#pragma checksum "C:\Users\ASUS\Documents\Metrodata\LMS\Client\Views\Class\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ad377e1a41d5838f4eb7ebf42b01b1226e4b913"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Class_Index), @"mvc.1.0.view", @"/Views/Class/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ad377e1a41d5838f4eb7ebf42b01b1226e4b913", @"/Views/Class/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Class_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\ASUS\Documents\Metrodata\LMS\Client\Views\Class\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""mainTitle"" class=""text-center mb-5 mt-5"">
    <h3>Daftar Kelas Codemy</h3>
    <p>Silahkan pilih kelas yang kamu inginkan</p>
</div>

<div class=""container text-center"">
    <div class=""card"">
        <div id=""mainCard"" class=""card-body"">
            <div id=""filter"" class=""row mb-4"">
                <div class=""col-sm"">
                    <p class=""mb-0"">Level</p>
                    <select id=""lv"" class=""selectpicker"" multiple>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ad377e1a41d5838f4eb7ebf42b01b1226e4b9133804", async() => {
                WriteLiteral("Beginner");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ad377e1a41d5838f4eb7ebf42b01b1226e4b9134788", async() => {
                WriteLiteral("Intermediate");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ad377e1a41d5838f4eb7ebf42b01b1226e4b9135776", async() => {
                WriteLiteral("Expert");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </select>\r\n                </div>\r\n\r\n                <div class=\"col-sm\">\r\n                    <p class=\"mb-0\">Category</p>\r\n                    <select id=\"cg\" class=\"selectpicker\" multiple>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ad377e1a41d5838f4eb7ebf42b01b1226e4b9136991", async() => {
                WriteLiteral("Front-End");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ad377e1a41d5838f4eb7ebf42b01b1226e4b9137976", async() => {
                WriteLiteral("Back-End");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ad377e1a41d5838f4eb7ebf42b01b1226e4b9138960", async() => {
                WriteLiteral("Fullstack");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </select>\r\n                </div>\r\n\r\n                <div class=\"col-sm\">\r\n                    <p class=\"mb-0\">Price Range</p>\r\n                    <select id=\"cg\" class=\"selectpicker\" multiple>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ad377e1a41d5838f4eb7ebf42b01b1226e4b91310181", async() => {
                WriteLiteral("500.000 - 1.000.000");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ad377e1a41d5838f4eb7ebf42b01b1226e4b91311177", async() => {
                WriteLiteral("1.000.001 - 2.500.000");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ad377e1a41d5838f4eb7ebf42b01b1226e4b91312175", async() => {
                WriteLiteral("2.500.000+");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </select>
                </div>
            </div>

            <div id=""classes"">
                <div class=""row mb-3"">
                    <div class=""col-sm"">
                        <div class=""card"">
                            <div class=""card-body text-left"">
                                <div class=""row"">
                                    <div class=""col-sm-3"">
                                        <img src=""https://www.fpaceforum.com/media/100x100.4555/full""");
            BeginWriteAttribute("alt", " alt=\"", 1930, "\"", 1936, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                    </div>
                                    <div class=""col-sm-9 align-self-center"">
                                        <h5 class=""mb-4 font-weight-bold""><a href=""class/details"">(Nama Kelas A)</a></h5>
                                        <span>(Nama Kategori)</span> <span>(Level)</span> <span>(Rating)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm"">
                        <div class=""card"">
                            <div class=""card-body text-left"">
                                <div class=""row"">
                                    <div class=""col-sm-3"">
                                        <img src=""https://www.fpaceforum.com/media/100x100.4555/full""");
            BeginWriteAttribute("alt", " alt=\"", 2841, "\"", 2847, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                    </div>
                                    <div class=""col-sm-9 align-self-center"">
                                        <h5 class=""mb-4 font-weight-bold""><a href=""class/details"">(Nama Kelas B)</a></h5>
                                        <span>(Nama Kategori)</span> <span>(Level)</span> <span>(Rating)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class=""row mb-3"">
                    <div class=""col-sm"">
                        <div class=""card"">
                            <div class=""card-body text-left"">
                                <div class=""row"">
                                    <div class=""col-sm-3"">
                                        <img src=""https://www.fpaceforum.com/media/100x100.4555/full""");
            BeginWriteAttribute("alt", " alt=\"", 3818, "\"", 3824, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                    </div>
                                    <div class=""col-sm-9 align-self-center"">
                                        <h5 class=""mb-4 font-weight-bold""><a href=""class/details"">(Nama Kelas C)</a></h5>
                                        <span>(Nama Kategori)</span> <span>(Level)</span> <span>(Rating)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm"">
                        <div class=""card"">
                            <div class=""card-body text-left"">
                                <div class=""row"">
                                    <div class=""col-sm-3"">
                                        <img src=""https://www.fpaceforum.com/media/100x100.4555/full""");
            BeginWriteAttribute("alt", " alt=\"", 4729, "\"", 4735, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                    </div>
                                    <div class=""col-sm-9 align-self-center"">
                                        <h5 class=""mb-4 font-weight-bold""><a href=""class/details"">(Nama Kelas D)</a></h5>
                                        <span>(Nama Kategori)</span> <span>(Level)</span> <span>(Rating)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class=""row mb-3"">
                    <div class=""col-sm"">
                        <div class=""card"">
                            <div class=""card-body text-left"">
                                <div class=""row"">
                                    <div class=""col-sm-3"">
                                        <img src=""https://www.fpaceforum.com/media/100x100.4555/full""");
            BeginWriteAttribute("alt", " alt=\"", 5706, "\"", 5712, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                    </div>
                                    <div class=""col-sm-9 align-self-center"">
                                        <h5 class=""mb-4 font-weight-bold""><a href=""class/details"">(Nama Kelas E)</a></h5>
                                        <span>(Nama Kategori)</span> <span>(Level)</span> <span>(Rating)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm"">
                        <div class=""card"">
                            <div class=""card-body text-left"">
                                <div class=""row"">
                                    <div class=""col-sm-3"">
                                        <img src=""https://www.fpaceforum.com/media/100x100.4555/full""");
            BeginWriteAttribute("alt", " alt=\"", 6617, "\"", 6623, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                    </div>
                                    <div class=""col-sm-9 align-self-center"">
                                        <h5 class=""mb-4 font-weight-bold""><a href=""class/details"">(Nama Kelas F)</a></h5>
                                        <span>(Nama Kategori)</span> <span>(Level)</span> <span>(Rating)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


");
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
