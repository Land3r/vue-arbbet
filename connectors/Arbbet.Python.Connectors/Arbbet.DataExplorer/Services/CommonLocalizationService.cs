using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.Extensions.Localization;

namespace Arbbet.DataExplorer.Services
{
  public class CommonLocalizationService : IStringLocalizer
  {
    private readonly IStringLocalizer localizer;
    public CommonLocalizationService(IStringLocalizerFactory factory)
    {
      var assemblyName = new AssemblyName(typeof(Program).GetTypeInfo().Assembly.FullName);
      localizer = factory.Create(nameof(Program), assemblyName.Name);
    }

    public LocalizedString this[string name] => localizer[name];

    public LocalizedString this[string name, params object[] arguments] => localizer[name, arguments];

    public string Get(string key)
    {
      return localizer[key];
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
      return localizer.GetAllStrings();
    }
  }
}
