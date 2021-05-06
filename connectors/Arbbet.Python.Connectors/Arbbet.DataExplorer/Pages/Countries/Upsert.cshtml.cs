using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Arbbet.AspNet.Helper.Core;
using Arbbet.AspNet.Helper.Razor;
using Arbbet.Connectors.Dal.Services;
using Arbbet.DataExplorer.Helpers;
using Arbbet.Domain.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arbbet.DataExplorer.Pages.Countries
{
    [AllowAnonymous]
    public class UpsertModel : UpsertPageModel<CountryDto>
    {
        private readonly CountryService _countryService;

        public IList<SelectListItem> FlagSelectList { get; set; }

        public UpsertModel(CountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Meaning == PageMeaning.EDIT && Id.HasValue)
            {
                Item = await _countryService.Get(Id.Value);
            }

            LoadRelatedData();
            return Page();
        }

        public override async Task<IActionResult> OnPostCreateAsync()
        {
            if (ModelState.IsValid)
            {
                _countryService.Create(Item);
                await _countryService.CommitAsync();

                return RedirectToPage("./Index");
            }

            LoadRelatedData();
            return Page();
        }

        public override async Task<IActionResult> OnPostEditAsync()
        {
            if (ModelState.IsValid)
            {
                var entity = await _countryService.Get(Id.Value);

                if (entity == null)
                {
                    return NotFound("Country not found");
                }

                entity.Code = Item.Code;
                entity.Name = Item.Name;
                entity.FlagName = Item.FlagName;

                _countryService.Update(entity);
                await _countryService.CommitAsync();

                return RedirectToPage("./Index");
            }

            LoadRelatedData();
            return Page();
        }

        private void LoadRelatedData()
        {
            LoadAvailableFlagsAsync();
        }

        private void LoadAvailableFlagsAsync()
        {
            FlagSelectList = AvailableFlags.Collection.ToSelectListItem(elm => elm.Replace(".", string.Empty).ToLowerInvariant(), elm => elm.ToString()).ToList();
        }
    }
}
