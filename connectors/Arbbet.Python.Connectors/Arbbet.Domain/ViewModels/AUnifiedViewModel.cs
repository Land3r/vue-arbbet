using Arbbet.Domain.Entities;
using Arbbet.Domain.Enums;
using Arbbet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.ViewModels
{
    public class AUnifiedViewModel : IPlatformSpecific<string>, IIdentifiable
    {
        public virtual Guid Id { get; set; }

        public virtual Guid? PlatformId { get; set; }

        public virtual Platform Platform { get; set; }

        public virtual string Platform_Id { get; set; }

        public virtual Guid? UnifiedEntityId { get; set; }

        public virtual UnifiedType UnifiedType { get; set; }
    }
}