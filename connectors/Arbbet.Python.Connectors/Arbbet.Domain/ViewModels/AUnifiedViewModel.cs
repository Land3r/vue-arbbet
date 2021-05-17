using Arbbet.Domain.Entities;
using Arbbet.Domain.Enums;
using Arbbet.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.ViewModels
{
  public class AUnifiedViewModel : IPlatformSpecific<string>, IIdentifiable
  {
    [DisplayName("Id")]
    public virtual Guid Id { get; set; }

    [DisplayName("Platform.Id")]
    public virtual Guid? PlatformId { get; set; }

    [DisplayName("Platform")]
    public virtual Platform Platform { get; set; }

    [DisplayName("Platform_Id")]
    public virtual string Platform_Id { get; set; }

    [DisplayName("UnifiedEntityId")]
    public virtual Guid? UnifiedEntityId { get; set; }

    [DisplayName("UnifiedType")]
    public virtual UnifiedType UnifiedType { get; set; }
  }
}