#pragma checksum "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\Shared\Product_Exists.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2d4f9c8bb6d4dd68d47d84f2341897ea6ec06ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Product_Exists), @"mvc.1.0.view", @"/Views/Shared/Product_Exists.cshtml")]
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
#line 1 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\_ViewImports.cshtml"
using MyResourcesApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\_ViewImports.cshtml"
using MyResourcesApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2d4f9c8bb6d4dd68d47d84f2341897ea6ec06ea", @"/Views/Shared/Product_Exists.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a2d5291f3ec8e5bd46baab07d99df654e7239b8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Product_Exists : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\Shared\Product_Exists.cshtml"
  
    ViewData["Title"] = "ID already Exists";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-danger\">Error.</h1>\r\n<h2 class=\"text-danger\">An error occurred while processing your request.</h2>\r\n<h3>Product Name = \"");
#nullable restore
#line 11 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\Shared\Product_Exists.cshtml"
               Write(ViewBag.productName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" is already exists, Try inserting different values and save.</h3>\r\n<div>\r\n    ");
#nullable restore
#line 13 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\Shared\Product_Exists.cshtml"
Write(Html.ActionLink("Ok", "EnterNewProduct", new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 14 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\Shared\Product_Exists.cshtml"
Write(Html.ActionLink("Cancel", "RegisterProduct", new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
