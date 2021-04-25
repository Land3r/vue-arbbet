using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.DataExplorer.Identity.Configuration
{
  public class IdentityConfiguration
  {
    public static string SectionName = "Identity";

    public PasswordRulesConfiguration PasswordRules { get; set; }

    public LockoutRulesConfiguration LockoutRules { get; set; }

    public UserRulesConfiguration UserRules { get; set; }

    public SignInRulesConfiguration SignInRules { get; set; }

    public TwoFactorAuthenticationRules TwoFactorAuthenticationRules { get; set; }

    public bool AllowRegistration { get; set; }

    public bool ConfirmEmail { get; set; }
  }

  public class PasswordRulesConfiguration
  {
    public int RequiredLength { get; set; }

    public bool RequireLowercase { get; set; }

    public bool RequireUppercase { get; set; }

    public bool RequireNonAlphanumeric { get; set; }

    public bool RequireDigit { get; set; }
  }

  public class LockoutRulesConfiguration
  {
    public bool AllowedForNewUsers { get; set; }

    public TimeSpan DefaultLockoutTimeSpan { get; set; }

    public int MaxFailedAccessAttempts { get; set; }
  }

  public class UserRulesConfiguration
  {
    public string AllowedUserNameCharacters { get; set; }

    public bool RequireUniqueEmail { get; set; }
  }

  public class SignInRulesConfiguration
  {
    public bool RequireConfirmedAccount { get; set; }

    public bool RequireConfirmedEmail { get; set; }

    public bool RequireConfirmedPhoneNumer { get; set; }
  }

  public class TwoFactorAuthenticationRules
  {
    public bool Enabled { get; set; }
  }
}
