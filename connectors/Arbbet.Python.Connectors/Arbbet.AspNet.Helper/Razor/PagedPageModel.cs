using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Arbbet.AspNet.Helper.Razor
{
    /// <summary>
    /// A Razor page model for pages with paginations of items.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model being manipulated.</typeparam>
    public class PagedPageModel<TViewModel> : PageModel
    {
        /// <summary>
        /// Gets or set the current page of the pagination.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public virtual int CurrentPage { get; set; } = 1;

        /// <summary>
        /// Gets or sets the total number of items
        /// </summary>
        public virtual int Count { get; set; }

        /// <summary>
        /// Gets or sets the page size for the pagination.
        /// </summary>
        public virtual int PageSize { get; set; } = 25;

        /// <summary>
        /// Deduct the total number of pages, based on the total number of items and the page size.
        /// </summary>
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        /// <summary>
        /// Gets or sets the list of items of type <see cref="TViewModel"/>.
        /// </summary>
        public virtual IList<TViewModel> Items { get; set; }

        /// <summary>
        /// Gets or sets the field on which an order should happend.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public virtual string OrderBy { get; set; }

        /// <summary>
        /// Gets or sets whether the Order gets applied ascendent or descendant.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public virtual string Order { get; set; } = "Asc";
    }

  public static class PagedPageModelExtensions
  {
    public static IEnumerable<TEntity> TakePage<TEntity>(this IEnumerable<TEntity> collection, int pageNumber, int pageSize)
    {
      return collection.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }

    public static IList<TEntity> TakePage<TEntity>(this IList<TEntity> collection, int pageNumber, int pageSize)
    {
      return collection.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }
  }
}
