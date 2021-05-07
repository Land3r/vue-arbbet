using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.AspNet.Helper.Breadcrumbs
{
  [System.AttributeUsage(System.AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
  public sealed class BreadcrumbAttribute : Attribute
  {
    public string Name { get; private set; }

    public string Icon { get; set; }

    public Type PageType { get; set; }

    public string PageUrl { get; private set; }

    public Type ParentType { get; set; }

    // This is a positional argument
    public BreadcrumbAttribute(string name, string pageUrl)
    {
      this.Name = name;
      this.PageUrl = pageUrl;
    }
  }
}
