#pragma checksum "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\Shared\ForeignKeyConstriant.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f37b6cf2bab8d1e287382d9501a8c110fcc3cc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ForeignKeyConstriant), @"mvc.1.0.view", @"/Views/Shared/ForeignKeyConstriant.cshtml")]
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
#nullable restore
#line 3 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f37b6cf2bab8d1e287382d9501a8c110fcc3cc6", @"/Views/Shared/ForeignKeyConstriant.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4c9dd16152a354abfea8fb21655e024dbc0b7ce", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ForeignKeyConstriant : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\Shared\ForeignKeyConstriant.cshtml"
  
    ViewData["Title"] = "Foreign Key Constriants";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-danger\">Error.</h1>\r\n<h2 class=\"text-danger\">An error occurred while processing your request.</h2>\r\n<h3>Customer ID = \"");
#nullable restore
#line 11 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\Shared\ForeignKeyConstriant.cshtml"
              Write(ViewBag.CustomerID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" has relationship with, ");
#nullable restore
#line 11 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\Shared\ForeignKeyConstriant.cshtml"
                                                          Write(ViewBag.ScreenName);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</h3>\r\n<h4>Try Deleting information from ");
#nullable restore
#line 12 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\Shared\ForeignKeyConstriant.cshtml"
                             Write(ViewBag.ScreenName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" screens.</h4> \r\n<div>\r\n    ");
#nullable restore
#line 14 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\Shared\ForeignKeyConstriant.cshtml"
Write(Html.ActionLink("Ok", "RegisterCustomer", new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n");
            WriteLiteral("</div>\r\n");
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
