#pragma checksum "C:\Users\A S U S\Documents\GitHub\LMS\Client\Views\Class\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe89f80efb0a3caf47867c0a4f05e3f452ef0efe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Class_Details), @"mvc.1.0.view", @"/Views/Class/Details.cshtml")]
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
#line 1 "C:\Users\A S U S\Documents\GitHub\LMS\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\A S U S\Documents\GitHub\LMS\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe89f80efb0a3caf47867c0a4f05e3f452ef0efe", @"/Views/Class/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Class_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\A S U S\Documents\GitHub\LMS\Client\Views\Class\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"codemyClassesDetail\">\r\n\r\n</div>\r\n\r\n<script>\r\n    let classId = ");
#nullable restore
#line 10 "C:\Users\A S U S\Documents\GitHub\LMS\Client\Views\Class\Details.cshtml"
              Write(ViewBag.ClassId);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n</script>\r\n\r\n<div id=\"classDetail\">\r\n\r\n</div>\r\n\r\n<div id=\"classSections\">\r\n\r\n</div>\r\n\r\n\r\n");
            WriteLiteral(@"<script>
    function enroll() {
        let token = """";
        $.ajax({
            url: ""https://localhost:44376/api/takenclasses/register"",
            type: ""post"",
            headers: {
                ""Content-Type"": ""application/json"",
                ""Accept"": ""application/json""
            },
            data: JSON.stringify(
                {
                    ""Email"": ""dennyfpr@gmail.com"",
                    ""Class_Id"": classId
                }),
            async: false
        }).done((result) => {
            token = result.dataToken.token;
            snap.pay(token);
        }).fail((error) => {
            console.log(error);
        })
    }
</script>

");
            WriteLiteral(@"<div class=""modal fade"" id=""formFb"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Feedback Form</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe89f80efb0a3caf47867c0a4f05e3f452ef0efe5298", async() => {
                WriteLiteral(@"
                        <div class=""form-group"">
                            <div class=""rating"">
                                <input type=""radio"" name=""rating"" value=""5"" id=""5""><label for=""5"">☆</label>
                                <input type=""radio"" name=""rating"" value=""4"" id=""4""><label for=""4"">☆</label>
                                <input type=""radio"" name=""rating"" value=""3"" id=""3""><label for=""3"">☆</label>
                                <input type=""radio"" name=""rating"" value=""2"" id=""2""><label for=""2"">☆</label>
                                <input type=""radio"" name=""rating"" value=""1"" id=""1""><label for=""1"">☆</label>
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label for=""inputFb"">Ulasan Kamu</label>
                            <textarea class=""form-control"" id=""reviewText"" placeholder=""ketik ulasanmu disini ..."" rows=""3""></textarea>
                            <small class=""form-text ");
                WriteLiteral("text-muted\">Ulasanmu sangat penting bagi kami.</small>\r\n                        </div>\r\n                        <button id=\"btnSendFb\" type=\"submit\" class=\"btn btn-primary rounded float-right\">Send Feedback</button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
