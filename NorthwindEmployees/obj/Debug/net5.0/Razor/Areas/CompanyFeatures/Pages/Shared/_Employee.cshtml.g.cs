#pragma checksum "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindEmployees\Areas\CompanyFeatures\Pages\Shared\_Employee.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db4889e75565c4ae64ca5cec920c0dc824b2762f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_CompanyFeatures_Pages_Shared__Employee), @"mvc.1.0.view", @"/Areas/CompanyFeatures/Pages/Shared/_Employee.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db4889e75565c4ae64ca5cec920c0dc824b2762f", @"/Areas/CompanyFeatures/Pages/Shared/_Employee.cshtml")]
    public class Areas_CompanyFeatures_Pages_Shared__Employee : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Company.Shared.Employee>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"card border-dark mb-3\" style=\"max-width: 18rem;\">\r\n    <div class=\"card-header\">");
#nullable restore
#line 4 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindEmployees\Areas\CompanyFeatures\Pages\Shared\_Employee.cshtml"
                        Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 4 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindEmployees\Areas\CompanyFeatures\Pages\Shared\_Employee.cshtml"
                                         Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    <div class=\"card-body text-dark\">\r\n        <h5 class=\"card-title\">");
#nullable restore
#line 6 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindEmployees\Areas\CompanyFeatures\Pages\Shared\_Employee.cshtml"
                          Write(Model.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <p class=\"card-text\">");
#nullable restore
#line 7 "C:\Users\BİLGE\Desktop\DEMO\PracticalApps\NorthwindEmployees\Areas\CompanyFeatures\Pages\Shared\_Employee.cshtml"
                        Write(Model.Notes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Company.Shared.Employee> Html { get; private set; }
    }
}
#pragma warning restore 1591
