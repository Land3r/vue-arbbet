#pragma checksum "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fcc54c226259255bca5ae1b12e99ccd0aadfde3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Countries_Index), @"mvc.1.0.razor-page", @"/Pages/Countries/Index.cshtml")]
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
#line 1 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\_ViewImports.cshtml"
using Arbbet.DataExplorer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\_ViewImports.cshtml"
using Arbbet.AspNet.Helper.Razor;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{CurrentPage?}/{OrderBy?}/{Order?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fcc54c226259255bca5ae1b12e99ccd0aadfde3", @"/Pages/Countries/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d257acf0acbd04937e3529849269d175d0486911", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Countries_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Upsert", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-gradient-success btn-wth-icon btn-rounded icon-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-capitalize"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Countries";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<nav class=""hk-breadcrumb"" aria-label=""breadcrumb"">
    <ol class=""breadcrumb breadcrumb-light bg-transparent"">
        <li class=""breadcrumb-item""><a href=""#"">Data</a></li>
        <li class=""breadcrumb-item active"" aria-current=""page"">Countries</li>
    </ol>
</nav>

<div class=""container-fluid px-xxl-65 px-xl-20"">
    <!-- Title -->
");
            WriteLiteral("    <!-- /Title -->\r\n    <!-- Row -->\r\n    <div class=\"row\">\r\n        <div class=\"col-xl-12\">\r\n            <section class=\"hk-sec-wrapper\">\r\n                <h5 class=\"hk-sec-title\">\r\n                    Countries\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3fcc54c226259255bca5ae1b12e99ccd0aadfde35274", async() => {
                WriteLiteral("\r\n                        <span class=\"btn-text\">Create</span> <span class=\"icon-label\"><i class=\"fa fa-plus-circle\"></i></span>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </h5>
                <div class=""row"">
                    <div class=""col-sm"">
                        <div class=""table-wrap mb-30"">
                            <div class=""table-responsive"">
                                <table class=""table table-hover table-striped mb-0"">
                                    <thead class=""thead-success"">
                                        <tr>
                                            <th>");
#nullable restore
#line 38 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml"
                                           Write(Html.DisplayNameFor(model => model.Items.FirstOrDefault().Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                            <th>");
#nullable restore
#line 39 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml"
                                           Write(Html.DisplayNameFor(model => model.Items.FirstOrDefault().Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                            <th>");
#nullable restore
#line 40 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml"
                                           Write(Html.DisplayNameFor(model => model.Items.FirstOrDefault().FlagName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                            <th>Actions</th>\r\n                                        </tr>\r\n                                    </thead>\r\n                                    <tbody>\r\n");
#nullable restore
#line 45 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml"
                                         foreach (var item in Model.Items)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3fcc54c226259255bca5ae1b12e99ccd0aadfde38916", async() => {
#nullable restore
#line 48 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml"
                                                                                                                    Write(item.Code);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 48 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml"
                                                                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                                <td><span class=\"text-capitalize\">");
#nullable restore
#line 49 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml"
                                                                             Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                                <td>\r\n");
#nullable restore
#line 51 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml"
                                                     if (!string.IsNullOrEmpty(item.FlagName))
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <i");
            BeginWriteAttribute("class", " class=\"", 3199, "\"", 3226, 2);
            WriteAttributeValue("", 3207, "flag", 3207, 4, true);
#nullable restore
#line 53 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml"
WriteAttributeValue(" ", 3211, item.FlagName, 3212, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n");
#nullable restore
#line 54 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <span class=\"text-danger\">-</span>\r\n");
#nullable restore
#line 58 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </td>\r\n                                                <td>TODO ?</td>\r\n                                            </tr>\r\n");
#nullable restore
#line 62 "D:\Dev_ng\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Countries\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>
                            <nav aria-label=""Page navigation example"">
                                <ul class=""pagination"">
                                    <li class=""page-item"">
                                        <a class=""page-link"" href=""#"" aria-label=""Previous"">
                                            <span aria-hidden=""true"">&laquo;</span>
                                            <span class=""sr-only"">Previous</span>
                                        </a>
                                    </li>
                                    <li class=""page-item""><a class=""page-link"" href=""#"">1</a></li>
                                    <li class=""page-item""><a class=""page-link"" href=""#"">2</a></li>
                                    <li class=""page-item""><a class=""page-link"" href=""#"">3</a></li>
                                    <li class=""page-item"">
");
            WriteLiteral(@"                                        <a class=""page-link"" href=""#"" aria-label=""Next"">
                                            <span aria-hidden=""true"">&raquo;</span>
                                            <span class=""sr-only"">Next</span>
                                        </a>
                                    </li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    <!-- /Row -->

</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Arbbet.DataExplorer.Pages.Countries.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Arbbet.DataExplorer.Pages.Countries.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Arbbet.DataExplorer.Pages.Countries.IndexModel>)PageContext?.ViewData;
        public Arbbet.DataExplorer.Pages.Countries.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
