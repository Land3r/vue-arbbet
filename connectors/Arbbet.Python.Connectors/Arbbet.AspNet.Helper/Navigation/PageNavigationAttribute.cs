using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.AspNet.Helper.Navigation
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class PageNavigationAttribute : Attribute
    {
        public PageNavigationAttribute(string name, string pageUrl)
        {
            this.Name = name;
            this.PageUrl = pageUrl;
        }

        public string Name { get; private set; }

        public string Icon { get; set; }

        public string PageUrl { get; private set; }

        public Type PageType { get; set; }

        public int Order { get; set; }

        public Type ParentType { get; set; }
    }
}