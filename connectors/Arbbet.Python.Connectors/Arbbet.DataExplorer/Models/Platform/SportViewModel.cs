using Arbbet.Domain.Entities;
using Arbbet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Models.Platform
{
    public class SportViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public Guid? UnifiedEntityId { get; set; }

        public Sport UnifiedEntity { get; set; }

        public UnifiedType UnifiedType { get; set; }

        public Guid? PlatformId { get; set; }

        public virtual PlatformViewModel Platform { get; set; }

        public string Platform_Id { get; set; }
    }
}
