using Arbbet.AspNet.Helper.Core.Definition;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Data
{
  public static class SiteDefinition
  {
    public static readonly PageDefinition SiteNavigation = new PageDefinition()
    {
      Name = "Data",
      Icon = "fas fa-funnel-dollar",
      Childrens = new List<PageDefinition>() {
        new PageDefinition() {
          Name = "Countries",
          Icon = "fas fa-flag",
          Page = "/Countries/Index",
          Path = "/Countries",
          Order = 1
        },
        new PageDefinition()
        {
          Name = "Teams",
          Icon = "fas fa-users",
          Page = "/Teams/Index",
          Path = "/Teams",
          Order = 2
        },
        new PageDefinition()
        {
          Name = "Platforms",
          Path = "/Platforms",
          Order = 3,
          Childrens = new List<PageDefinition>()
          {
            new PageDefinition()
            {
              Name = "Test1",
              Icon = "fa fa-plus",
              Page = "/Platforms/4",
              Path = "/Platforms/4"
            },
            new PageDefinition()
            {
              Name = "Test2",
              Icon = "fa fa-plus",
              Page = "/Platforms/9",
              Path = "/Platforms/9"
            }
          }
        }
      }
    };

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
