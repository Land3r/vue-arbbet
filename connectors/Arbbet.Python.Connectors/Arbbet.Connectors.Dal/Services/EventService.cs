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
    public class EventService : AUnifiedEntityService<Event>
    {
        public static Func<IQueryable<Event>, IQueryable<Event>> WithAllProperties = elm => WithPlatform(WithParticipants(WithBets(WithCompetition(elm))));
        public static Func<IQueryable<Event>, IQueryable<Event>> WithPlatform = elm => elm.Include(elm => elm.Platform);
        public static Func<IQueryable<Event>, IQueryable<Event>> WithParticipants = elm => elm.Include(elm => elm.Participants);
        public static Func<IQueryable<Event>, IQueryable<Event>> WithBets = elm => elm.Include(elm => elm.Bets);
        public static Func<IQueryable<Event>, IQueryable<Event>> WithCompetition = elm => elm.Include(elm => elm.Competition);

        public EventService(ConnectorDbContext context, PerformanceStatService performanceStatService) : base(context, performanceStatService)
        {
        }
    }
}
