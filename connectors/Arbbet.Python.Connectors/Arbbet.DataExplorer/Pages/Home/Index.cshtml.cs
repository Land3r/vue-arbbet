using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arbbet.AspNet.Helper.Breadcrumbs;
using Arbbet.AspNet.Helper.Navigation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Arbbet.DataExplorer.Pages.Home
{
    [Authorize]
    [Breadcrumb("Home", "/Home/Index/", Icon = "fas fa-home", PageType = typeof(IndexModel), ParentType = null)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
