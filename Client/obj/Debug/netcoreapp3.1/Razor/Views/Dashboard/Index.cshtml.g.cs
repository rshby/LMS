<<<<<<< HEAD
#pragma checksum "C:\Users\A S U S\Documents\GitHub\LMS\Client\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a32a94d85f18a578a6cfc9fc2efb996261ffa1a2"
=======
#pragma checksum "P:\MCC\Tugas\Git\LMS\Client\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "281b5ba8c1da083c32304730f98f9cd71c25055c"
>>>>>>> Denny
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
<<<<<<< HEAD
#line 1 "C:\Users\A S U S\Documents\GitHub\LMS\Client\Views\_ViewImports.cshtml"
=======
#line 1 "P:\MCC\Tugas\Git\LMS\Client\Views\_ViewImports.cshtml"
>>>>>>> Denny
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
<<<<<<< HEAD
#line 2 "C:\Users\A S U S\Documents\GitHub\LMS\Client\Views\_ViewImports.cshtml"
=======
#line 2 "P:\MCC\Tugas\Git\LMS\Client\Views\_ViewImports.cshtml"
>>>>>>> Denny
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"281b5ba8c1da083c32304730f98f9cd71c25055c", @"/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
<<<<<<< HEAD
#line 1 "C:\Users\A S U S\Documents\GitHub\LMS\Client\Views\Dashboard\Index.cshtml"
=======
#line 1 "P:\MCC\Tugas\Git\LMS\Client\Views\Dashboard\Index.cshtml"
>>>>>>> Denny
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""dashboard"">

</div>

<div class=""mb-5 mt-5"">
    <div class=""ml-3"">
        <h3>Selamat datang (Nama Lengkap)!</h3>
        <p>Selamat belajar dan bereksplorasi.</p>
    </div>
</div>

<div class=""mb-3"">
    <div class=""card"">
        <div class=""card-header bg-white"">
            <h5>Kelas yang Sedang Diproses Pembayaran</h5>
        </div>
        <div class=""card-body"">
            <table id=""unpaidClasses"" class=""table table-borderless table-striped"">
                <thead>
                    <tr>
                        <th scope=""col"">Class Name</th>
                        <th scope=""col"">Price</th>
                        <th scope=""col"">Date Expired</th>
                        <th scope=""col"">Action</th>
                    </tr>
                </thead>
                <tbody id=""unpaidClass"">
                </tbody>
            </table>
        </div>
    </div>
</div>

<div class=""row"">
    <div class=""col-sm"">
        <div class=""card"">
         ");
            WriteLiteral(@"   <div class=""card-header bg-white"">
                <h5>Kelas yang Sedang Dijalani</h5>
            </div>
            <div class=""card-body"">
                <table class=""table table-borderless table-striped"">
                    <thead>
                        <tr>
                            <th scope=""col"">Class Name</th>
                            <th scope=""col"">Action</th>
                        </tr>
                    </thead>
                    <tbody id=""undoneClass"">

                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <div class=""col-sm"">
        <div class=""card"">
            <div class=""card-header bg-white"">
                <h5>Kelas yang Sudah Selesai</h5>
            </div>
            <div class=""card-body"">
                <table class=""table table-borderless table-striped"">
                    <thead>
                        <tr>
                            <th scope=""col"">Class Name</th>
               ");
            WriteLiteral("             <th scope=\"col\">Action</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody id=\"doneClass\">\r\n");
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
