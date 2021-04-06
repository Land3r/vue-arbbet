using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Domain.Performances
{
  public class PerformanceStat
  {
    public string Name { get; set; }

    public MonitoredScopeType? Type { get; set; }

    public long TimeElapsed { get; set; }
  }
}
