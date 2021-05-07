using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.AspNet.Helper.Navigation
{
    public class SiteNavigationProvider
    {
        public IList<IPageNavigationDefinition> _siteDefinition { get; set; }

        public SiteNavigationProvider(Assembly assembly)
        {
            _siteDefinition = SiteNavigationHelper.GetNavigationForAssembly(assembly);
        }

        public SiteNavigationProvider()
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            if (assembly.GetName().Name == "Microsoft.Extensions.DependencyInjection")
            {
                assembly = Assembly.GetEntryAssembly();
            }
            _siteDefinition = SiteNavigationHelper.GetNavigationForAssembly(assembly);
        }

        public void AddDefinition(IList<IPageNavigationDefinition> definition)
        {
            _siteDefinition = _siteDefinition.Concat(definition).ToList();
        }

        public IList<NavigationNode> GetNavigation()
        {
            IList<NavigationNode> res = new List<NavigationNode>();

            // Process site definition, to go from a flat list, to a navigation tree
            IList<IPageNavigationDefinition> navigationSections = _siteDefinition.Where(elm => elm.ParentType == null).ToList();

            foreach (var section in navigationSections)
            {
                NavigationNode node = new NavigationNode()
                {
                    Name = section.Name,
                    Icon = section.Icon,
                    Order = section.Order,
                    PageUrl = section.PageUrl,
                    Path = null,
                    Childrens = new List<NavigationNode>()
                };

                var childs = GetChildrenPageDefinitionForType(section.PageType);
                foreach (var child in childs)
                {

                }

                res.Add(node);
            }

            //_siteDefinition.FirstOrDefault(elm => elm.)
            return res;
        }

        private NavigationNode GetNavigationNodeForType(Type type)
        {
            Action<NavigationNode> SetChildren = null;
            SetChildren = parent =>
            {
                parent.Childrens = _siteDefinition
                    .Where(childItem => childItem.ParentType == type)
                    .Select(elm => new NavigationNode()
                    {
                        Name = elm.Name,
                        Icon = elm.Icon,
                        Order = elm.Order,
                        PageUrl = elm.PageUrl,
                        Path = null,
                        Childrens = new List<NavigationNode>()
                    })
                    .ToList();

                //Recursively call the SetChildren method for each child.
                parent.Childrens.ForEach(SetChildren);
            };

            //Initialize the hierarchical list to root level items
            List<NavigationNode> hierarchicalItems = _siteDefinition
                .Where(rootItem => rootItem.ParentType == null)
                .Select(elm => new NavigationNode()
                {
                    Name = elm.Name,
                    Icon = elm.Icon,
                    Order = elm.Order,
                    PageUrl = elm.PageUrl,
                    Path = null,
                    Childrens = new List<NavigationNode>()
                }).ToList();

            //Call the SetChildren method to set the children on each root level item.
            hierarchicalItems.ForEach(SetChildren);
        }


        private IList<NavigationNode> GetChildrenPageDefinitionForType(Type type)
        {
            return _siteDefinition.Where(elm => elm.ParentType == type).ToList();
        }
    }
}
