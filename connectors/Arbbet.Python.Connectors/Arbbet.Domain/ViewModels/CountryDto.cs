using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Interfaces;

namespace Arbbet.Domain.ViewModels
{
  [DisplayName("Country")]
  public class CountryDto : IIdentifiable
  {
    //[Display(ResourceType = typeof(Domain.))]
    //[Display(Name = "Country.Id", ResourceType = typeof(Domain.Resources)]
    public Guid Id { get; set; }

    //[DisplayName("Country.Name", )]
    public string Name { get; set; }

    [DisplayName("Country.Code")]
    public string Code { get; set; }

    [DisplayName("Country.FlagName")]
    public string FlagName { get; set; }
  }
}
