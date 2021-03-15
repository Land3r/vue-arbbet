using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Entities;
using Arbbet.Domain.Interfaces;

namespace Arbbet.Domain.Bases
{
  /// <summary>
  /// APlatformSpecific abstract class.
  /// Entity base class to reprensents Entity that is specific to a <see cref="Platform"/>.
  /// </summary>
  public abstract class APlatformSpecific : IPlatformSpecific<string>
  {
    /// <summary>
    /// The Id of the <see cref="Platform"/> this Entity belongs to.
    /// </summary>
    public Guid? PlatformId { get; set; }

    /// <summary>
    /// The <see cref="Platform"/> this entity belongs to.
    /// </summary>
    [ForeignKey("PlatformId")]
    public Platform Platform { get; set; }

    /// <summary>
    /// The Id of this Entity on the target Platform.
    /// Used for tracking items.
    /// </summary>
    public string Platform_Id { get; set; }
  }
}
