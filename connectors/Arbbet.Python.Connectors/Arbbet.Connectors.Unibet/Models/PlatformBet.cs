using System.Collections.Generic;

using Arbbet.Domain.Enums;

namespace Arbbet.Connectors.Unibet.Models
{
  public class PlatformBet
  {
    public string Id { get; set; }

    public BetType Type { get; set; }

    public IList<PlatformOutcome> Outcomes { get; set; }
  }
}