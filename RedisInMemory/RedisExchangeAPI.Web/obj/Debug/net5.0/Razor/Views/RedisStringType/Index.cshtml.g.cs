#pragma checksum "C:\Users\Muhammed\source\repos\RedisInMemory\RedisExchangeAPI.Web\Views\RedisStringType\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39cc19efe9d2cf2fa3b127c536dcea9bcb39bf9c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RedisStringType_Index), @"mvc.1.0.view", @"/Views/RedisStringType/Index.cshtml")]
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
#line 1 "C:\Users\Muhammed\source\repos\RedisInMemory\RedisExchangeAPI.Web\Views\_ViewImports.cshtml"
using RedisExchangeAPI.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Muhammed\source\repos\RedisInMemory\RedisExchangeAPI.Web\Views\_ViewImports.cshtml"
using RedisExchangeAPI.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39cc19efe9d2cf2fa3b127c536dcea9bcb39bf9c", @"/Views/RedisStringType/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b887bbd62d89910b2a1ec81835ff7d2b056da440", @"/Views/_ViewImports.cshtml")]
    public class Views_RedisStringType_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1> Redis String Type </h1>\r\n<h2> ");
#nullable restore
#line 7 "C:\Users\Muhammed\source\repos\RedisInMemory\RedisExchangeAPI.Web\Views\RedisStringType\Index.cshtml"
Write(ViewBag.value);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Muhammed\source\repos\RedisInMemory\RedisExchangeAPI.Web\Views\RedisStringType\Index.cshtml"
 if(ViewBag.person == null) 
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p> Veri yok </p>\r\n");
#nullable restore
#line 12 "C:\Users\Muhammed\source\repos\RedisInMemory\RedisExchangeAPI.Web\Views\RedisStringType\Index.cshtml"
}
else 
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3> ");
#nullable restore
#line 15 "C:\Users\Muhammed\source\repos\RedisInMemory\RedisExchangeAPI.Web\Views\RedisStringType\Index.cshtml"
Write(ViewBag.person.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n");
#nullable restore
#line 16 "C:\Users\Muhammed\source\repos\RedisInMemory\RedisExchangeAPI.Web\Views\RedisStringType\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
