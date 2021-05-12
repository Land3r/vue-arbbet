using Arbbet.AspNet.Helper.Reflexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.AspNet.Helper.Navigation
{
    public static class SiteNavigationHelper
    {
        public static bool ShowFirstSection { get; set; } = true;

        // Register all Page navigations
        // Note that this process requires reflexion and should be done once, then saved and use the results already queried.
        public static IList<IPageNavigationDefinition> GetNavigationForAssembly(Assembly assembly)
        {
            IEnumerable<Type> pages = ReflexionHelper.GetTypesWithAttribute(assembly, typeof(PageNavigationAttribute));

            IList<IPageNavigationDefinition> siteDefinition = new List<IPageNavigationDefinition>();

            foreach (Type pageType in pages)
            {
                PageNavigationAttribute pageNavAttribute = pageType.GetCustomAttribute<PageNavigationAttribute>(false);
                if (pageNavAttribute != null)
                {
                    siteDefinition.Add(new PageNavigationDefinition()
                    {
                        Name = pageNavAttribute.Name,
                        PageUrl = pageNavAttribute.PageUrl,
                        PageType = pageNavAttribute.PageType,
                        ParentType = pageNavAttribute.ParentType,
                        Icon = pageNavAttribute.Icon,
                        Badge = pageNavAttribute.Badge,
                        Order = pageNavAttribute.Order
                    });
                }
            }

            return siteDefinition;
        }
    }
}
