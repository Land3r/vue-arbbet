using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.AspNet.Helper.Reflexion
{
  public static class ReflexionHelper
  {
    public static IEnumerable<Type> GetTypesWithAttribute(Assembly assembly, Type attributeType)
    {
      foreach (Type type in assembly.GetTypes())
      {
        if (type.GetCustomAttributes(attributeType, true).Length > 0)
        {
          yield return type;
        }
      }
    }
  }
}
