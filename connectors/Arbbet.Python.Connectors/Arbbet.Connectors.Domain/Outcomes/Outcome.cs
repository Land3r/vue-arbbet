using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Events;

namespace Arbbet.Connectors.Domain.Outcomes
{
  /// <summary>
  /// Outcome class.
  /// A possible Outcome for an Event.
  /// </summary>
  public class Outcome
  {
    /// <summary>
    /// The Id of the Outcome.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// The type of the Outcome
    /// </summary>
    public OutcomeType OutcomeType { get; set; }

    /// <summary>
    /// Additionnal data
    /// TODO: Surement besoin de cela a un moment ou à un autre.
    /// </summary>
    public string AdditionnalData { get; set; }

    /// <summary>
    /// The odd associated with this Outcome.
    /// </summary>
    public decimal Odd { get; set; }

    /// <summary>
    /// The parent event that hosts that Outcome.
    /// </summary>
    public Event Event { get; set; }

    /// <summary>
    /// The date at which the Outcome is no longer valid. Odd may have change, and it needs to be updated.
    /// </summary>
    public DateTime ExpiresAt { get; set; }
  }
}
