#pragma checksum "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63942067e3ee561375d6ec5b203dfda2ad6643a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PlaceOrder_GenerateReport), @"mvc.1.0.view", @"/Views/PlaceOrder/GenerateReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63942067e3ee561375d6ec5b203dfda2ad6643a9", @"/Views/PlaceOrder/GenerateReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4c9dd16152a354abfea8fb21655e024dbc0b7ce", @"/Views/_ViewImports.cshtml")]
    public class Views_PlaceOrder_GenerateReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MyResourcesApp.Models.PlaceOrder>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
  
    ViewData["Title"] = "Reports";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div id=\"Grid\">\r\n    <h1>");
#nullable restore
#line 10 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <br />\r\n\r\n    <h3>Customer Wise Orders</h3>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 18 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
               Write(Html.DisplayNameFor(model => model.CID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 21 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
               Write(Html.DisplayNameFor(model => model.PriceAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 24 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
               Write(Html.DisplayNameFor(model => model.AdvanceBalance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 27 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
               Write(Html.DisplayNameFor(model => model.TransportAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 33 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
             foreach (var item in (ViewBag.CustomerOrderDetails as IEnumerable<PlaceOrder>))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        Nu. ");
#nullable restore
#line 41 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
                       Write(Html.DisplayFor(modelItem => item.PriceAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        Nu. ");
#nullable restore
#line 44 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
                       Write(Html.DisplayFor(modelItem => item.AdvanceBalance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        Nu. ");
#nullable restore
#line 47 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TransportAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 50 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n    <br />\r\n    <h3>Product Wise Orders</h3>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n\r\n                <th>\r\n                    ");
#nullable restore
#line 61 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
               Write(Html.DisplayNameFor(model => model.productName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 64 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
               Write(Html.DisplayNameFor(model => model.PriceAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 67 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
               Write(Html.DisplayNameFor(model => model.TransportAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n\r\n\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 75 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
             foreach (var item in (ViewBag.CustomerProductDetails as IEnumerable<PlaceOrder>))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 80 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
                   Write(Html.DisplayFor(modelItem => item.productName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        Nu. ");
#nullable restore
#line 83 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
                       Write(Html.DisplayFor(modelItem => item.PriceAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        Nu. ");
#nullable restore
#line 86 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TransportAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 89 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
#nullable restore
#line 93 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
 using (Html.BeginForm("Export", "PlaceOrder", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"hidden\" name=\"GridHtml\" />\r\n    <input type=\"submit\" id=\"btnSubmit\" value=\"Download To PDF\" class=\"btn btn-secondary\"/>\r\n");
#nullable restore
#line 97 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\GenerateReport.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "63942067e3ee561375d6ec5b203dfda2ad6643a911589", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    $(function () {\r\n        $(\"#btnSubmit\").click(function () {\r\n            $(\"input[name=\'GridHtml\']\").val($(\"#Grid\").html());\r\n        });\r\n    });\r\n    $(\'#btnSubmit\').css(\'background\', \'green\');\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MyResourcesApp.Models.PlaceOrder>> Html { get; private set; }
    }
}
#pragma warning restore 1591
