using Arbbet.Connectors.Domain.Performances;
using Arbbet.Domain.Entities;
using Arbbet.Domain.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Dal.Services
{
    public class PlatformService : ACrudEntityService<Platform, PlatformDto>
    {
        public static readonly Func<IQueryable<Platform>, IQueryable<Platform>> WithAllProperties = elm => elm;

        public PlatformService(ConnectorDbContext connectorDbContext, PerformanceStatService performanceStatService, IMapper mapper) : base(connectorDbContext, performanceStatService, mapper)
        {
        }
    }
}
