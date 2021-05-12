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

namespace Arbbet.DataExplorer.Pages.Platforms
{
    [Authorize]
    [Breadcrumb("Platforms", "/Platforms/Index", Icon = "fas fa-chalkboard-teacher", PageType = typeof(IndexModel), ParentType = null)]
    [PageNavigation("Platforms", "/Platforms/Index", Icon = "fas fa-chalkboard-teacher", Order = 1, PageType = typeof(IndexModel), ParentType = typeof(DataNavigation))]
    public class IndexModel : PagedPageModel<PlatformDto>
    {
        private readonly PlatformService _platformService;
        public IndexModel(PlatformService platformService)
        {
            _platformService = platformService;
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

            Items = _platformService.Where(elm => true).OrderBy(elm => elm.Name).ToList();
            Count = Items.Count();
            Items = Items.TakePage(CurrentPage, PageSize);
        }
    }
}
