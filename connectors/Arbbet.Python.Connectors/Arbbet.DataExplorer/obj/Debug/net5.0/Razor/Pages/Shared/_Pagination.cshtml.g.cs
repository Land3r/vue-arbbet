#pragma checksum "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Shared\_Pagination.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27283e37c29628bfd3ef45309408607d41998b48"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Shared__Pagination), @"mvc.1.0.view", @"/Pages/Shared/_Pagination.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27283e37c29628bfd3ef45309408607d41998b48", @"/Pages/Shared/_Pagination.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f766e1c2600d6afdff6bd59ab622fa7d29c1273a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__Pagination : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-CurrentPage", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Shared\_Pagination.cshtml"
  
    var maxPagesDisplay = 15;
    int startAt = Math.Max(1, Model.CurrentPage - (maxPagesDisplay / 2));
    int endAt = Math.Min(Model.TotalPages, Model.CurrentPage + (maxPagesDisplay / 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<ul class=\"pagination\">\r\n");
#nullable restore
#line 8 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Shared\_Pagination.cshtml"
     if (Model.TotalPages > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27283e37c29628bfd3ef45309408607d41998b485335", async() => {
                WriteLiteral("First");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-CurrentPage", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["CurrentPage"] = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </li>\r\n");
#nullable restore
#line 13 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Shared\_Pagination.cshtml"

        for (int i = startAt; i <= endAt; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li");
            BeginWriteAttribute("class", " class=\"", 460, "\"", 519, 2);
            WriteAttributeValue("", 468, "page-item", 468, 9, true);
#nullable restore
#line 16 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Shared\_Pagination.cshtml"
WriteAttributeValue(" ", 477, i == Model.CurrentPage ? "active" : "", 478, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27283e37c29628bfd3ef45309408607d41998b487747", async() => {
#nullable restore
#line 17 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Shared\_Pagination.cshtml"
                                                           Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-CurrentPage", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Shared\_Pagination.cshtml"
                                                WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["CurrentPage"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-CurrentPage", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["CurrentPage"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </li>\r\n");
#nullable restore
#line 19 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Shared\_Pagination.cshtml"
        }

        if (Model.TotalPages > 1)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27283e37c29628bfd3ef45309408607d41998b4810460", async() => {
                WriteLiteral("Last");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-CurrentPage", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Shared\_Pagination.cshtml"
                                                WriteLiteral(Model.TotalPages);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["CurrentPage"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-CurrentPage", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["CurrentPage"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </li>\r\n");
#nullable restore
#line 26 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Shared\_Pagination.cshtml"
        }
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item\">\r\n            <a class=\"page-link disabled\" href=\"#\">No pages</a>\r\n        </li>\r\n");
#nullable restore
#line 33 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Shared\_Pagination.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
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
