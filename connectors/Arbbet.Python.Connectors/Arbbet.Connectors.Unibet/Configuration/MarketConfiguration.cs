using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Unibet.Models;

namespace Arbbet.Connectors.Unibet.Configuration
{
  public static class MarketConfiguration
  {
    public static readonly IList<string> ExcludedEntries = new List<string>()
    {
      "Accueil Paris Sportifs",
      "Promotions",
      "Cotes Boostées",
      "Super Cotes Boostées",
      "Unibet Experience"
    };

    public static readonly IList<PlatformMarket> IncludedEntries = new List<PlatformMarket>()
    {
      new PlatformMarket()
      {
        Type = "Résultat",
        Name = "Résultat du match",
      }
    };
  }
}
