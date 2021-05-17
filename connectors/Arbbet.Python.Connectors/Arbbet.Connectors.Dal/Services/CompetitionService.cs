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
    public class CompetitionService : AUnifiedEntityService<Competition, CompetitionDto>
    {
        public static readonly Func<IQueryable<Competition>, IQueryable<Competition>> WithAllProperties = elm => WithPlatform(WithCountry(WithSport(elm))).AsNoTracking();
        public static readonly Func<IQueryable<Competition>, IQueryable<Competition>> WithPlatform = elm => elm.Include(elm => elm.Platform).AsNoTracking();
        public static readonly Func<IQueryable<Competition>, IQueryable<Competition>> WithCountry = elm => elm.Include(elm => elm.Country).AsNoTracking();
        public static readonly Func<IQueryable<Competition>, IQueryable<Competition>> WithSport = elm => elm.Include(elm => elm.Sport).AsNoTracking();

        public CompetitionService(ConnectorDbContext context, PerformanceStatService performanceStatService, IMapper mapper) : base(context, performanceStatService, mapper)
        {
        }
    }
}
