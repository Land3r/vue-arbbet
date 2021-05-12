using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Helpers
{
    public static class PlatformHelper
    {
        public static string GetPlatformBadge(string platformName)
        {
            return $"<span class=\"badge badge-info\">{platformName}</span>";
        }
    }
}
