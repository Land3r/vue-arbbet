using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Bets;
using Arbbet.Connectors.Domain.Competitions;
using Arbbet.Connectors.Domain.Outcomes;
using Arbbet.Connectors.Domain.Platforms;

namespace Arbbet.Connectors.Domain.Events
{
  /// <summary>
  /// Event class.
  /// An event is a physical occurence (typically of a match between two teams) on which you can bet on.
  /// </summary>
  public class Event
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
    /// The Outcomes possible of the Event.
    /// </summary>
    public virtual IList<Outcome> Outcomes { get; set; }

    /// <summary>
    /// The competition of the Event.
    /// </summary>
    public virtual Competition Competition { get; set; }

    /// <summary>
    /// Parent event of this event.
    /// Allows to link Events between them, for platform specific tracking.
    /// </summary>
    public virtual Event UnifiedEvent { get; set; }

    /// <summary>
    /// The date at which the Event was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The date at which the Event was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    #region Vendor specific fields

    /// <summary>
    /// The Platform on which this Event was registered on.
    /// </summary>
    public virtual Platform Platform { get; set; }

    /// <summary>
    /// The platform specific id for the Event.
    /// </summary>
    public string Platform_id { get; set; }

    /// <summary>
    /// The platform specific url for the Event.
    /// </summary>
    public string Platform_url { get; set; }

    #endregion Vendor specific fields
  }
}
