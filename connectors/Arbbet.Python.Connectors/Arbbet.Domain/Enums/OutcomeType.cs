using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.Enums
{
  /// <summary>
  /// Outcome types.
  /// Represents all the kinds of outcome possible.
  /// </summary>
  public enum OutcomeType
  {
    /// <summary>
    /// 1
    /// </summary>
    Team_1_Win,

    /// <summary>
    /// 2
    /// </summary>
    Team_2_Win,

    /// <summary>
    /// N
    /// </summary>
    Team_Draw,

    /// <summary>
    /// Used for individual winner odds.
    /// </summary>
    Individual_Winner
  }
}
