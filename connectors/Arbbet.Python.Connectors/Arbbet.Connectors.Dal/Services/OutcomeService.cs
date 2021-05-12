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
    public class OutcomeService : ACrudEntityService<Outcome>
    {
        public static readonly Func<IQueryable<Outcome>, IQueryable<Outcome>> WithAllProperties = elm => WithTeam(WithBet(elm));
        public static readonly Func<IQueryable<Outcome>, IQueryable<Outcome>> WithBet = elm => elm.Include(elm => elm.Bet);
        public static readonly Func<IQueryable<Outcome>, IQueryable<Outcome>> WithTeam = elm => elm.Include(elm => elm.Team);

        public OutcomeService(ConnectorDbContext connectorDbContext, PerformanceStatService performanceStatService) : base(connectorDbContext, performanceStatService)
        {
        }

        public IEnumerable<Outcome> GetOutcomesForBet(Guid betId)
        {
            using (var ms = new MonitoredScope(_performanceStatService) { Type = MonitoredScopeType.Database })
            {
                return _entities.Where(elm => elm.BetId == betId).Include(elm => elm.Team);
            }
        }
    }
}
