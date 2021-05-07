using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Arbbet.AspNet.Helper.Breadcrumbs;
using Arbbet.AspNet.Helper.Razor;
using Arbbet.Connectors.Dal.Services;
using Arbbet.Domain.Entities;
using Arbbet.Domain.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Arbbet.DataExplorer.Pages.Countries
{
  [Authorize]
  [Breadcrumb("Countries", "/Coutries/Index/", Icon = "fas fa-flag", PageType = typeof(IndexModel), ParentType = null)]
  public class IndexModel : PagedPageModel<CountryDto>
  {
    private readonly CountryService _countryService;
    public IndexModel(CountryService countryService)
    {
      _countryService = countryService;
    }

    public async Task<IActionResult> OnGetAsync()
    {
      await LoadData();

      return Page();
    }

    private async Task LoadData()
    {
      OrderBy ??= "Name";
      Order ??= "Asc";

      var test = _countryService.Where(elm => true).OrderBy(elm => EF.Property<object>(elm, OrderBy));
      Items = _countryService.Where(elm => true).OrderBy(elm => elm.Name).ToList();
      Count = Items.Count();
      Items = Items.TakePage(CurrentPage, PageSize);
    }
  }
}
