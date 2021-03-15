using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Enums;
using Arbbet.Domain.Interfaces;

namespace Arbbet.Domain.Entities
{
  public class Sport : IIdentifiable, ICodeNamed, IUnifiedEntity<Sport>
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public Guid? UnifiedEntityId { get; set; }

    [ForeignKey("UnifiedEntityId")]
    public virtual Sport UnifiedEntity { get; set; }

    public UnifiedType UnifiedType { get; set; }

    public Guid? PlatformId { get; set; }

    [ForeignKey("PlatformId")]
    public virtual Platform Platform { get; set; }

    public string Platform_Id { get; set; }

    public virtual IList<Competition> Competitions { get; set; }
  }
}
