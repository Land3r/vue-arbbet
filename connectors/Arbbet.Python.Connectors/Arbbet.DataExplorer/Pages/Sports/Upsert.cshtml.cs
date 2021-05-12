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

namespace Arbbet.DataExplorer.Pages.Sports
{
    [AllowAnonymous]
    [Breadcrumb("Edit sport", "/Sports/Index/", Icon = "fas fa-basketball-ball", PageType = typeof(UpsertModel), ParentType = typeof(IndexModel))]
    public class UpsertModel : UpsertPageModel<SportDto>
    {
        private readonly SportService _sportService;

        public UpsertModel(SportService sportService)
        {
            _sportService = sportService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Meaning == PageMeaning.EDIT && Id.HasValue)
            {
                Item = await _sportService.Get(Id.Value);
            }

            LoadRelatedData();
            return Page();
        }

        public override async Task<IActionResult> OnPostCreateAsync()
        {
            if (ModelState.IsValid)
            {
                _sportService.Create(Item);
                await _sportService.CommitAsync();

                return RedirectToPage("./Index");
            }

            LoadRelatedData();
            return Page();
        }

        public override async Task<IActionResult> OnPostEditAsync()
        {
            if (ModelState.IsValid)
            {
                var entity = await _sportService.Get(Id.Value);

                if (entity == null)
                {
                    return NotFound("Country not found");
                }

                entity.Name = Item.Name;
                entity.Code = Item.Code;

                _sportService.Update(entity);
                await _sportService.CommitAsync();

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
