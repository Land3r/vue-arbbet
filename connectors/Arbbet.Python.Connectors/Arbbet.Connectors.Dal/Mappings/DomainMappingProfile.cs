using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Entities;
using Arbbet.Domain.ViewModels;

using AutoMapper;

namespace Arbbet.Connectors.Dal.Mappings
{
  public class DomainMappingProfile : Profile
  {
    public DomainMappingProfile()
    {
      CreateMap<Country, CountryDto>();
    }
  }
}
