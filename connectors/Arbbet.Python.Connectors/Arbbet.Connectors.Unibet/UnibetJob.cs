
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Dal;
using Arbbet.Connectors.Unibet.Configuration;
using Arbbet.Connectors.Unibet.Models;
using Arbbet.Connectors.Unibet.Services;
using Arbbet.Domain.Entities;

using Microsoft.Extensions.Logging;

namespace Arbbet.Connectors.Unibet
{
  public class UnibetJob
  {
    private static string jobName = "UnibetJob";
    private static string platformCode = "UNI";

    private readonly ILogger<UnibetJob> _logger;
    private readonly ConnectorDbContext _context;
    private readonly UnibetService _service;

    private Platform _platform;

    public UnibetJob(ILogger<UnibetJob> logger,
      ConnectorDbContext context,
      UnibetService unibetService)
    {
      _logger = logger;
      _context = context;
      _service = unibetService;
    }

    public async Task<bool> Run()
    {
      try
      {
        _logger.Log(LogLevel.Information, "{0} starting", jobName) ;

        _platform = _context.Platforms.FirstOrDefault(eml => eml.Code == UnibetJob.platformCode);
        _logger.Log(LogLevel.Debug, "Platform {0} found", _platform.Name);

        var sports = await _service.GetSportsAsync();
        _logger.Log(LogLevel.Debug, "Retrieved {0} sports", sports.Count());

        foreach (PlatformSport sport in sports)
        {
          _logger.Log(LogLevel.Debug, "Processing {0}", sport.Name);

          if (sport.Name == "Football")
          {
            var markets = await _service.GetMarketsAsync(sport.Id);
            _logger.Log(LogLevel.Debug, "Retrieved {0} markets for {1}", markets.Count(), sport.Name);

            foreach (PlatformMarket market in markets)
            {
              if (MarketConfiguration.IncludedEntries.Contains(market))
              {
                _logger.Log(LogLevel.Debug, "Processing market {0} for {1}", market.Name, sport.Name);
                
                var events = await _service.GetEventsAsync(sport.Id, market.Type, market.Name);
                _logger.Log(LogLevel.Debug, "Retrieved {0} events for market {1}", events.Count(), market.Name);

                foreach (PlatformEvent platformEvent in events)
                {
                  _logger.Log(LogLevel.Debug, "Processing event {0} for {1}", platformEvent.Name, platformEvent.CompetitionName);



                  _logger.Log(LogLevel.Debug, "Finished processing event {0}", platformEvent.Name);
                }
              }

              _logger.Log(LogLevel.Debug, "Finished processing market {0}", market.Name);
            }
          }

          _logger.Log(LogLevel.Debug, "Finished processing sport {0}", sport.Name);
        }

        _logger.Log(LogLevel.Information, "{0} stopping", jobName);
        return true;
      }
      catch (Exception ex)
      {
        _logger.Log(LogLevel.Critical, ex, "{0} exception", jobName);
        return false;
      }
      finally
      {
      }
    }
  }
}
