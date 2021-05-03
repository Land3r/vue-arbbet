using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Performances;
using Arbbet.Domain.Entities;
using Arbbet.Domain.ViewModels;

using AutoMapper;

namespace Arbbet.Connectors.Dal.Services
{
  public class CountryService : ACrudEntityService<Country, CountryDto>
  {
    public CountryService(ConnectorDbContext context, PerformanceStatService performanceStatService, IMapper mapper) : base(context, performanceStatService, mapper)
    {
    }
  }
}
