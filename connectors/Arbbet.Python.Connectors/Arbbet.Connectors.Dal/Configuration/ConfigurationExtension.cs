using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

namespace Arbbet.Connectors.Dal.Configurations
{
  public static class ConfigurationExtension
  {
    public static IServiceCollection Configure(IServiceCollection services)
    {
      return services.AddDbContext<ConnectorDbContext>(options =>
            options.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=Arbbet;Integrated Security=true;Pooling=true;"));
    }
  }
}
