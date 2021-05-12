using Arbbet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Helpers
{
    public static class UnifiedEntityHelper
    {
        public static string GetUnifiedBadge(UnifiedType unifiedType)
        {
            if (unifiedType == UnifiedType.Master)
            {
                return $"<span class=\"badge badge-danger\">{unifiedType}</span>";
            }
            else if (unifiedType == UnifiedType.Platform)
            {
                return $"<span class=\"badge badge-primary\">{unifiedType}</span>";
            }
            else
            {
                return $"<span class=\"badge badge-info\">Unknown</span>";
            }
        }
    }
}
