using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.AspNet.Helper.Breadcrumbs
{
    public class BreadcrumbsProvider : IBreadcrumbsProvider
    {
        public IList<IBreadcrumbDefinition> _breadcrumbs { get; set; }

        public BreadcrumbsProvider(Assembly assembly)
        {
            _breadcrumbs = BreadcrumbsHelper.GetBreadcrumbsForAssembly(assembly);
        }

        public BreadcrumbsProvider()
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            if (assembly.GetName().Name == "Microsoft.Extensions.DependencyInjection")
            {
                assembly = Assembly.GetEntryAssembly();
            }
            _breadcrumbs = BreadcrumbsHelper.GetBreadcrumbsForAssembly(assembly);
        }

        public LinkedList<IBreadcrumbDefinition> GetBreadcrumbsHierarchyForType(Type pagetype)
        {
            LinkedList<IBreadcrumbDefinition> res = new LinkedList<IBreadcrumbDefinition>();

            // Get end node
            var endNode = _breadcrumbs.FirstOrDefault(elm => elm.PageType == pagetype);

            if (endNode != null)
            {
                res.AddFirst(endNode);

                if (endNode.ParentType != null)
                {
                    do
                    {
                        endNode = GetParentNode(endNode.ParentType, _breadcrumbs);
                        res.AddFirst(endNode);
                    }
                    while (endNode.ParentType != null);
                }
            }

            return res;
        }

        private IBreadcrumbDefinition GetParentNode(Type pagetype, IList<IBreadcrumbDefinition> breadcrumbsDefinition)
        {
            return breadcrumbsDefinition.FirstOrDefault(elm => elm.PageType == pagetype);
        }
    }
}
