#pragma checksum "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\PurchaseHistory\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eabfbcee3e9589de33bfde033998ee4945eeb09b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PurchaseHistory_Index), @"mvc.1.0.view", @"/Views/PurchaseHistory/Index.cshtml")]
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
#line 1 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\_ViewImports.cshtml"
using TransportCompany;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\_ViewImports.cshtml"
using TransportCompany.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eabfbcee3e9589de33bfde033998ee4945eeb09b", @"/Views/PurchaseHistory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90ce0c65725a5f7a18e8cf6f3ab1677c378fb47f", @"/Views/_ViewImports.cshtml")]
    public class Views_PurchaseHistory_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PurchaseHistoryModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\PurchaseHistory\Index.cshtml"
  
    ViewData["Title"] = "PuchaseHistory";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""table"">
    <table>
        <tr>
            <th>
                Дата покупки
            </th>
            <th>
                Название тарифа
            </th>
            <th>
                Цена, ₽
            </th>
            <th>
                Тарифная зона
            </th>
            <th>
                Сумма покупки, ₽
            </th>
        </tr>

");
#nullable restore
#line 26 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\PurchaseHistory\Index.cshtml"
         foreach (var purchase in @Model.Purchases)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\PurchaseHistory\Index.cshtml"
               Write(purchase.PurchaseTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\PurchaseHistory\Index.cshtml"
               Write(purchase.TariffName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\PurchaseHistory\Index.cshtml"
               Write(purchase.TariffPrice.ToString("######.##"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 32 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\PurchaseHistory\Index.cshtml"
               Write(purchase.TariffZone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 33 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\PurchaseHistory\Index.cshtml"
               Write(purchase.Summ.ToString("######.##"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 35 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\PurchaseHistory\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PurchaseHistoryModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
