using Arbbet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.Entities
{
    public class Country : IIdentifiable, ICodeNamed
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
