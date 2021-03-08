using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.Enums
{
    public enum BetType
    {
        /// <summary>
        /// Known as 1/2
        /// </summary>
        Win_Lose = 1,

        /// <summary>
        /// Known as 1/N/2
        /// </summary>
        Win_Draw_Lose = 2,

        /// <summary>
        /// Handicap [0:1]
        /// </summary>
        Handicap_0_1 = 3
    }
}
