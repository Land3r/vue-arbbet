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
    private readonly PlatformService _platformService;

    public IEnumerable<SelectListItem> PlatformSelectList { get; set; }

    public IEnumerable<SportDto> UnifiedItems { get; set; }

    public IEnumerable<SelectListItem> UnifiedEntitiesSelectList { get; set; }

    public UpsertModel(SportService sportService,
      PlatformService platformService)
    {
      _sportService = sportService;
      _platformService = platformService;
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
        entity.UnifiedType = Item.UnifiedType;
        entity.PlatformId = Item.PlatformId;

        if (entity.UnifiedType == Domain.Enums.UnifiedType.Platform)
        {
          entity.UnifiedEntityId = Item.UnifiedEntityId;
        }

        _sportService.Update(entity);
        await _sportService.CommitAsync();
      }

      LoadRelatedData();
      return Page();
    }

    private void LoadRelatedData()
    {
      LoadPlatformSelectList();
      LoadUnifiedItems();
      LoadUnifiedItemsSelectList();
    }

    private void LoadPlatformSelectList()
    {
      PlatformSelectList = _platformService.Where(elm => true).ToSelectListItem(elm => elm.Id.ToString(), elm => elm.Name);
    }

    private void LoadUnifiedItems()
    {
      if (Item?.UnifiedType == Domain.Enums.UnifiedType.Platform && Item.UnifiedEntityId != null)
      {
        UnifiedItems = _sportService.Where(elm => elm.Id == Item.UnifiedEntityId.Value, SportService.WithPlatform);
      }
      else if (Item?.UnifiedType == Domain.Enums.UnifiedType.Master)
      {
        UnifiedItems = _sportService.Where(elm => elm.UnifiedEntityId == Item.Id, SportService.WithPlatform);
      }
      else
      {
        UnifiedItems = new List<SportDto>();
      }
    }

    private void LoadUnifiedItemsSelectList()
    {
      if (Item?.UnifiedType == Domain.Enums.UnifiedType.Platform)
      {
        UnifiedEntitiesSelectList = _sportService.Where(elm => elm.UnifiedType == Domain.Enums.UnifiedType.Master).ToSelectListItem(elm => elm.Id.ToString(), elm => elm.Name);
      }
      else if (Item?.UnifiedType == Domain.Enums.UnifiedType.Master)
      {
        UnifiedEntitiesSelectList = _sportService.Where(elm => elm.UnifiedType == Domain.Enums.UnifiedType.Platform).ToSelectListItem(elm => elm.Id.ToString(), elm => elm.Name);
      }
      else
      {
        UnifiedEntitiesSelectList = new List<SelectListItem>();
      }
    }
  }
}
