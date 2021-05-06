using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.AspNet.Helper.Core
{
  public static class BreadcrumbHelper
  {
    public static bool ShowFirstPage { get; set; } = true;
    public static readonly PageDefinition SiteDefinition = new PageDefinition()
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
  }

  public class PageDefinition
  {
    public string Name { get; set; }

    public string Icon { get; set; }

    public string Page { get; set; }

    public string Path { get; set; }

    public int Order { get; set; }

    public IList<PageDefinition> Childrens { get; set; }
  }
}
