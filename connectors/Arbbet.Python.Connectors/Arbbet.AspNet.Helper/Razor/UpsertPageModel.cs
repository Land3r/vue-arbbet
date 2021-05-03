using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbbet.AspNet.Helper.Razor
{
    /// <summary>
    /// A Razor page model for pages with upsert (update / insert) capabilities.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model being manipulated.</typeparam>
    public class UpsertPageModel<TViewModel> : PageModel
    {
        /// <summary>
        /// Gets the page meaning.
        /// Allow to determine if the page is in Creation or Edit mode.
        /// </summary>
        public PageMeaning Meaning
        {
            get
            {
                return Id.HasValue ? PageMeaning.EDIT : PageMeaning.CREATE;
            }
        }

        /// <summary>
        /// Gets or sets the Id of the <see cref="TViewModel"/> being manipulated.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TViewModel"/> to create or edit.
        /// </summary>
        [BindProperty]
        public TViewModel Item { get; set; }

        /// <summary>
        /// Receiver for creation route.
        /// </summary>
        /// <returns></returns>
        public virtual Task<IActionResult> OnPostCreateAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Receiver for edit route.
        /// </summary>
        /// <returns></returns>
        public virtual Task<IActionResult> OnPostEditAsync()
        {
            throw new NotImplementedException();
        }
    }
}
