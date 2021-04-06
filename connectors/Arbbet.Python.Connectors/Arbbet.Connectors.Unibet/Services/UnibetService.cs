using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

using Arbbet.Connectors.Domain.Performances;
using Arbbet.Connectors.Unibet.Configuration;
using Arbbet.Connectors.Unibet.Extensions;
using Arbbet.Connectors.Unibet.Helpers;
using Arbbet.Connectors.Unibet.Models;
using Arbbet.Connectors.Unibet.Services.Models;
using Arbbet.Domain.Enums;

using Microsoft.Extensions.Logging;

namespace Arbbet.Connectors.Unibet.Services
{
  public class UnibetService
  {
    private readonly ILogger<UnibetService> _logger;
    private readonly PerformanceStatService _performanceStatService;
    private readonly string baseUrl = "https://www.unibet.fr/";

    private readonly HttpClient _httpClient;

    public UnibetService(ILogger<UnibetService> logger,
      HttpClient httpClient,
      PerformanceStatService performanceStatService)
    {
      _logger = logger;
      _performanceStatService = performanceStatService;

      httpClient.BaseAddress = new Uri(baseUrl);

      _httpClient = httpClient;
    }

    public async Task<IList<PlatformSport>> GetSportsAsync()
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Network })
      {
        var res = await _httpClient.GetAsync("/zones/menulist/all.json");

        res.EnsureSuccessStatusCode();

        using (var responseStream = await res.Content.ReadAsStreamAsync())
        {
          //using (StreamReader reader = new StreamReader(responseStream))
          //{
          //  string text = await reader.ReadToEndAsync();
          //}
          MenuListResult resObj = await JsonSerializer.DeserializeAsync<MenuListResult>(responseStream);
          IList<PlatformSport> platformSports = resObj.Menu.MenusLevel1More.Union(resObj.Menu.MenusLevel1).Where(sport => !SportConfiguration.ExcludedEntries.Contains(sport.Name))
            .Select(elm => new PlatformSport()
            {
              Id = elm.Id,
              Name = elm.Name
            }).ToList();

          return platformSports;
        }
      }
    }

    public async Task<IList<PlatformMarket>> GetMarketsAsync(int sportId)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Network })
      {
        var res = await _httpClient.GetAsync(string.Format("zones/sportnode/marketfilters.json?nodeId={0}", sportId));

        res.EnsureSuccessStatusCode();

        using (var responseStream = await res.Content.ReadAsStreamAsync())
        {
          //using (StreamReader reader = new StreamReader(responseStream))
          //{
          //  string text = await reader.ReadToEndAsync();
          //}

          MarketListResult resObj = await JsonSerializer.DeserializeAsync<MarketListResult>(responseStream);
          List<PlatformMarket> markets = new List<PlatformMarket>();
          PropertyInfo[] properties = typeof(MarketNames).GetProperties();
          foreach (PropertyInfo property in properties)
          {
            object subMarket = property.GetValue(resObj.MarketNames);
            if (subMarket?.GetType() == typeof(List<MarketDetail>))
            {
              IList<MarketDetail> subMarketTyped = (List<MarketDetail>)subMarket;
              markets.AddRange(subMarketTyped.Select(elm => new PlatformMarket()
              {
                Name = elm.Name,
                Type = property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name
              }));
            }
          }

          return markets;
        }
      }
    }

    public async Task<IList<PlatformEvent>> GetEventsAsync(int sportId, string marketType, string marketName)
    {
      using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Network })
      {
        var res = await _httpClient.GetAsync(string.Format("zones/sportnode/markets.json?nodeId={0}&filter={1}&marketname={2}", sportId, HttpUtility.HtmlAttributeEncode(marketType), HttpUtility.HtmlAttributeEncode(marketName)));

        res.EnsureSuccessStatusCode();

        using (var responseStream = await res.Content.ReadAsStreamAsync())
        {
          //using (StreamReader reader = new StreamReader(responseStream))
          //{
          //  string text = await reader.ReadToEndAsync();
          //}

          EventListResult resObj = await JsonSerializer.DeserializeAsync<EventListResult>(responseStream);
          List<PlatformEvent> events = new List<PlatformEvent>();
          foreach (MarketEventDay day in resObj.MarketsByType.FirstOrDefault()?.Days)
          {
            foreach (var sportEvent in day.Events)
            {
              var eventStartDate = DateTimeOffset.FromUnixTimeMilliseconds(sportEvent.EventStartDate);

              PlatformEvent platformEvent = new PlatformEvent()
              {
                Id = sportEvent.EventId,
                Name = sportEvent.EventName,
                CompetitionId = sportEvent.CompetitionId.ToString(),
                CompetitionName = sportEvent.CompetitionName,
                StartDate = eventStartDate.DateTime,
                Bets = new List<PlatformBet>()
              };

              if (platformEvent.CompetitionName.Split(", ").Length == 2)
              {
                var countryPlatformSplit = platformEvent.CompetitionName.Split(", ");
                platformEvent.CompetitionCountryName = countryPlatformSplit[0];
                platformEvent.CompetitionName = countryPlatformSplit[1];
              }

              foreach (var bet in sportEvent.Markets)
              {
                PlatformBet platformBet = new PlatformBet()
                {
                  Id = bet.MarketId,
                  Outcomes = new List<PlatformOutcome>()
                };

                if (platformEvent.HomeTeam == null)
                {
                  platformEvent.HomeTeam = bet.EventHomeTeamName;
                }

                if (platformEvent.AwayTeam == null)
                {
                  platformEvent.AwayTeam = bet.EventAwayTeamName;
                }

                if (platformEvent.Url == null)
                {
                  platformEvent.Url = bet.EventUrl;
                }

                BetType? betType = ConvergenceHelper.GetBetType(bet.MarketType);
                if (betType != null)
                {
                  platformBet.Type = betType.Value;
                }

                foreach (var outcome in bet.Selections)
                {
                  PlatformOutcome platformOutcome = new PlatformOutcome();

                  if (outcome.Name == "Match nul")
                  {
                    platformOutcome.TeamName = null;
                  }
                  else
                  {
                    platformOutcome.TeamName = outcome.Name;
                  }

                  OutcomeType? outcomeType = ConvergenceHelper.GetOutcomeType(platformEvent.Name, platformBet.Type, outcome.Name);
                  if (outcomeType != null)
                  {
                    platformOutcome.Type = outcomeType.Value;
                  }

                  platformOutcome.Odd = ConvergenceHelper.GetOdd(Decimal.Parse(outcome.CurrentPriceDown), Decimal.Parse(outcome.CurrentPriceUp));

                  platformBet.Outcomes.Add(platformOutcome);
                }

                platformEvent.Bets.Add(platformBet);
              }

              events.Add(platformEvent);
            }
          }

          return events;
        }

      }
    }
  }
}
