using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Entities;
using Arbbet.Domain.Enums;
using Arbbet.Domain.Interfaces;

namespace Arbbet.Domain.Bases
{
  /// <summary>
  /// AUnifiedEntity abstract class.
  /// </summary>
  /// <typeparam name="TEntity">The type of the Entity being Unified.</typeparam>
  public abstract class AUnifiedEntity<TEntity> : APlatformSpecific, IIdentifiable
  {
    /// <summary>
    /// The Id of the Entity.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// The Id of the unified <typeparamref name="TEntity"/>
    /// </summary>
    public Guid? UnifiedEntityId { get; set; }

    /// <summary>
    /// The <typeparamref name="TEntity"/> entity unified, if any.
    /// </summary>
    [ForeignKey("UnifiedEntityId")]
    public virtual TEntity UnifiedEntity { get; set; }

    /// <summary>
    /// The Unification status of the <typeparamref name="TEntity"/>
    /// </summary>
    public virtual UnifiedType UnifiedType { get; set; }
  }
}
