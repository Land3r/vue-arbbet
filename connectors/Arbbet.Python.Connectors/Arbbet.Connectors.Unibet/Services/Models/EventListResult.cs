using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Unibet.Services.Models
{
  public class EventListResult
  {
    [JsonPropertyName("marketsByType")]
    public IList<MarketEventContainer> MarketsByType { get; set; }
  }

  public class MarketEventContainer
  {
    [JsonPropertyName("marketName")]
    public string MarketName { get; set; }

    [JsonPropertyName("days")]
    public IList<MarketEventDay> Days { get; set; }
  }

  public class MarketEventDay
  {
    [JsonPropertyName("day")]
    public long Day { get; set; }

    [JsonPropertyName("events")]
    public IList<MarketEvent> Events { get; set; }
  }

  public class MarketEvent
  {
    [JsonPropertyName("eventId")]
    public string EventId { get; set; }

    [JsonPropertyName("eventName")]
    public string EventName { get; set; }

    [JsonPropertyName("eventStartDate")]
    public long EventStartDate { get; set; }

    [JsonPropertyName("competitionId")]
    public long CompetitionId { get; set; }

    [JsonPropertyName("competitionName")]
    public string CompetitionName { get; set; }

    [JsonPropertyName("markets")]
    public IList<MarketBet> Markets { get; set; }
  }

  public class MarketBet
  {
    [JsonPropertyName("eventId")]
    public string EventId { get; set; }

    [JsonPropertyName("marketId")]
    public string MarketId { get; set; }

    [JsonPropertyName("marketName")]
    public string MarketName { get; set; }

    [JsonPropertyName("eventName")]
    public string EventName { get; set; }

    [JsonPropertyName("competitionId")]
    public double CompetitionId { get; set; }

    [JsonPropertyName("competitionName")]
    public string CompetitionName { get; set; }

    [JsonPropertyName("eventStartDate")]
    public long EventStartDate { get; set; }

    [JsonPropertyName("marketType")]
    public string MarketType { get; set; }

    [JsonPropertyName("eventHomeTeamName")]
    public string EventHomeTeamName { get; set; }

    [JsonPropertyName("eventAwayTeamName")]
    public string EventAwayTeamName { get; set; }

    [JsonPropertyName("eventFriendlyUrl")]
    public string EventUrl { get; set; }

    [JsonPropertyName("selections")]
    public IList<BetSelection> Selections { get; set; }
  }

  public class BetSelection
  {
    [JsonPropertyName("selectionId")]
    public string SelectionId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("currentPriceUp")]
    public string CurrentPriceUp { get; set; }

    [JsonPropertyName("currentPriceDown")]
    public string CurrentPriceDown { get; set; }
  }
}
