using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Domain.Statistics
{
  public class Statistic
  {
    public long Created { get; set; }
    public long Updated { get; set; }
    public long Deleted { get; set; }
    public long Retrieved { get; set; }

    public Statistic()
    {
      Created = 0;
      Updated = 0;
      Deleted = 0;
      Retrieved = 0;
    }
  }
}
