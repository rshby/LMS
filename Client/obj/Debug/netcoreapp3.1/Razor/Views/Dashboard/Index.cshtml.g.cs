#pragma checksum "C:\Users\ASUS\Documents\Metrodata\LMS\Client\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb8a7db3f592e6df54ef7ca953e354664578524a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Index), @"mvc.1.0.view", @"/Views/Dashboard/Index.cshtml")]
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
#line 1 "C:\Users\ASUS\Documents\Metrodata\LMS\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Documents\Metrodata\LMS\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb8a7db3f592e6df54ef7ca953e354664578524a", @"/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ASUS\Documents\Metrodata\LMS\Client\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""mb-5 mt-5"">
    <div class=""ml-3"">
        <h3>Selamat datang (Nama Lengkap)!</h3>
        <p>Selamat belajar dan bereksplorasi.</p>
    </div>
</div>
<div class=""row"">
    <div class=""col-sm"">
        <div class=""card"">
            <div class=""card-header bg-white"">
                Kelas yang Sedang Dijalani
            </div>
            <div class=""card-body"">
                <table class=""table table-borderless table-striped"">
                    <thead>
                        <tr>
                            <th scope=""col"">Class Name</th>
                            <th scope=""col"">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td><a href=""Class"">(Nama Kelas A)</a></td>
                            <td><button type=""button"" class=""btn btn-outline-info"">Continue</button></td>
                        </tr>
                        <tr>
                       ");
            WriteLiteral(@"     <td><a href=""#"">(Nama Kelas B)</a></td>
                            <td><button type=""button"" class=""btn btn-outline-info"">Continue</button></td>
                        </tr>
                        <tr>
                            <td><a href=""#"">(Nama Kelas C)</a></td>
                            <td><button type=""button"" class=""btn btn-outline-info"">Continue</button></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <div class=""col-sm"">
        <div class=""card"">
            <div class=""card-header bg-white"">
                Kelas yang Sudah Selesai
            </div>
            <div class=""card-body"">
                <table class=""table table-borderless table-striped"">
                    <thead>
                        <tr>
                            <th scope=""col"">Class Name</th>
                            <th scope=""col"">Action</th>
                        </tr>
                    ");
            WriteLiteral(@"</thead>
                    <tbody>
                        <tr>
                            <td><a href=""#"">(Nama Kelas A)</a></td>
                            <td><button type=""button"" class=""btn btn-outline-info"">Feedback</button><button type=""button"" class=""btn btn-outline-info  ml-2"">Certificate</button></td>
                        </tr>
                        <tr>
                            <td><a href=""#"">(Nama Kelas B)</a></td>
                            <td><button type=""button"" class=""btn btn-outline-info"">Feedback</button><button type=""button"" class=""btn btn-outline-info  ml-2"">Certificate</button></td>
                        </tr>
                        <tr>
                            <td><a href=""#"">(Nama Kelas C)</a></td>
                            <td><button type=""button"" class=""btn btn-outline-info"">Feedback</button><button type=""button"" class=""btn btn-outline-info  ml-2"">Certificate</button></td>
                        </tr>
                    </tbody>
             ");
            WriteLiteral("   </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
