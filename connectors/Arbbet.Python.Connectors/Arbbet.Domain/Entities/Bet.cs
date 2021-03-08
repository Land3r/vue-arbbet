using Arbbet.Domain.Enums;
using Arbbet.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arbbet.Domain.Entities
{
  public class Bet : IIdentifiable, INamed, IUnifiedEntity<Bet>
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual IList<Outcome> Outcomes { get; set; }

    /// <summary>
    /// The date at which the Bet was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The date at which the Bet was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    public DateTime ExpiresAt { get; set; }

    public Guid EventId { get; set; }

    [ForeignKey("EventId")]
    public virtual Event Event { get; set; }

    public virtual BetType BetType { get; set; }

    public Guid? UnifiedEntityId { get; set; }

    [ForeignKey("UnifiedEntityId")]
    public virtual Bet UnifiedEntity { get; set; }

    public virtual UnifiedType UnifiedType { get; set; }

    public Guid? PlatformId { get; set; }

    [ForeignKey("PlatformId")]
    public Platform Platform { get; set; }

    public string Platform_Id { get; set; }
  }
}