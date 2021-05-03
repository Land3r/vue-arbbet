using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.ViewModels
{
  public class CountryDto
  {
    public Guid? Id { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public string FlagName { get; set; }
  }
}
