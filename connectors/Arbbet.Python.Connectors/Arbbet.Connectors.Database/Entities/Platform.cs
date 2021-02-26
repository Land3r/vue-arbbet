using System;
using System.Collections.Generic;
using System.Text;

namespace Arbbet.Connectors.Database.Entities
{
    public class Platform
    {
        [DatabaseGenerated]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}
