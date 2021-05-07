using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.AspNet.Helper.Core.Definition;

namespace Arbbet.AspNet.Helper.Breadcrumbs
{
  public class BreadcrumbsProvider
  {
    public IList<BreadcrumbDefinition> _breadcrumbs { get; set; }

    public BreadcrumbsProvider()
    {
      _breadcrumbs = BreadcrumbsHelper.GetBreadcrumbsForAssembly()
    }
    
  }
}
