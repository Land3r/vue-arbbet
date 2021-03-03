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
        TEAM_1_WIN,

        /// <summary>
        /// 2
        /// </summary>
        TEAM_2_WIN,

        /// <summary>
        /// N
        /// </summary>
        TEAM_DRAW,

        /// <summary>
        /// Used for individual winner odds.
        /// </summary>
        INDIVIDUAL_WINNER
    }
}
