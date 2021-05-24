#pragma checksum "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35e271438c47d3d66ad9df9d49a5e462fee61480"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cms_Page), @"mvc.1.0.view", @"/Views/Cms/Page.cshtml")]
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
#line 1 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\_ViewImports.cshtml"
using Piranha.AspNetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\_ViewImports.cshtml"
using NorthwindCms.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35e271438c47d3d66ad9df9d49a5e462fee61480", @"/Views/Cms/Page.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6678a70b82dc05f14c5ff659ec3564cb98c831e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Cms_Page : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StandardPage>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
  
    ViewData["Title"] = !string.IsNullOrEmpty(Model.MetaTitle) ? Model.MetaTitle : Model.Title;
    var hasImage = Model.PrimaryImage.HasValue;

#line default
#line hidden
#nullable disable
            DefineSection("head", async() => {
                WriteLiteral("\n    ");
#nullable restore
#line 7 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
Write(WebApp.MetaTags(Model));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
            }
            );
            WriteLiteral("\n<header ");
#nullable restore
#line 10 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
    Write(hasImage ? "class=has-image" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 10 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
                                         Write(hasImage ? $"style=background-image:url({ @Url.Content(WebApp.Media.ResizeImage(Model.PrimaryImage, 1920, 400)) })" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral(">\n    <div class=\"dimmer\"></div>\n    <div class=\"container text-center\">\n        <h1>");
#nullable restore
#line 13 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n");
#nullable restore
#line 14 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
         if (!string.IsNullOrWhiteSpace(Model.Excerpt))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row justify-content-center\">\n                <div class=\"col-lg-8 lead\">\n                    ");
#nullable restore
#line 18 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
               Write(Html.Raw(Model.Excerpt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n            </div>\n");
#nullable restore
#line 21 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n</header>\n\n<main>\n");
#nullable restore
#line 26 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
     foreach (var block in Model.Blocks)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div");
            BeginWriteAttribute("class", " class=\"", 835, "\"", 865, 2);
            WriteAttributeValue("", 843, "block", 843, 5, true);
#nullable restore
#line 28 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
WriteAttributeValue(" ", 848, block.CssName(), 849, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n            <div class=\"container\">\n                ");
#nullable restore
#line 30 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
           Write(Html.DisplayFor(m => block, block.GetType().Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n");
#nullable restore
#line 33 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindCms\Views\Cms\Page.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</main>\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Authorization.IAuthorizationService Auth { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Piranha.AspNetCore.Services.IApplicationService WebApp { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StandardPage> Html { get; private set; }
    }
}
#pragma warning restore 1591
