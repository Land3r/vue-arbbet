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
          if (teams[0] == outcomeName)
          {
            return OutcomeType.Team_1_Win;
          }
          else if (teams[1] == outcomeName)
          {
            return OutcomeType.Team_2_Win;
          }
          else if (outcomeName == "Match Nul")
          {
            return OutcomeType.Team_Draw;
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
