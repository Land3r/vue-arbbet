using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Performances;
using Arbbet.Domain.Entities;
using Arbbet.Domain.Enums;
using Arbbet.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using static Arbbet.Connectors.Dal.Services.Enums;

namespace Arbbet.Connectors.Dal.Services
{
    public class BetService : AUnifiedEntityService<Bet>
    {
        public static readonly Func<IQueryable<Bet>, IQueryable<Bet>> WithAllProperties = elm => WithPlatform(WithCountry(WithSport(elm)));

        public static readonly Func<IQueryable<Bet>, IQueryable<Bet>> WithPlatform = elm => elm.Include(elm => elm.Event);

        public BetService(ConnectorDbContext connectorDbContext, PerformanceStatService performanceStatService) : base(connectorDbContext, performanceStatService)
        {
        }

        public IEnumerable<Bet> GetBetsForEvent(Guid eventId)
        {
            return this.Where(elm => elm.EventId == eventId);
        }

        public Bet GetBetForEvent(Guid eventId, BetType betType)
        {
            return this.FirstOrDefault(elm => elm.EventId == eventId && elm.BetType == betType);
        }
    }
}
