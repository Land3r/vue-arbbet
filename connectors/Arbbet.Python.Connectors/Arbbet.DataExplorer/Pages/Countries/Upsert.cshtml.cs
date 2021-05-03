using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Arbbet.AspNet.Helper.Razor;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Arbbet.DataExplorer.Pages.Countries
{
  public class UpsertModel : PageModel
  {
    public PageMeaning Meaning
    {
      get
      {
        return Id.HasValue ? PageMeaning.EDIT : PageMeaning.CREATE;
      }
    }

    [BindProperty(SupportsGet = true)]
    public Guid? Id { get; set; }

    public void OnGet()
    {
    }
  }
}
