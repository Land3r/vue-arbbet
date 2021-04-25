using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Arbbet.DataExplorer.Identity.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Arbbet.DataExplorer.Areas.Identity.Pages.Account
{
  [AllowAnonymous]
  public class LogoutModel : PageModel
  {
    private readonly SignInManager<ArbbetUser> _signInManager;
    private readonly ILogger<LogoutModel> _logger;

    public LogoutModel(SignInManager<ArbbetUser> signInManager, ILogger<LogoutModel> logger)
    {
      _signInManager = signInManager;
      _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync()
    {
      if (User.Identity.IsAuthenticated)
      {
        await DoLogoutAsync();
        return RedirectToPage();
      }
      else
      {
        return Page();
      }
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
      await DoLogoutAsync();

      if (returnUrl != null)
      {
        return LocalRedirect(returnUrl);
      }
      else
      {
        return RedirectToPage();
      }
    }

    private async Task DoLogoutAsync()
    {
      await _signInManager.SignOutAsync();
      _logger.LogInformation("User logged out.");
    }
  }
}
