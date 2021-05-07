using Arbbet.AspNet.Helper.Core.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.AspNet.Helper.Core
{
    public static class BreadcrumbHelper
    {
        public static LinkedList<IBreadcrumbDefinition> GetHierarchyForType(Type pagetype, IList<IBreadcrumbDefinition> breadcrumbDefinition)
        {
            LinkedList<IBreadcrumbDefinition> res = new LinkedList<IBreadcrumbDefinition>();

            // Get end node
            var endNode = breadcrumbDefinition.FirstOrDefault(elm => elm.PageType == pagetype);

            if (endNode != null)
            {
                res.AddFirst(endNode);

                if (endNode.ParentType != null)
                {
                    do
                    {
                        endNode = GetParentNode(endNode.ParentType, breadcrumbDefinition);
                        res.AddFirst(endNode);

                    }
                    while (endNode.ParentType != null);
                }
            }

            return res;
        }

        private static IBreadcrumbDefinition GetParentNode(Type pagetype, IList<IBreadcrumbDefinition> breadcrumbDefinition)
        {
            return breadcrumbDefinition.FirstOrDefault(elm => elm.PageType == pagetype);
        }
    }
}
