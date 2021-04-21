using Arbbet.DataExplorer.Identity.Dal;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Arbbet.DataExplorer.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Arbbet.DataExplorer.Identity.Configuration
{
  public static class ConfigurationExtension
  {
    public static IServiceCollection ConfigureIdentity(IServiceCollection services)
    {
      services.AddDbContext<ArbbetIdentityDbContext>(options =>
            options.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=Arbbet.Identity;Integrated Security=true;Pooling=true;"));

      services.AddIdentity<ArbbetUser, ArbbetRole>()
        .AddEntityFrameworkStores<ArbbetIdentityDbContext>()
        .AddDefaultTokenProviders();

      services.ConfigureApplicationCookie(options =>
      {
        options.LoginPath = $"/Identity/Account/Login";
        options.LogoutPath = $"/Identity/Account/Logout";
        options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
      });

      return services;
    }
  }
}
