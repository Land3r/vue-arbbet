using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Unibet.Models
{
  public class PlatformEvent
  {
    public string Id { get; set; }

    public string Name { get; set; }

    public DateTime StartDate { get; set; }

    public string CompetitionId { get; set; }

    public string CompetitionName { get; set; }

    public string CompetitionCountryName { get; set; }

    public string HomeTeam { get; set; }

    public string AwayTeam { get; set; }

    public string Url { get; set; }

    public IList<PlatformBet> Bets { get; set; }
  }
}
