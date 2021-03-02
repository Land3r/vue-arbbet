using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Enums;

namespace Arbbet.Domain.Interfaces
{
  public interface IUnifiedEntity<TEntity> : IPlatformSpecific
  {
    public TEntity? UnifiedEntity { get; set; }

    public Guid? UnifiedEntityId { get; set; }

    public UnifiedType UnifiedType { get; set; }
  }
}
