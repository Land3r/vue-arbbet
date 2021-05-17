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
    public class OutcomeService : ACrudEntityService<Outcome, OutcomeDto>
    {
        public static readonly Func<IQueryable<Outcome>, IQueryable<Outcome>> WithAllProperties = elm => WithTeam(WithBet(elm)).AsNoTracking();
        public static readonly Func<IQueryable<Outcome>, IQueryable<Outcome>> WithBet = elm => elm.Include(elm => elm.Bet).AsNoTracking();
        public static readonly Func<IQueryable<Outcome>, IQueryable<Outcome>> WithTeam = elm => elm.Include(elm => elm.Team).AsNoTracking();

        public OutcomeService(ConnectorDbContext connectorDbContext, PerformanceStatService performanceStatService, IMapper mapper) : base(connectorDbContext, performanceStatService, mapper)
        {
        }

        public IEnumerable<OutcomeDto> GetOutcomesForBet(Guid betId)
        {
            using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
            {
                return this.Where(elm => elm.BetId == betId, WithTeam);
            }
        }
    }
}
