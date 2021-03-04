using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Arbbet.Domain.Entities
{
  [Index(nameof(Code))]
  public class Platform : ICodeNamed, IIdentifiable
  {
    /// <summary>
    /// The Id of the Platform.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// The Name of the Platform.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The Code of the Platform.
    /// </summary>
    public string Code { get; set; }
  }
}
