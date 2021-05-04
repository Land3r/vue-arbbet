using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.DataExplorer.Identity.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace Arbbet.DataExplorer.Areas.Identity.Pages.Account
{
  [AllowAnonymous]
  public class RegisterConfirmationModel : PageModel
  {
    private readonly UserManager<ArbbetUser> _userManager;
    private readonly IEmailSender _sender;

    public RegisterConfirmationModel(UserManager<ArbbetUser> userManager, IEmailSender sender)
    {
      _userManager = userManager;
      _sender = sender;
    }

    public string Email { get; set; }

    public bool DisplayConfirmAccountLink { get; set; }

    public string EmailConfirmationUrl { get; set; }

    public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
    {
      if (email == null)
      {
        return RedirectToPage("/Index");
      }

      var user = await _userManager.FindByEmailAsync(email);
      if (user == null)
      {
        return NotFound($"Unable to load user with email '{email}'.");
      }

      Email = email;

      return Page();
    }
  }
}