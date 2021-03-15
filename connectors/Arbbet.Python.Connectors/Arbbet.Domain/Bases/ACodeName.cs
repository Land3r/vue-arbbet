using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Interfaces;

namespace Arbbet.Domain.Bases
{
  /// <summary>
  /// ACodeName abstract class.
  /// Entity base class to represent a Key / Value pair.
  /// </summary>
  public abstract class ACodeName : ICodeNamed, IIdentifiable
  {
    /// <summary>
    /// The Id of the Entity.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// The Code of the Entity.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// The Name of the Entity.
    /// </summary>
    public string Name { get; set; }
  }
}
