using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Configuration
{
  public class LanguageConfiguration
  {
    public static string SectionName = "Language";

    public string DefaultCulture { get; set; }

    public IList<string> SupportedCultures { get; set; }
  }
}
