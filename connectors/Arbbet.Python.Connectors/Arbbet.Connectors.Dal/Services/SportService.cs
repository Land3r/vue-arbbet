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
    public class SportService : AUnifiedEntityService<Sport, SportDto>
    {
        public static readonly Func<IQueryable<Sport>, IQueryable<Sport>> WithAllProperties = elm => WithPlatform(elm).AsNoTracking();
        public static readonly Func<IQueryable<Sport>, IQueryable<Sport>> WithPlatform = elm => elm.Include(item => item.Platform).AsNoTracking();

        public SportService(ConnectorDbContext connectorDbContext, PerformanceStatService performanceStatService, IMapper mapper) : base(connectorDbContext, performanceStatService, mapper)
        {
        }
    }
}