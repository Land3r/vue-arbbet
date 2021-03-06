﻿using Arbbet.Domain.Bases;
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
  public class Competition : AUnifiedEntity<Competition>, IIdentifiable, INamed, ICountryLocalized, IUnifiedEntity<Competition>
  {
    public string Name { get; set; }

    public Guid SportId { get; set; }
    
    [ForeignKey("SportId")]
    public virtual Sport Sport { get; set; }

    public Guid? CountryId { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; }
  }
}
