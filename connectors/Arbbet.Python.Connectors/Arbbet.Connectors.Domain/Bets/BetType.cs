using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Domain.Bets
{
  public enum BetType
  {
    /// <summary>
    /// Known as 1/2
    /// </summary>
    WIN_LOSE = 1,

    /// <summary>
    /// Known as 1/N/2
    /// </summary>
    WIN_DRAW_LOSE = 2
  }
}
