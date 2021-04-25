using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Identity.Helpers
{
  public static class UserHelperExtensions
  {
    public static string GetInitials(string username)
    {
      if (string.IsNullOrEmpty(username))
      {
        return string.Empty;
      }

      if (username.Split(' ').Length > 1)
      {
        var split = username.Split(' ');
        return split[0].Substring(0, 1).ToUpperInvariant() + split[1].Substring(0, 1).ToUpperInvariant();
      }
      else if (username.Split('@').Length > 1)
      {
        var split = username.Split('@');
        return GetInitials(split[0]);
      }
      else if (username.Split('.').Length > 1)
      {
        var split = username.Split('.');
        return split[0].Substring(0, 1).ToUpperInvariant() + split[1].Substring(0, 1).ToUpperInvariant();
      }
      else if (username.Length >= 2)
      {
        return username.Substring(0, 2).ToUpperInvariant();
      }
      else
      {
        return username.ToUpperInvariant();
      }
    }
  }
}
