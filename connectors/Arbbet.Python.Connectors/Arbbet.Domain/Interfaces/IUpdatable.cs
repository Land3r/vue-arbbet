using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.Interfaces
{
  public interface IUpdatable
  {
    public DateTime? UpdatedAt { get; set; }
  }
}
