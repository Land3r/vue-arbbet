using Arbbet.Domain.Enums;

namespace Arbbet.Connectors.Unibet.Models
{
  public class PlatformOutcome
  {
    public OutcomeType Type { get; set; }
    public decimal Odd { get; set; }

    public string TeamName { get; set; }
  }
}