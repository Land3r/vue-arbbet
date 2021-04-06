using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Performances;
using Arbbet.Domain.Entities;

namespace Arbbet.Connectors.Dal.Services
{
  public class CompetitionService : AUnifiedEntityService<Competition>
  {
    public CompetitionService(ConnectorDbContext context, PerformanceStatService performanceStatService) : base(context, performanceStatService)
    {
    }
  }
}
