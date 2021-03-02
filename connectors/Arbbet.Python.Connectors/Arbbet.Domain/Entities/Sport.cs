using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Interfaces;

namespace Arbbet.Domain.Entities
{
  public class Sport : IIdentifiable, ICodeNamed, IPlatformSpecific<string>
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public Guid? PlatformId { get; set; }
    public string Platform_Id { get; set; }
  }
}
