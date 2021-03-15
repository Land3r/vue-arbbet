using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Unibet.Configuration
{
  public static class SportConfiguration
  {
    public static readonly IList<string> ExcludedEntries = new List<string>()
    {
      "Accueil Paris Sportifs",
      "Promotions",
      "Cotes Boostées",
      "Super Cotes Boostées",
      "Unibet Experience"
    };
  }
}
