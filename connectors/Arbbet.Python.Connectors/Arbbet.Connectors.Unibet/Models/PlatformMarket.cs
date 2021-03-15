using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Unibet.Models
{
  public class PlatformMarket : IEquatable<PlatformMarket>
  {
    public string Type { get; set; }

    public string Name { get; set; }

    public bool Equals(PlatformMarket other)
    {
      return this.Type == other.Type
        && this.Name == other.Name;
    }
  }
}
