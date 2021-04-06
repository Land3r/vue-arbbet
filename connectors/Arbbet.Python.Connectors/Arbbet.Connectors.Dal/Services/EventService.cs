using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Performances;
using Arbbet.Domain.Entities;

namespace Arbbet.Connectors.Dal.Services
{
  public class EventService : AUnifiedEntityService<Event>
  {
    public EventService(ConnectorDbContext context, PerformanceStatService performanceStatService) : base(context, performanceStatService)
    {
    }
  }
}
