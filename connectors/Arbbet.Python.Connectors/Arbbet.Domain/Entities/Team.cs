using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Bases;
using Arbbet.Domain.Enums;
using Arbbet.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Arbbet.Domain.Entities
{
  public class Team : AUnifiedEntity<Team>, IIdentifiable, INamed, ICountryLocalized
  {
    public string Name { get; set; }

    public TeamType TeamType { get; set; }

    public Guid? SportId { get; set; }

    [ForeignKey("SportId")]
    public virtual Sport Sport { get; set; }

    public Guid? CountryId { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; }

    public virtual IList<Event> Events { get; set; }
  }
}
