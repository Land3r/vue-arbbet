#pragma checksum "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Areas\Identity\Pages\Shared\_AlertMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92d190ea23fef50ba57903910d8a742bb87f9fb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Shared__AlertMessage), @"mvc.1.0.view", @"/Areas/Identity/Pages/Shared/_AlertMessage.cshtml")]
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
#line 1 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Areas\Identity\Pages\_ViewImports.cshtml"
using Arbbet.DataExplorer.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Areas\Identity\Pages\_ViewImports.cshtml"
using Arbbet.DataExplorer.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Areas\Identity\Pages\_ViewImports.cshtml"
using Arbbet.DataExplorer.Identity.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92d190ea23fef50ba57903910d8a742bb87f9fb3", @"/Areas/Identity/Pages/Shared/_AlertMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86941658c9724d50438838c38025aa5ad7972950", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Shared__AlertMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Areas\Identity\Pages\Shared\_AlertMessage.cshtml"
 if (!String.IsNullOrEmpty(Model))
{
    var statusMessageClass = Model.StartsWith("Error") ? "danger" : "success";
    var icon = statusMessageClass == "danger" ? "zmdi-alert-circle-o" : "zmdi-check-circle";

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div");
            BeginWriteAttribute("class", " class=\"", 238, "\"", 320, 7);
            WriteAttributeValue("", 246, "alert", 246, 5, true);
            WriteAttributeValue(" ", 251, "alert-", 252, 7, true);
#nullable restore
#line 7 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Areas\Identity\Pages\Shared\_AlertMessage.cshtml"
WriteAttributeValue("", 258, statusMessageClass, 258, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 277, "alert-wth-icon", 278, 15, true);
            WriteAttributeValue(" ", 292, "alert-dismissible", 293, 18, true);
            WriteAttributeValue(" ", 310, "fade", 311, 5, true);
            WriteAttributeValue(" ", 315, "show", 316, 5, true);
            EndWriteAttribute();
            WriteLiteral(" role=\"alert\">\r\n        <span class=\"alert-icon-wrap\"><i");
            BeginWriteAttribute("class", " class=\"", 377, "\"", 395, 2);
            WriteAttributeValue("", 385, "zmdi", 385, 4, true);
#nullable restore
#line 8 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Areas\Identity\Pages\Shared\_AlertMessage.cshtml"
WriteAttributeValue(" ", 389, icon, 390, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i></span>");
#nullable restore
#line 8 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Areas\Identity\Pages\Shared\_AlertMessage.cshtml"
                                                                  Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n            <span aria-hidden=\"true\">×</span>\r\n        </button>\r\n    </div>\r\n");
#nullable restore
#line 13 "D:\Dev_Services_Prives\vue-arbbet\connectors\Arbbet.Python.Connectors\Arbbet.DataExplorer\Areas\Identity\Pages\Shared\_AlertMessage.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
