using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Dal.Services;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

namespace Arbbet.Connectors.Dal.Configuration
{
  public static class ConfigurationExtension
  {
    public static IServiceCollection ConfigureDbContext(IServiceCollection services)
    {
      return services.AddDbContext<ConnectorDbContext>(options =>
            options.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=Arbbet;Integrated Security=true;Pooling=true;",
        optionsBuilder => optionsBuilder.MigrationsHistoryTable("__EFMigrationsHistory", "Domain")));
    }

    public static IServiceCollection ConfigureDI(IServiceCollection services)
    {
      return services
        .AddScoped<PlatformService>()
        .AddScoped<EventService>()
        .AddScoped<SportService>()
        .AddScoped<CompetitionService>()
        .AddScoped<TeamService>()
        .AddScoped<CountryService>()
        .AddScoped<EventService>()
        .AddScoped<BetService>()
        .AddScoped<OutcomeService>();
    }
  }
}
