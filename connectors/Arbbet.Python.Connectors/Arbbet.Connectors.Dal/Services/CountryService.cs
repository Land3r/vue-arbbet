using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Performances;
using Arbbet.Domain.Entities;
using Arbbet.Domain.ViewModels;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Arbbet.Connectors.Dal.Services
{
    public class CountryService : ACrudEntityService<Country, CountryDto>
    {
        public static Func<IQueryable<Country>, IQueryable<Country>> WithAllProperties = elm => elm;

        public CountryService(ConnectorDbContext context, PerformanceStatService performanceStatService, IMapper mapper) : base(context, performanceStatService, mapper)
        {
        }
    }
}
