using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Domain.Performances
{
  public class PerformanceStatService
  {
    private IList<PerformanceStat> _stats = new List<PerformanceStat>();

    public PerformanceStatService()
    {
    }

    public void AddStat(PerformanceStat stat)
    {
      _stats.Add(stat);
    }

    public void RemoveStat(PerformanceStat stat)
    {
      _stats.Remove(stat);
    }

    public IEnumerable<PerformanceStat> Aggregate()
    {
      return _stats.GroupBy(elm => elm.Type)
        .Select(elm => new PerformanceStat()
        {
          Name = "Aggregate",
          TimeElapsed = elm.Sum(elm2 => elm2.TimeElapsed),
          Type = elm.Key
        });
    }
  }
}
