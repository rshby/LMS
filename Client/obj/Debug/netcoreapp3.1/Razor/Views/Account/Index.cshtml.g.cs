#pragma checksum "P:\MCC\Tugas\Git\LMS\Client\Views\Account\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94240f41fe6e7e89a837677173d7e8265fa6370b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Index), @"mvc.1.0.view", @"/Views/Account/Index.cshtml")]
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
#line 1 "P:\MCC\Tugas\Git\LMS\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "P:\MCC\Tugas\Git\LMS\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94240f41fe6e7e89a837677173d7e8265fa6370b", @"/Views/Account/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("needs-validation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formUpdateAccount"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return false"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "P:\MCC\Tugas\Git\LMS\Client\Views\Account\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container mt-5\">\r\n    <div class=\"card mb-5\">\r\n        <div class=\"card-body\">\r\n            <h4>User Profile</h4>\r\n            <div class=\"dropdown-divider\"></div>\r\n            <div class=\"modal-body\" id=\"DetailEmp\">\r\n");
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94240f41fe6e7e89a837677173d7e8265fa6370b5683", async() => {
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""form-group col"">
                            <label for=""InputFN"">Nama Depan</label>
                            <input type=""text"" class=""form-control"" id=""InputFN"" aria-describedby=""inputFN"" placeholder=""cth: Budi"" required>
                            <div class=""invalid-feedback"">
                                Mohon Isi Nama Depan
                            </div>
                        </div>
                        <div class=""form-group col"">
                            <label for=""InputLN"">Nama Belakang</label>
                            <input type=""text"" class=""form-control"" id=""InputLN"" aria-describedby=""inputLN"" placeholder=""cth: Setiawan"" required>
                            <div class=""invalid-feedback"">
                                Mohon Isi Nama Belakang
                            </div>
                        </div>
                        <div class=""form-group col"">
                       ");
                WriteLiteral("     <label for=\"InputGd\">Jenis Kelamin</label>\r\n                            <select class=\"custom-select mr-sm-2\" id=\"InputGd\" required>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94240f41fe6e7e89a837677173d7e8265fa6370b7214", async() => {
                    WriteLiteral("Pilih ...");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94240f41fe6e7e89a837677173d7e8265fa6370b8472", async() => {
                    WriteLiteral("Laki-laki");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94240f41fe6e7e89a837677173d7e8265fa6370b9730", async() => {
                    WriteLiteral("Perempuan");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </select>
                            <div class=""invalid-feedback"">
                                Mohon Isi Jenis Kelamin
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""form-group col mb-0"">
                            <label for=""InputBd"">Tanggal Lahir</label>
                            <div class=""form-group"">
                                <div class=""datepicker date input-group"">
                                    <input type=""date"" placeholder=""cth: 2012-12-21"" class=""form-control"" id=""InputBd"" required>
                                    <div class=""invalid-feedback"">
                                        Mohon Isi Tanggal Lahir
                                    </div>
                                    <span class=""input-group-append""></span>
                                </div>
                            </div>
          ");
                WriteLiteral(@"              </div>
                        <div class=""form-group col"">
                            <label for=""InputPh"">Nomor Telepon</label>
                            <input type=""text"" class=""form-control"" id=""InputPh"" aria-describedby=""inputPh"" placeholder=""cth: 0812xxxxxxx"" required>
                            <div class=""invalid-feedback"">
                                Mohon Isi Nomor Telepon
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""form-group col"">
                            <label for=""InputDg"">Major</label>
                            <input type=""text"" class=""form-control"" id=""InputMajor"" aria-describedby=""inputMajor"" placeholder=""cth: Teknik Informatika"" required>
                            <div class=""invalid-feedback"">
                                Mohon Isi Major
                            </div>
                        </div>
                ");
                WriteLiteral(@"        <div class=""form-group col"">
                            <label for=""InputUn"">Universitas</label>
                            <select class=""custom-select mr-sm-2"" id=""InputUn"" required>
                            </select>
                            <div class=""invalid-feedback"">
                                Mohon Isi Universitas
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""form-group col"">
                            <label for=""InputProvince"">Provinsi</label>
                            <select class=""custom-select mr-sm-2"" id=""InputProvince"" required>
                            </select>
                            <div class=""invalid-feedback"">
                                Mohon Isi Provinsi
                            </div>
                        </div>
                        <div class=""form-group col"">
                            <label for=""I");
                WriteLiteral(@"nputCity"">Kota</label>
                            <select class=""custom-select mr-sm-2"" id=""InputCity"" required>
                            </select>
                            <div class=""invalid-feedback"">
                                Mohon Isi Kota
                            </div>
                        </div>
                        <div class=""form-group col"">
                            <label for=""InputDistrict"">Kecamatan</label>
                            <select class=""custom-select mr-sm-2"" id=""InputDistrict"" required>
                            </select>
                            <div class=""invalid-feedback"">
                                Mohon Isi Kecamatan
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""form-group col"">
                            <label for=""InputSubDistrict"">Kelurahan</label>
                            <select class=""custom-s");
                WriteLiteral(@"elect mr-sm-2"" id=""InputSubDistrict"" required>
                            </select>
                            <div class=""invalid-feedback"">
                                Mohon Isi Kelurahan
                            </div>
                        </div>
                        <div class=""form-group col"">
                            <label for=""InputUn"">Alamat</label>
                            <input type=""text"" class=""form-control"" id=""InputStreet"" aria-describedby=""inputStreet"" placeholder=""cth: Jl. Merdeka"" required>
                            <div class=""invalid-feedback"">
                                Mohon Isi Alamat
                            </div>
                        </div>
                    </div>
                    <br />
                    <button type=""submit"" id=""buttonUpdateAcount"" class=""btn btn-primary rounded float-right"" style=""width: 150px"">Update</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("novalidate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
