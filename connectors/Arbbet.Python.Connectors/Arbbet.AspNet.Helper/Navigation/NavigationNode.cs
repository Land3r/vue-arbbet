using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.AspNet.Helper.Navigation
{
    public class NavigationNode
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public string PageUrl { get; set; }

        public Type PageType { get; set; }

        public int Order { get; set; }

        public IList<NavigationNode> Childrens { get; set; }

        public bool? Actif { get; set; }
    }
}
