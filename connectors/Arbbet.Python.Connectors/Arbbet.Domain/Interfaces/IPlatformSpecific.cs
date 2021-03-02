using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Domain.Interfaces
{
  public interface IPlatformSpecific<TKey>
  {
    public Guid? PlatformId { get; set; }

    public TKey Platform_Id { get; set; }
  }
}
