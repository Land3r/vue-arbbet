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
  public class Competition : IIdentifiable, INamed, ICountryLocalized, IUnifiedEntity<Competition>
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid SportId { get; set; }
    
    [ForeignKey("SportId")]
    public virtual Sport Sport { get; set; }

    public Guid? CountryId { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; }

    public Guid? PlatformId { get; set; }

    [ForeignKey("PlatformId")]
    public virtual Platform Platform { get; set; }

    public string Platform_Id { get; set; }

    public Guid? UnifiedEntityId { get; set; }

    [ForeignKey("UnifiedEntityId")]
    public virtual Competition UnifiedEntity { get; set; }

    public virtual UnifiedType UnifiedType { get; set; }
  }
}
