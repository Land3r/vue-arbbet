using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Domain.Entities;

namespace Arbbet.Domain.Seeds
{
  class Platforms
  {
    public static IList<Platform> Data = new List<Platform>()
    {
      new Platform()
      {
        Id = Guid.Parse("01cb8b1d-5b7f-4545-aba0-a0b8bd46b9bf"),
        Name = "FDJ",
        Code = "FDJ"
      }
    };
  }
}
