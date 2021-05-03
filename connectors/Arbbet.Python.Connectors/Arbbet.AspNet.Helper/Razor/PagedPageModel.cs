using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Arbbet.AspNet.Helper.Razor
{
  public class PagedPageModel<TViewModel> : PageModel
  {
    [BindProperty(SupportsGet = true)]
    public virtual int CurrentPage { get; set; } = 1;

    public virtual int Count { get; set; }

    public virtual int PageSize { get; set; } = 25;

    public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

    public virtual IList<TViewModel> Items { get; set; }

    [BindProperty(SupportsGet = true)]
    public virtual string OrderBy { get; set; }

    [BindProperty(SupportsGet = true)]
    public virtual string Order { get; set; } = "Asc";
  }
}
