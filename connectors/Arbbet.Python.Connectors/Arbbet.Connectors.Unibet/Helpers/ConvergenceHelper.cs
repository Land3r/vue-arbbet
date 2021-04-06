using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Enums;

namespace Arbbet.Connectors.Unibet.Helpers
{
  public static class ConvergenceHelper
  {
    public static BetType? GetBetType(string marketType)
    {
      if (marketType == "1x2")
      {
        return BetType.Win_Draw_Lose;
      }
      else
      {
        return null;
      }
    }

    public static OutcomeType? GetOutcomeType(string eventName, BetType betType, string outcomeName)
    {
      if (betType == BetType.Win_Draw_Lose)
      {
        var teams = eventName.Split(" - ");
        if (teams.Length == 2)
        {
          if (outcomeName == "Match nul")
          {
            return OutcomeType.Team_Draw;
          }
          else
          {
            // Dans le cas des paris 1x2, on represente les options comme Equipe A gagnante / Equipe B gagnante plutot que Equipe A gagnante / Equipe A perdante
            return OutcomeType.Team_Win;
          }
        }
        else
        {
          return null;
        }
      }
      else
      {
        return null;
      }
    }

    public static decimal GetOdd(decimal lower, decimal upper)
    {
      return 1 + (upper / lower);
    }
  }
}
