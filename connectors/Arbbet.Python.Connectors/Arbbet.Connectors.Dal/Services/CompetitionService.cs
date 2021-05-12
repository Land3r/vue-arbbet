using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Performances;
using Arbbet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arbbet.Connectors.Dal.Services
{
    public class CompetitionService : AUnifiedEntityService<Competition>
    {
        public static readonly Func<IQueryable<Competition>, IQueryable<Competition>> WithAllProperties = elm => WithPlatform(WithCountry(WithSport(elm)));
        public static readonly Func<IQueryable<Competition>, IQueryable<Competition>> WithPlatform = elm => elm.Include(elm => elm.Platform);
        public static readonly Func<IQueryable<Competition>, IQueryable<Competition>> WithCountry = elm => elm.Include(elm => elm.Country);
        public static readonly Func<IQueryable<Competition>, IQueryable<Competition>> WithSport = elm => elm.Include(elm => elm.Sport);

        public CompetitionService(ConnectorDbContext context, PerformanceStatService performanceStatService) : base(context, performanceStatService)
        {
        }
    }
}
