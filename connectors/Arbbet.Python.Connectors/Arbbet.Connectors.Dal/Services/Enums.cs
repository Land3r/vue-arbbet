using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.Connectors.Dal.Services
{
  public static class Enums
  {
    public enum CRUD_RESULT
    {
      NONE,
      CREATED,
      UPDATED,
      DELETED,
      ERROR
    }
  }
}
