using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Performances;
using Arbbet.Domain.Entities;
using Arbbet.Domain.Enums;
using Arbbet.Domain.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static Arbbet.Connectors.Dal.Services.Enums;

namespace Arbbet.Connectors.Dal.Services
{
    public class BetService : AUnifiedEntityService<Bet, BetDto>
    {
        public static readonly Func<IQueryable<Bet>, IQueryable<Bet>> WithAllProperties = elm => WithPlatform(WithEvent(WithOutcomes(elm)));

        public static readonly Func<IQueryable<Bet>, IQueryable<Bet>> WithPlatform = elm => elm.Include(elm => elm.Platform);
        public static readonly Func<IQueryable<Bet>, IQueryable<Bet>> WithEvent = elm => elm.Include(elm => elm.Event);
        public static readonly Func<IQueryable<Bet>, IQueryable<Bet>> WithOutcomes = elm => elm.Include(elm => elm.Outcomes);

        public BetService(ConnectorDbContext connectorDbContext, PerformanceStatService performanceStatService, IMapper mapper) : base(connectorDbContext, performanceStatService, mapper)
        {
        }

        public IEnumerable<BetDto> GetBetsForEvent(Guid eventId)
        {
            return this.Where(elm => elm.EventId == eventId);
        }

        public BetDto GetBetForEvent(Guid eventId, BetType betType)
        {
            return this.FirstOrDefault(elm => elm.EventId == eventId && elm.BetType == betType);
        }
    }
}
