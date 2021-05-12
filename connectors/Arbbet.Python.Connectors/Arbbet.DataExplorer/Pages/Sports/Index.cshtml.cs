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

namespace Arbbet.DataExplorer.Pages.Sports
{
    [Authorize]
    [Breadcrumb("Sports", "/Sports/Index", Icon = "fas fa-basketball-ball", PageType = typeof(IndexModel), ParentType = null)]
    [PageNavigation("Sports", "/Sports/Index", Icon = "fas fa-basketball-ball", Order = 2, PageType = typeof(IndexModel), ParentType = typeof(DataNavigation))]
    public class IndexModel : PagedPageModel<SportDto>
    {
        private readonly SportService _sportService;
        public IndexModel(SportService sportService)
        {
            _sportService = sportService;
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

            Items = _sportService.Where(elm => elm.Code != null, SportService.WithAllProperties).OrderBy(elm => elm.Name).ToList();
            Count = Items.Count();
            Items = Items.TakePage(CurrentPage, PageSize);
        }
    }
}
