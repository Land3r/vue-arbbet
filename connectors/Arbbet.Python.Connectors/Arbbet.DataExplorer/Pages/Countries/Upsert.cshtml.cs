using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Arbbet.AspNet.Helper.Razor;
using Arbbet.Connectors.Dal.Services;
using Arbbet.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Arbbet.DataExplorer.Pages.Countries
{
    [AllowAnonymous]
    public class UpsertModel : UpsertPageModel<CountryDto>
    {
        private readonly CountryService _countryService;

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

            return Page();
        }
    }
}
