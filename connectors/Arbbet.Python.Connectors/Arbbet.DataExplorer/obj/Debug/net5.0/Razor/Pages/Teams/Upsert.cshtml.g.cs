#pragma checksum "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0c259327db9512bae0b0bfaeed5ab5267727c55"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Teams_Upsert), @"mvc.1.0.razor-page", @"/Pages/Teams/Upsert.cshtml")]
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
#nullable restore
#line 5 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
using Arbbet.Domain.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{Id?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0c259327db9512bae0b0bfaeed5ab5267727c55", @"/Pages/Teams/Upsert.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f766e1c2600d6afdff6bd59ab622fa7d29c1273a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Teams_Upsert : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Breadcrumb", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("select2 form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-clearable", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Select a type"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
  
    ViewData["Title"] = Model.Meaning == PageMeaning.CREATE ? Localizer["PageTitle_Create"] : Localizer["PageTitle_Edit", Model.Item.Name];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c0c259327db9512bae0b0bfaeed5ab5267727c557501", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 11 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = this.Model.GetType();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"container-fluid px-xxl-65 px-xl-20\">\r\n    <!-- Title -->\r\n");
            WriteLiteral("    <!-- /Title -->\r\n    <!-- Row -->\r\n    <div class=\"row\">\r\n        <div class=\"col-xl-12\">\r\n            <section class=\"hk-sec-wrapper\">\r\n                <h5 class=\"hk-sec-title\">\r\n                    <i");
            BeginWriteAttribute("class", " class=\"", 1340, "\"", 1405, 1);
#nullable restore
#line 24 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
WriteAttributeValue("", 1348, SiteNavigationProvider.GetPageIcon(this.Model.GetType()), 1348, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                    ");
#nullable restore
#line 25 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
               Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </h5>\r\n                <div class=\"row\">\r\n                    <div class=\"col-sm\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0c259327db9512bae0b0bfaeed5ab5267727c5510339", async() => {
                WriteLiteral("\r\n                            <div class=\"row\">\r\n                                <div class=\"col\">\r\n                                    <div class=\"form-group\">\r\n                                        ");
#nullable restore
#line 33 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
                                   Write(Html.HiddenFor(model => model.Item.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        ");
#nullable restore
#line 34 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
                                   Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        ");
#nullable restore
#line 35 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
                                   Write(Html.LabelFor(model => model.Item.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        ");
#nullable restore
#line 36 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
                                   Write(Html.TextBoxFor(model => model.Item.Name, htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                                <div class=\"col\">\r\n                                    <div class=\"form-group\">\r\n                                        ");
#nullable restore
#line 41 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
                                   Write(Html.LabelFor(model => model.Item.TeamType));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0c259327db9512bae0b0bfaeed5ab5267727c5512867", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 42 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Item.TeamType);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 42 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Html.GetEnumSelectList<TeamType>();

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    </div>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col-sm"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0c259327db9512bae0b0bfaeed5ab5267727c5515451", async() => {
#nullable restore
#line 48 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
                                                                                                                                                           Write(Model.Meaning == PageMeaning.CREATE ? CommonLocalizer["Action.Create"]: CommonLocalizer["Action.Save"]);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 48 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Pages\Teams\Upsert.cshtml"
                                                                                         WriteLiteral(Model.Meaning == PageMeaning.CREATE ? "Create": "Edit");

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-page-handler", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </section>\r\n        </div>\r\n    </div>\r\n    <!-- /Row -->\r\n\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Arbbet.AspNet.Helper.Navigation.SiteNavigationProvider SiteNavigationProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CommonLocalizationService CommonLocalizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<Arbbet.DataExplorer.Pages.Teams.UpsertModel> Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Arbbet.DataExplorer.Pages.Teams.UpsertModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Arbbet.DataExplorer.Pages.Teams.UpsertModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Arbbet.DataExplorer.Pages.Teams.UpsertModel>)PageContext?.ViewData;
        public Arbbet.DataExplorer.Pages.Teams.UpsertModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
