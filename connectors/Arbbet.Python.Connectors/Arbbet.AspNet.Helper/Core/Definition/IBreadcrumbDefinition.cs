using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.AspNet.Helper.Core.Definition
{
    public interface IBreadcrumbDefinition
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public Type PageType { get; set; }

        public string Page { get; set; }

        public Type Parent { get; set; }
    }
}
