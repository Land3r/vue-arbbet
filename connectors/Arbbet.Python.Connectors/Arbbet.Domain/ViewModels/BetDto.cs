using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Enums;

namespace Arbbet.Domain.ViewModels
{
  public class BetDto
  {
    public Guid? Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime ExpiresAt { get; set; }

    public Guid EventId { get; set; }

    // TODO: Outcomes.

    public virtual EventDto Event { get; set; }

    public virtual BetType BetType { get; set; }

    public Guid? PlatformId { get; set; }

    public string Platform_Id { get; set; }

    public BetDto UnifiedEntity { get; set; }

    public Guid? UnifiedEntityId { get; set; }

    public UnifiedType UnifiedType { get; set; }
  }
}
