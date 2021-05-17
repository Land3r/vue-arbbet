using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Enums;

namespace Arbbet.Domain.ViewModels
{
  [DisplayName("Team")]
  public class TeamDto : AUnifiedViewModel
  {
    [DisplayName("Team.Name")]
    public string Name { get; set; }

    [DisplayName("Team.TeamType")]
    public TeamType TeamType { get; set; }

    [DisplayName("Team.SportId")]
    public Guid? SportId { get; set; }

    [DisplayName("Team.Sport")]
    public virtual SportDto Sport { get; set; }

    [DisplayName("Team.CountryId")]
    public Guid? CountryId { get; set; }

    [DisplayName("Team.Country")]
    public virtual CountryDto Country { get; set; }
  }
}
