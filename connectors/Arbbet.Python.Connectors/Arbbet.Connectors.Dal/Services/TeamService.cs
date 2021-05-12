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
    public class TeamService : ACrudEntityService<Team, TeamDto>
    {
        public static readonly Func<IQueryable<Team>, IQueryable<Team>> WithAllProperties = elm => WithCountry(WithSport(WithPlatform(elm)));
        public static readonly Func<IQueryable<Team>, IQueryable<Team>> WithPlatform = elm => elm.Include(item => item.Platform);
        public static readonly Func<IQueryable<Team>, IQueryable<Team>> WithSport = elm => elm.Include(item => item.Sport);
        public static readonly Func<IQueryable<Team>, IQueryable<Team>> WithCountry = elm => elm.Include(item => item.Country);

        public TeamService(ConnectorDbContext connectorDbContext, PerformanceStatService performanceStatService, IMapper mapper) : base(connectorDbContext, performanceStatService, mapper)
        {
        }
    }
}