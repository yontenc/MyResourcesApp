#pragma checksum "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8194695e877fade8f8851c9da79f1e75a9d3d431"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PlaceOrder_OrderDetails), @"mvc.1.0.view", @"/Views/PlaceOrder/OrderDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8194695e877fade8f8851c9da79f1e75a9d3d431", @"/Views/PlaceOrder/OrderDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a2d5291f3ec8e5bd46baab07d99df654e7239b8", @"/Views/_ViewImports.cshtml")]
    public class Views_PlaceOrder_OrderDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MyResourcesApp.Models.PlaceOrder>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary my-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewPlaceOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
  
    ViewData["Title"] = "Order Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8194695e877fade8f8851c9da79f1e75a9d3d4314685", async() => {
                WriteLiteral("<i class=\"fas fa-plus mr-1\"></i>Add New Order");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table table-hover\" id=\"dataTable\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.OrderID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.CID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.productName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.SiteID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n");
            WriteLiteral("            <th>\r\n                ");
#nullable restore
#line 41 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.OrderStatusID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 47 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.OrderID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.CID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 56 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.productName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 59 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.SiteID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 62 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n");
            WriteLiteral("            <td>\r\n                ");
#nullable restore
#line 74 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.OrderStatusID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 77 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.ActionLink("Edit Order", "EditCustomerInfo", new { cid = item.CID }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 78 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
           Write(Html.ActionLink("Generate Report", "GenerateReport", new { cid = item.CID, productName = item.productName }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                <input type=\"submit\" value=\"Cancel Order\" class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2705, "\"", 2797, 14);
            WriteAttributeValue("", 2715, "return", 2715, 6, true);
            WriteAttributeValue(" ", 2721, "confirm(\'Are", 2722, 13, true);
            WriteAttributeValue(" ", 2734, "you", 2735, 4, true);
            WriteAttributeValue(" ", 2738, "sure", 2739, 5, true);
            WriteAttributeValue(" ", 2743, "you", 2744, 4, true);
            WriteAttributeValue(" ", 2747, "wanted", 2748, 7, true);
            WriteAttributeValue(" ", 2754, "to", 2755, 3, true);
            WriteAttributeValue(" ", 2757, "delete", 2758, 7, true);
            WriteAttributeValue(" ", 2764, "site", 2765, 5, true);
            WriteAttributeValue(" ", 2769, "recode", 2770, 7, true);
            WriteAttributeValue(" ", 2776, "with", 2777, 5, true);
            WriteAttributeValue(" ", 2781, "ID=", 2782, 4, true);
#nullable restore
#line 79 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
WriteAttributeValue(" ", 2785, item.CID, 2786, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2795, "\')", 2795, 2, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 82 "C:\Users\USER\Desktop\c# Programming\MyResourcesApp\Views\PlaceOrder\OrderDetails.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
