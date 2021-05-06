using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.AspNet.Helper.Core.Definition
{
    public interface ISiteNavigationDefinition<TEntity>
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public string Page { get; set; }

        public string Path { get; set; }

        public int Order { get; set; }

        public IList<TEntity> Childrens { get; set; }
    }
}
