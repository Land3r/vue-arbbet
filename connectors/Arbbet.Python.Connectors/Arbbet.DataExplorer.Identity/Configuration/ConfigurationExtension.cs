using Arbbet.DataExplorer.Identity.Dal;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Arbbet.DataExplorer.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Arbbet.DataExplorer.Identity.Configuration
{
  public static class ConfigurationExtension
  {
    public static IServiceCollection ConfigureIdentity(IServiceCollection services, IOptions<IdentityConfiguration> configurationOptions)
    {
      services.AddDbContext<ArbbetIdentityDbContext>(options =>
            options.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=Arbbet.Identity;Integrated Security=true;Pooling=true;"));

      services.AddIdentity<ArbbetUser, ArbbetRole>(options =>
      {
        options.Password.RequiredLength = configurationOptions.Value.PasswordRules.RequiredLength;
        options.Password.RequireLowercase = configurationOptions.Value.PasswordRules.RequireLowercase;
        options.Password.RequireUppercase = configurationOptions.Value.PasswordRules.RequireUppercase;
        options.Password.RequireDigit = configurationOptions.Value.PasswordRules.RequireDigit;
        options.Password.RequireNonAlphanumeric = configurationOptions.Value.PasswordRules.RequireNonAlphanumeric;

        options.Lockout.AllowedForNewUsers = configurationOptions.Value.LockoutRules.AllowedForNewUsers;
        options.Lockout.DefaultLockoutTimeSpan = configurationOptions.Value.LockoutRules.DefaultLockoutTimeSpan;
        options.Lockout.MaxFailedAccessAttempts = configurationOptions.Value.LockoutRules.MaxFailedAccessAttempts;

        options.User.AllowedUserNameCharacters = configurationOptions.Value.UserRules.AllowedUserNameCharacters;
        options.User.RequireUniqueEmail = configurationOptions.Value.UserRules.RequireUniqueEmail;

        options.SignIn.RequireConfirmedAccount = configurationOptions.Value.SignInRules.RequireConfirmedAccount;
        options.SignIn.RequireConfirmedEmail = configurationOptions.Value.SignInRules.RequireConfirmedEmail;
        options.SignIn.RequireConfirmedPhoneNumber = configurationOptions.Value.SignInRules.RequireConfirmedPhoneNumer;
      })
        .AddEntityFrameworkStores<ArbbetIdentityDbContext>()
        .AddDefaultTokenProviders();

      services.ConfigureApplicationCookie(options =>
      {
        options.LoginPath = $"/Identity/Account/Login";
        options.LogoutPath = $"/Identity/Account/Logout";
        options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
        options.Cookie.Name = configurationOptions.Value.CookieConfiguration.Name;
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = configurationOptions.Value.CookieConfiguration.ExpireTimeSpan;
        options.SlidingExpiration = configurationOptions.Value.CookieConfiguration.SlidingExpiration;
      });

      return services;
    }
  }
}
