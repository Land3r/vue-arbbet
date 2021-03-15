using Arbbet.Domain.Enums;
using Arbbet.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.Entities
{
  public class Event : IIdentifiable, INamed, IUnifiedEntity<Event>
  {
    /// <summary>
    /// The Id of the Event.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// The name of the Event.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The type of Event.
    /// </summary>
    public virtual EventType EventType { get; set; }

    /// <summary>
    /// The Teams participating in the Event.
    /// </summary>
    public virtual IList<Team> Participants { get; set; }

    public DateTime? StartDate { get; set; }

    /// <summary>
    /// The possible bets of the Event.
    /// </summary>
    public virtual IList<Bet> Bets { get; set; }

    /// <summary>
    /// The competition of the Event.
    /// </summary>
    public virtual Competition Competition { get; set; }

    /// <summary>
    /// The date at which the Event was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The date at which the Event was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    public string Url { get; set; }

    public Guid? UnifiedEntityId { get; set; }

    [ForeignKey("UnifiedEntityId")]
    public virtual Event UnifiedEntity { get; set; }

    public UnifiedType UnifiedType { get; set; }

    public Guid? PlatformId { get; set; }

    [ForeignKey("PlatformId")]
    public virtual Platform Platform { get; set; }

    public string Platform_Id { get; set; }
  }
}
