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

namespace Arbbet.DataExplorer.Pages.Teams
{
    [Authorize]
    [Breadcrumb("Teams", "/Teams/Index", Icon = "fas fa-users", PageType = typeof(IndexModel), ParentType = null)]
    [PageNavigation("Teams", "/Teams/Index", Icon = "fas fa-users", Order = 2, PageType = typeof(IndexModel), ParentType = typeof(DataNavigation))]
    public class IndexModel : PagedPageModel<TeamDto>
    {
        private readonly TeamService _teamService;
        public IndexModel(TeamService teamService)
        {
            _teamService = teamService;
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

            Items = _teamService.Where(elm => true).OrderBy(elm => elm.Name).ToList();
            Count = Items.Count();
            Items = Items.TakePage(CurrentPage, PageSize);
        }
    }
}
