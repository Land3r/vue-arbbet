using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Arbbet.DataExplorer.Identity.Configuration;
using Arbbet.DataExplorer.Identity.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Arbbet.DataExplorer.Areas.Identity.Pages.Account
{
  public class ManageModel : PageModel
  {
    private readonly UserManager<ArbbetUser> _userManager;
    private readonly SignInManager<ArbbetUser> _signInManager;
    private readonly ILogger<ManageModel> _logger;
    private readonly IdentityConfiguration _identityConfiguration;


    public ManageModel(UserManager<ArbbetUser> userManager,
            SignInManager<ArbbetUser> signInManager,
            ILogger<ManageModel> logger,
            IOptions<IdentityConfiguration> identityConfiguration)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _logger = logger;
      _identityConfiguration = identityConfiguration.Value;
    }

    [BindProperty(SupportsGet = true)]
    public string ActivePage { get; set; }

    [BindProperty]
    public InputChangePasswordModel InputChangePassword { get; set; }

    [TempData]
    public string StatusChangePasswordMessage { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
      var user = await _userManager.GetUserAsync(User);
      if (user == null)
      {
        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
      }

      // Security tab
      // Password
      var hasPassword = await _userManager.HasPasswordAsync(user);
      if (!hasPassword)
      {
        return RedirectToPage("./SetPassword");
      }

      // 2FA
      TwoFactorAuthentication = new TwoFactorAuthenticationModel();
      TwoFactorAuthentication.TwoFactorAuthenticationAvailable = _identityConfiguration.TwoFactorAuthenticationRules.Enabled;
      TwoFactorAuthentication.HasAuthenticator = await _userManager.GetAuthenticatorKeyAsync(user) != null;
      TwoFactorAuthentication.TwoFactorAuthenticationEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
      TwoFactorAuthentication.IsMachineRemembered = await _signInManager.IsTwoFactorClientRememberedAsync(user);
      TwoFactorAuthentication.RecoveryCodesLeft = await _userManager.CountRecoveryCodesAsync(user);

      return Page();
    }

    public async Task<IActionResult> OnPostUpdatePasswordAsync()
    {
      ActivePage = "Security";

      if (!ModelState.IsValid)
      {
        return Page();
      }

      var user = await _userManager.GetUserAsync(User);
      if (user == null)
      {
        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
      }

      var changePasswordResult = await _userManager.ChangePasswordAsync(user, InputChangePassword.OldPassword, InputChangePassword.NewPassword);
      if (!changePasswordResult.Succeeded)
      {
        foreach (var error in changePasswordResult.Errors)
        {
          if (error.Code == "PasswordMismatch")
          {
            ModelState.AddModelError("InputChangePassword.OldPassword", error.Description);
          }
          else
          {
            ModelState.AddModelError("InputChangePassword.NewPassword", error.Description);
          }
        }
        return Page();
      }

      await _signInManager.RefreshSignInAsync(user);
      _logger.LogInformation("User changed their password successfully.");
      StatusChangePasswordMessage = "Your password has been changed.";

      return RedirectToPage(new { ActivePage = "Security"});
    }

    [BindProperty]
    public TwoFactorAuthenticationModel TwoFactorAuthentication { get; set; }

    [TempData]
    public string TwoFactorAuthenticationMessage { get; set; }

    public class InputChangePasswordModel
    {
      [Required]
      [DataType(DataType.Password)]
      [Display(Name = "Current password")]
      public string OldPassword { get; set; }

      [Required]
      [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
      [DataType(DataType.Password)]
      [Display(Name = "New password")]
      public string NewPassword { get; set; }

      [DataType(DataType.Password)]
      [Display(Name = "Confirm new password")]
      [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
      public string ConfirmPassword { get; set; }
    }

    public class TwoFactorAuthenticationModel
    {
      public bool TwoFactorAuthenticationAvailable { get; set; }
      
      public bool TwoFactorAuthenticationEnabled { get; set; }
      
      public int? RecoveryCodesLeft { get; set; }

      public bool? IsMachineRemembered { get; set; }

      public bool? HasAuthenticator { get; set; }
    }
  }
}

