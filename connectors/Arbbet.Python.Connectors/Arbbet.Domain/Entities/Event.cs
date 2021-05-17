using Arbbet.Domain.Bases;
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
  public class Event : AUnifiedEntity<Event>, IIdentifiable, INamed, IUnifiedEntity<Event>, IUpdatable
  {
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

    public Guid? CompetitionId { get; set; }

    [ForeignKey("CompetitionId")]
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
    public DateTime? UpdatedAt { get; set; }

    public string Url { get; set; }
  }
}
