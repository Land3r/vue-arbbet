using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arbbet.AspNet.Helper.MVC
{
  public static class SelectListHelper
  {
    public static IEnumerable<SelectListItem> ToSelectListItem<TEntity>(this IEnumerable<TEntity> collection, Func<TEntity, string> valueGetter, Func<TEntity, string> labelGetter)
    {
      return collection.Select(elm => new SelectListItem(labelGetter(elm), valueGetter(elm)));
    }

    public static IEnumerable<SelectListItem> ToSelectListItem<TEntity>(this IEnumerable<TEntity> collection, Func<TEntity, string> valueGetter, Func<TEntity, string> labelGetter, Func<TEntity, bool> selectedGetter)
    {
      return collection.Select(elm => new SelectListItem(labelGetter(elm), valueGetter(elm), selectedGetter(elm)));
    }

    public static IEnumerable<SelectListItem> ToSelectListItem<TEntity>(this IEnumerable<TEntity> collection, Func<TEntity, string> valueGetter, Func<TEntity, string> labelGetter, string selectedValue)
    {
      return collection.Select(elm => new SelectListItem(labelGetter(elm), valueGetter(elm), valueGetter(elm) == selectedValue));
    }

    public static IEnumerable<SelectListItem> ToSelectListItem<TEntity>(this IEnumerable<TEntity> collection, Func<TEntity, string> valueGetter, Func<TEntity, string> labelGetter, Func<TEntity, bool> selectedGetter, Func<TEntity, bool> disabledGetter)
    {
      return collection.Select(elm => new SelectListItem(labelGetter(elm), valueGetter(elm), selectedGetter(elm), disabledGetter(elm)));
    }

    public static IEnumerable<SelectListItem> ToSelectListItem<TEntity>(this IEnumerable<TEntity> collection, Func<TEntity, string> valueGetter, Func<TEntity, string> labelGetter, string selectedValue, Func<TEntity, bool> disabledGetter)
    {
      return collection.Select(elm => new SelectListItem(labelGetter(elm), valueGetter(elm), valueGetter(elm) == selectedValue, disabledGetter(elm)));
    }
  }
}
