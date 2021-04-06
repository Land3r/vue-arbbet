using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Enums;

namespace Arbbet.Domain.ViewModels
{
  public class TeamDto
  {
    public Guid? Id { get; set; }

    public string Name { get; set; }

    public TeamType TeamType { get; set; }

    public Guid? SportId { get; set; }

    public virtual SportDto Sport { get; set; }

    public Guid? CountryId { get; set; }

    public virtual CountryDto Country { get; set; }
  }
}
