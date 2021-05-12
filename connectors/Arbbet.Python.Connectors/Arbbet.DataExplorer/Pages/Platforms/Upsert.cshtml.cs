using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Arbbet.AspNet.Helper.Breadcrumbs;
using Arbbet.AspNet.Helper.Core;
using Arbbet.AspNet.Helper.Razor;
using Arbbet.Connectors.Dal.Services;
using Arbbet.DataExplorer.Helpers;
using Arbbet.Domain.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arbbet.DataExplorer.Pages.Platforms
{
    [AllowAnonymous]
    [Breadcrumb("Edit platform", null, Icon = "fas fa-chalkboard-teacher", PageType = typeof(UpsertModel), ParentType = typeof(IndexModel))]
    public class UpsertModel : UpsertPageModel<PlatformDto>
    {
        private readonly PlatformService _platformService;

        public UpsertModel(PlatformService platformService)
        {
            _platformService = platformService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Meaning == PageMeaning.EDIT && Id.HasValue)
            {
                Item = await _platformService.Get(Id.Value);
            }

            LoadRelatedData();
            return Page();
        }

        public override async Task<IActionResult> OnPostCreateAsync()
        {
            if (ModelState.IsValid)
            {
                _platformService.Create(Item);
                await _platformService.CommitAsync();

                return RedirectToPage("./Index");
            }

            LoadRelatedData();
            return Page();
        }

        public override async Task<IActionResult> OnPostEditAsync()
        {
            if (ModelState.IsValid)
            {
                var entity = await _platformService.Get(Id.Value);

                if (entity == null)
                {
                    return NotFound("Country not found");
                }

                entity.Name = Item.Name;
                entity.Code = Item.Code;

                _platformService.Update(entity);
                await _platformService.CommitAsync();

                return RedirectToPage("./Index");
            }

            LoadRelatedData();
            return Page();
        }

        private void LoadRelatedData()
        {
        }
    }
}
