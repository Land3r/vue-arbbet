using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Arbbet.AspNet.Helper.Breadcrumbs;
using Arbbet.AspNet.Helper.Navigation;
using Arbbet.AspNet.Helper.Razor;
using Arbbet.Connectors.Dal.Services;
using Arbbet.DataExplorer.Data.Navigation;
using Arbbet.Domain.Entities;
using Arbbet.Domain.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Arbbet.DataExplorer.Pages.Countries
{
    [Authorize]
    [Breadcrumb("Countries", "/Countries/Index/", Icon = "fas fa-flag", PageType = typeof(IndexModel), ParentType = null)]
    [PageNavigation("Countries", "/Countries/Index", Icon = "fas fa-flag", Order = 1, PageType = typeof(IndexModel), ParentType = typeof(DataNavigation))]
    public class IndexModel : PagedPageModel<CountryDto>
    {
        private readonly CountryService _countryService;
        public IndexModel(CountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult OnGet()
        {
            LoadData();

            return Page();
        }

        private void LoadData()
        {
            OrderBy ??= "Name";
            Order ??= "Asc";

            Items = _countryService.Where(elm => true).OrderBy(elm => elm.Name).ToList();
            Count = Items.Count();
            Items = Items.TakePage(CurrentPage, PageSize);
        }
    }
}
