using Arbbet.AspNet.Helper.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Data.Navigation
{
    [PageNavigation("Data", null, Icon = "fas fa-funnel-dollar", Order = 1, PageType = typeof(DataNavigation), ParentType = null, Badge = "Hoooot")]
    public class DataNavigation : INavigationSection
    {
    }
}
