#pragma checksum "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17d39a5799f2b9c35968b8890797560905371673"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stock_Index), @"mvc.1.0.view", @"/Views/Stock/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17d39a5799f2b9c35968b8890797560905371673", @"/Views/Stock/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90ce0c65725a5f7a18e8cf6f3ab1677c378fb47f", @"/Views/_ViewImports.cshtml")]
    public class Views_Stock_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StockModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml"
  
    ViewData["Title"] = "Stock";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h2>Автобус</h2>
<div class=""table"">
    <table>
        <tr>
            <th>
                Регистрационный номер
            </th>
            <th>
                Производитель
            </th>
            <th>
                Год выпуска
            </th>
            <th>
                Объем двигателя
            </th>
        </tr>

");
#nullable restore
#line 23 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml"
         foreach (var bus in @Model.Buses)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 26 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml"
               Write(bus.RegNum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml"
               Write(bus.Manufacturer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml"
               Write(bus.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml"
               Write(bus.Volume);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 31 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </table>

    <h2>Троллейбус</h2>
<div class=""table"">
    <table>
        <tr>
            <th>
                Регистрационный номер
            </th>
            <th>
                Производитель
            </th>
            <th>
                Год выпуска
            </th>
            <th>
                Тип системы управления
            </th>
        </tr>

");
#nullable restore
#line 52 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml"
         foreach (var bus in @Model.Trolleybuses)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 55 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml"
               Write(bus.RegNum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 56 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml"
               Write(bus.Manufacturer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 57 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml"
               Write(bus.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 58 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml"
               Write(bus.ControlType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 60 "C:\Users\ilyak\source\repos\TransportCompany\TransportCompany\Views\Stock\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StockModel> Html { get; private set; }
    }
}
#pragma warning restore 1591