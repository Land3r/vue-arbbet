#pragma checksum "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Shared\_RightPanel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "299d311923eed13eac3bf4a72adde65ce41f9edd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Shared__RightPanel), @"mvc.1.0.view", @"/Pages/Shared/_RightPanel.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\_ViewImports.cshtml"
using Arbbet.DataExplorer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\_ViewImports.cshtml"
using Arbbet.AspNet.Helper.Razor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\_ViewImports.cshtml"
using Arbbet.DataExplorer.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\_ViewImports.cshtml"
using Arbbet.DataExplorer.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"299d311923eed13eac3bf4a72adde65ce41f9edd", @"/Pages/Shared/_RightPanel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f766e1c2600d6afdff6bd59ab622fa7d29c1273a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__RightPanel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"        <!-- Setting Panel -->
<div class=""hk-settings-panel"">
    <div class=""nicescroll-bar position-relative"">
        <div class=""settings-panel-wrap"">
            <div class=""settings-panel-head"">
                <img class=""brand-img d-inline-block align-top""");
            BeginWriteAttribute("src", " src=\"", 270, "\"", 326, 1);
#nullable restore
#line 6 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Shared\_RightPanel.cshtml"
WriteAttributeValue("", 276, Url.Content("~/img/logos/arbbet_logo_header.png"), 276, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" alt=""brand"" />
                <a href=""javascript:void(0);"" id=""settings_panel_close"" class=""settings-panel-close""><span class=""feather-icon""><i data-feather=""x""></i></span></a>
            </div>

            <hr>
            <h6 class=""mb-5"">Navigation</h6>
            <p class=""font-14"">Menu comes in two modes: dark & light</p>
            <div class=""button-list hk-nav-select mb-10"">
                <button type=""button"" id=""nav_light_select"" class=""btn btn-outline-success btn-sm btn-wth-icon icon-wthot-bg""><span class=""icon-label""><i class=""fa fa-sun-o""></i> </span><span class=""btn-text"">Light Mode</span></button>
                <button type=""button"" id=""nav_dark_select"" class=""btn btn-outline-light btn-sm btn-wth-icon icon-wthot-bg""><span class=""icon-label""><i class=""fa fa-moon-o""></i> </span><span class=""btn-text"">Dark Mode</span></button>
            </div>
            <hr>
            <h6 class=""mb-5"">Top Nav</h6>
            <p class=""font-14"">Choose your liked color mode</p>
      ");
            WriteLiteral(@"      <div class=""button-list hk-navbar-select mb-10"">
                <button type=""button"" id=""navtop_light_select"" class=""btn btn-outline-light btn-sm btn-wth-icon icon-wthot-bg""><span class=""icon-label""><i class=""fa fa-sun-o""></i> </span><span class=""btn-text"">Light Mode</span></button>
                <button type=""button"" id=""navtop_dark_select"" class=""btn btn-outline-success btn-sm btn-wth-icon icon-wthot-bg""><span class=""icon-label""><i class=""fa fa-moon-o""></i> </span><span class=""btn-text"">Dark Mode</span></button>
            </div>
            <hr>
            <div class=""d-flex justify-content-between align-items-center"">
                <h6>Scrollable Header</h6>
                <div class=""toggle toggle-sm toggle-simple toggle-light toggle-bg-success scroll-nav-switch""></div>
            </div>
            <button id=""reset_settings"" class=""btn btn-success btn-block btn-reset mt-30"">Reset</button>
        </div>
    </div>
");
            WriteLiteral("</div>\r\n<!-- /Setting Panel -->");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
