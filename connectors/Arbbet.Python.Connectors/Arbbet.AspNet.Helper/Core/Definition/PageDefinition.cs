using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.AspNet.Helper.Core.Definition
{
    public class PageDefinition : ISiteNavigationDefinition<PageDefinition>
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public string Page { get; set; }

        public Type Parent { get; set; }

        public Type Type { get; set; }

        public string Path { get; set; }

        public int Order { get; set; }

        public IList<PageDefinition> Childrens { get; set; }
    }
}
