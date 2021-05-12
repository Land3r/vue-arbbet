using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Arbbet.AspNet.Helper.Navigation
{
    public class SiteNavigationProvider
    {
        public IList<IPageNavigationDefinition> _siteDefinition { get; set; }

        public IDictionary<Type, NavigationNode> _navigationNodes { get; set; }

        public SiteNavigationProvider(Assembly assembly)
        {
            _siteDefinition = SiteNavigationHelper.GetNavigationForAssembly(assembly);
            _navigationNodes = BuildHierarchericalTree(_siteDefinition);
        }

        public SiteNavigationProvider()
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            if (assembly.GetName().Name == "Microsoft.Extensions.DependencyInjection")
            {
                assembly = Assembly.GetEntryAssembly();
            }
            _siteDefinition = SiteNavigationHelper.GetNavigationForAssembly(assembly);
            _navigationNodes = BuildHierarchericalTree(_siteDefinition);
        }

        public void AddDefinition(IList<IPageNavigationDefinition> definition)
        {
            _siteDefinition = _siteDefinition.Concat(definition).ToList();
            _navigationNodes = BuildHierarchericalTree(_siteDefinition);
        }

        public IDictionary<Type, NavigationNode> BuildHierarchericalTree(IList<IPageNavigationDefinition> navigationNodes)
        {
            var treeDict = navigationNodes
                .Select(elm => new NavigationNode()
                {
                    Name = elm.Name,
                    Icon = elm.Icon,
                    Badge = elm.Badge,
                    Order = elm.Order,
                    PageUrl = elm.PageUrl,
                    PageType = elm.PageType,
                    Childrens = new List<NavigationNode>()
                }).ToDictionary(elm => elm.PageType);

            // group flat objects by their ParentId
            var flatObjectsGroupedByParentId = navigationNodes.Where(item => item.ParentType != null).GroupBy(item => item.ParentType);
            foreach (var group in flatObjectsGroupedByParentId)
            {
                // find each group's parent object
                NavigationNode parent;
                if (treeDict.TryGetValue(group.Key, out parent))
                {
                    // convert the group of flat objects to a list of heirarchial objects by looking up the correct heirarchial object from the dictionary
                    parent.Childrens = group.Select(item => treeDict[item.PageType]).ToList();
                }
                else
                {
                    // something's wrong!!!  ParentId refers to a non-existant object.
                    // TODO: Error
                }
            }

            return treeDict;
        }

        public IDictionary<Type, NavigationNode> BuildHierarchericalTree(IList<IPageNavigationDefinition> navigationNodes, HttpContext context)
        {
            var treeDict = navigationNodes
                .Select(elm => new NavigationNode()
                {
                    Name = elm.Name,
                    Icon = elm.Icon,
                    Badge = elm.Badge,
                    Order = elm.Order,
                    PageUrl = elm.PageUrl,
                    PageType = elm.PageType,
                    Childrens = new List<NavigationNode>(),
                    Actif = !string.IsNullOrEmpty(elm.PageUrl) && context.Request.Path.HasValue && routeMatches(context, elm.PageUrl)
                }).ToDictionary(elm => elm.PageType);

            // group flat objects by their ParentId
            var flatObjectsGroupedByParentId = navigationNodes.Where(item => item.ParentType != null).GroupBy(item => item.ParentType);
            foreach (var group in flatObjectsGroupedByParentId)
            {
                // find each group's parent object
                NavigationNode parent;
                if (treeDict.TryGetValue(group.Key, out parent))
                {
                    // convert the group of flat objects to a list of heirarchial objects by looking up the correct heirarchial object from the dictionary
                    parent.Childrens = group.Select(item => treeDict[item.PageType]).ToList();
                }
                else
                {
                    // something's wrong!!!  ParentId refers to a non-existant object.
                    // TODO: Error
                }
            }

            return treeDict;
        }

        private bool routeMatches(HttpContext context, string pageUrl)
        {
            if (pageUrl.EndsWith("/Index"))
            {
                pageUrl = pageUrl.Replace("/Index", string.Empty);
            }

            return context.Request.Path.ToString().StartsWith(pageUrl);
        }

        public IDictionary<Type, NavigationNode> BuildHierarchericalTree(IList<IPageNavigationDefinition> navigationNodes, string pageUrl)
        {
            var treeDict = navigationNodes
                .Select(elm => new NavigationNode()
                {
                    Name = elm.Name,
                    Icon = elm.Icon,
                    Badge = elm.Badge,
                    Order = elm.Order,
                    PageUrl = elm.PageUrl,
                    PageType = elm.PageType,
                    Childrens = new List<NavigationNode>(),
                    Actif = pageUrl.StartsWith(elm.PageUrl)
                }).ToDictionary(elm => elm.PageType);

            // group flat objects by their ParentId
            var flatObjectsGroupedByParentId = navigationNodes.Where(item => item.ParentType != null).GroupBy(item => item.ParentType);
            foreach (var group in flatObjectsGroupedByParentId)
            {
                // find each group's parent object
                NavigationNode parent;
                if (treeDict.TryGetValue(group.Key, out parent))
                {
                    // convert the group of flat objects to a list of heirarchial objects by looking up the correct heirarchial object from the dictionary
                    parent.Childrens = group.Select(item => treeDict[item.PageType]).ToList();
                }
                else
                {
                    // something's wrong!!!  ParentId refers to a non-existant object.
                    // TODO: Error
                }
            }

            return treeDict;
        }

        public IList<NavigationNode> GetNavigation(HttpContext context)
        {
            var res = BuildHierarchericalTree(_siteDefinition, context).Values.ToList();

            IList<Type> parents = _siteDefinition.Where(elm => elm.ParentType == null).Select(elm => elm.PageType).ToList();
            return res.Where(elm => parents.Contains(elm.PageType)).ToList();
        }

        public string GetPageIcon(Type pageType)
        {
            var elm = _navigationNodes.FirstOrDefault(elm => elm.Key == pageType);
            if (elm.Value != null)
            {
                return elm.Value.Icon;
            }

            return null;
        }
    }
}
