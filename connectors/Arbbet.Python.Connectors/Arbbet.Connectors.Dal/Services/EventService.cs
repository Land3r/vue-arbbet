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
    public class EventService : AUnifiedEntityService<Event, EventDto>
    {
        public static Func<IQueryable<Event>, IQueryable<Event>> WithAllProperties = elm => WithPlatform(WithParticipants(WithBets(WithCompetition(elm)))).AsNoTracking();
        public static Func<IQueryable<Event>, IQueryable<Event>> WithPlatform = elm => elm.Include(elm => elm.Platform).AsNoTracking();
        public static Func<IQueryable<Event>, IQueryable<Event>> WithParticipants = elm => elm.Include(elm => elm.Participants).AsNoTracking();
        public static Func<IQueryable<Event>, IQueryable<Event>> WithBets = elm => elm.Include(elm => elm.Bets).AsNoTracking();
        public static Func<IQueryable<Event>, IQueryable<Event>> WithCompetition = elm => elm.Include(elm => elm.Competition).AsNoTracking();

        public EventService(ConnectorDbContext context, PerformanceStatService performanceStatService, IMapper mapper) : base(context, performanceStatService, mapper)
        {
        }
    }
}
