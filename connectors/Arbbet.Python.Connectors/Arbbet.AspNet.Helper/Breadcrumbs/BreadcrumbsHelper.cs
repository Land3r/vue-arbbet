﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Arbbet.AspNet.Helper.Breadcrumbs;
using Arbbet.AspNet.Helper.Reflexion;

namespace Arbbet.AspNet.Helper.Breadcrumbs
{
  public class BreadcrumbsHelper
  {
    // Register all breadcrumbs
    // Note that this process requires reflexion and should be done once, then saved and use the results already queried.
    public static IList<IBreadcrumbDefinition> GetBreadcrumbsForAssembly(Assembly assembly)
    {
      IEnumerable<Type> pages = ReflexionHelper.GetTypesWithAttribute(assembly, typeof(BreadcrumbAttribute));

      IList<IBreadcrumbDefinition> siteDefinition = new List<IBreadcrumbDefinition>();

      foreach (Type pageType in pages)
      {
        BreadcrumbAttribute breadcrumbAttribute = pageType.GetCustomAttribute<BreadcrumbAttribute>(false);
        if (breadcrumbAttribute != null)
        {
          siteDefinition.Add(new BreadcrumbDefinition()
          {
            Name = breadcrumbAttribute.Name,
            Icon = breadcrumbAttribute.Icon,
            PageUrl = breadcrumbAttribute.PageUrl,
            PageType = breadcrumbAttribute.PageType,
            ParentType = breadcrumbAttribute.ParentType
          });
        }
      }

      return siteDefinition;
    }
  }
}
