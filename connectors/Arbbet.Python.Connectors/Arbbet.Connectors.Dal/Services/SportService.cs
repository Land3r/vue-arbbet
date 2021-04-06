using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Domain.Performances;
using Arbbet.Domain.Entities;

namespace Arbbet.Connectors.Dal.Services
{
  public class SportService : AUnifiedEntityService<Sport>
  {
    public SportService(ConnectorDbContext connectorDbContext, PerformanceStatService performanceStatService) : base(connectorDbContext, performanceStatService)
    {
    }
  }
}
