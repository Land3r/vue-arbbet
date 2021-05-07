using Arbbet.AspNet.Helper.Breadcrumbs;
using Arbbet.AspNet.Helper.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Data
{
    public static class SiteDefinition
    {

      //  public static readonly PageNavigationDefinition SiteNavigation = new PageNavigationDefinition()
      //  {
      //      Name = "Data",
      //      Icon = "fas fa-funnel-dollar",
      //      Childrens = new List<PageNavigationDefinition>() {
      //  new PageNavigationDefinition() {
      //    Name = "Countries",
      //    Icon = "fas fa-flag",
      //    PageUrl = "/Countries/Index",
      //    Path = "/Countries",
      //    Order = 1
      //  },
      //  new PageNavigationDefinition()
      //  {
      //    Name = "Teams",
      //    Icon = "fas fa-users",
      //    PageUrl = "/Teams/Index",
      //    Path = "/Teams",
      //    Order = 2
      //  },
      //  new PageNavigationDefinition()
      //  {
      //    Name = "Platforms",
      //    Path = "/Platforms",
      //    Order = 3,
      //    Childrens = new List<PageNavigationDefinition>()
      //    {
      //      new PageNavigationDefinition()
      //      {
      //        Name = "Test1",
      //        Icon = "fa fa-plus",
      //        PageUrl = "/Platforms/4",
      //        Path = "/Platforms/4"
      //      },
      //      new PageNavigationDefinition()
      //      {
      //        Name = "Test2",
      //        Icon = "fa fa-plus",
      //        PageUrl = "/Platforms/9",
      //        Path = "/Platforms/9"
      //      }
      //    }
      //  }
      //}
      //  };

        // TODO: Ce serait bien de passer sur un systeme d'annotation et d'autoenregistrement des 
        public static readonly IList<IBreadcrumbDefinition> Breadcrumbs = new List<IBreadcrumbDefinition>()
        {
            new BreadcrumbDefinition()
            {
                Name = "Countries",
                Icon = "fa fa-home",
                PageType = typeof(Pages.Countries.IndexModel),
                PageUrl = "/Countries/Index",
                ParentType = null
            },
            new BreadcrumbDefinition()
            {
                Name = "Edit Country",
                Icon = "fas fa-flag",
                PageType = typeof(Pages.Countries.UpsertModel),
                PageUrl = "/Countries/Upsert",
                ParentType = typeof(Pages.Countries.IndexModel)
            },
        };
    }
}
