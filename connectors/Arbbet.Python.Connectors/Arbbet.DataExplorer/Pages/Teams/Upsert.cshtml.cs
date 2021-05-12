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

namespace Arbbet.DataExplorer.Pages.Teams
{
  [AllowAnonymous]
  [Breadcrumb("Edit team", "/Teams/Index/", Icon = "fas fa-users", PageType = typeof(UpsertModel), ParentType = typeof(IndexModel))]
  public class UpsertModel : UpsertPageModel<TeamDto>
  {
    private readonly TeamService _teamService;

    public IList<SelectListItem> FlagSelectList { get; set; }

    public UpsertModel(TeamService teamService)
    {
      _teamService = teamService;
    }

    public async Task<IActionResult> OnGetAsync()
    {
      if (Meaning == PageMeaning.EDIT && Id.HasValue)
      {
        Item = await _teamService.Get(Id.Value);
      }

      LoadRelatedData();
      return Page();
    }

    public override async Task<IActionResult> OnPostCreateAsync()
    {
      if (ModelState.IsValid)
      {
        _teamService.Create(Item);
        await _teamService.CommitAsync();

        return RedirectToPage("./Index");
      }

      LoadRelatedData();
      return Page();
    }

    public override async Task<IActionResult> OnPostEditAsync()
    {
      if (ModelState.IsValid)
      {
        var entity = await _teamService.Get(Id.Value);

        if (entity == null)
        {
          return NotFound("Country not found");
        }

        entity.Name = Item.Name;
        entity.TeamType = Item.TeamType;

        _teamService.Update(entity);
        await _teamService.CommitAsync();

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
