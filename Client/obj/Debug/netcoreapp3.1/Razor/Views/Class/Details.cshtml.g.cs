<<<<<<< HEAD
#pragma checksum "C:\Users\ASUS\Documents\Metrodata\LMS\Client\Views\Class\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "909fdac78dc1bff5aef0a8bfdf8f479064e9691b"
=======
#pragma checksum "C:\Users\A S U S\Documents\GitHub\LMS\Client\Views\Class\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad73d6c55e59dabac1adcd40571ddcd9b8b65be1"
>>>>>>> Vincen
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"909fdac78dc1bff5aef0a8bfdf8f479064e9691b", @"/Views/Class/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Class_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Client.Models.Class>
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
            WriteLiteral("\r\n");
#nullable restore
<<<<<<< HEAD
#line 3 "C:\Users\ASUS\Documents\Metrodata\LMS\Client\Views\Class\Details.cshtml"
=======
#line 2 "C:\Users\A S U S\Documents\GitHub\LMS\Client\Views\Class\Details.cshtml"
>>>>>>> Vincen
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container mt-5 mb-5\">\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-4\">\r\n            <h3>");
#nullable restore
#line 10 "C:\Users\ASUS\Documents\Metrodata\LMS\Client\Views\Class\Details.cshtml"
           Write(ViewBag.ClassId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <img src=\"https://dummyimage.com/sqrpop\"");
            BeginWriteAttribute("alt", " alt=\"", 256, "\"", 262, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
        </div>
        <div class=""col-sm-8 align-self-center"">
            <h5 class=""mb-3 font-weight-bold"">(Nama Kelas A)</h5>
            <p>(Deskripsi: Laoreet ac, aliquam sit amet justo nunc tempor, metus vel placerat suscipit, orci nisl iaculis eros, a tincidunt nisi odio eget lorem nulla condimentum tempor mattis ut vitae feugiat augue cras ut metus a risus iaculis scelerisque eu ac ante fusce non varius purus aenean nec magna felis fusce vestibulum.)</p>
            <p><span>(Nama Kategori)</span> <span>(Level)</span> <span>(Rating)</span></p>
            <button id=""gen-a-button"" type=""button"" class=""btn btn-primary"">Take Class</button>
            <button id=""feedback"" type=""button"" class=""btn btn-info"" data-toggle=""modal"" data-target=""#formFb"">Give Feedback</button>
            <button id=""gen-a-button"" type=""button"" class=""btn btn-success"">View Certificate</button>
        </div>
    </div>
</div>

<div class=""container card mb-3"">
    <div class=""card-body"">
        <ul class=");
            WriteLiteral(@"""nav nav-tabs mb-3"">
            <li class=""nav-item"">
                <a class=""nav-link active"" href=""#classSect"">Class Sections</a>
            </li>
        </ul>

        <div id=""#classSect"" class=""row"">
            <div class=""col-4"">
                <div class=""list-group"" id=""list-tab"" role=""tablist"" style=""height: 30rem; overflow: scroll;"">
                    <a class=""list-group-item list-group-item-action active"" data-toggle=""list"" href=""#sect1"">(Nama Section 1)</a>
                    <a class=""list-group-item list-group-item-action"" data-toggle=""list"" href=""#sect2"">(Nama Section 2)</a>
                    <a class=""list-group-item list-group-item-action"" data-toggle=""list"" href=""#sect3"">(Nama Section 3)</a>
                    <a class=""list-group-item list-group-item-action"" data-toggle=""list"" href=""#sect4"">(Nama Section 4)</a>
                    <a class=""list-group-item list-group-item-action"" data-toggle=""list"" href=""#sect2"">(Nama Section 2)</a>
                    <a class=""");
            WriteLiteral(@"list-group-item list-group-item-action"" data-toggle=""list"" href=""#sect3"">(Nama Section 3)</a>
                    <a class=""list-group-item list-group-item-action"" data-toggle=""list"" href=""#sect4"">(Nama Section 4)</a>
                    <a class=""list-group-item list-group-item-action"" data-toggle=""list"" href=""#sect2"">(Nama Section 2)</a>
                    <a class=""list-group-item list-group-item-action"" data-toggle=""list"" href=""#sect3"">(Nama Section 3)</a>
                    <a class=""list-group-item list-group-item-action"" data-toggle=""list"" href=""#sect4"">(Nama Section 4)</a>
                    <a class=""list-group-item list-group-item-action"" data-toggle=""list"" href=""#sect2"">(Nama Section 2)</a>
                    <a class=""list-group-item list-group-item-action"" data-toggle=""list"" href=""#sect3"">(Nama Section 3)</a>
                    <a class=""list-group-item list-group-item-action"" data-toggle=""list"" href=""#sect4"">(Nama Section 4)</a>
                </div>
            </div>
          ");
            WriteLiteral(@"  <div class=""col-8"">
                <div class=""tab-content"" id=""nav-tabContent"">
                    <div class=""tab-pane fade show active"" id=""sect1"">
                        <h4>(Nama Section 1)</h4>
                        <br />
                        <div id=""vidSect1"" class=""embed-responsive embed-responsive-16by9"">
                            <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/dQw4w9WgXcQ?rel=0"" allowfullscreen></iframe>
                        </div>
                    </div>
                    <div class=""tab-pane fade"" id=""sect2"">
                        <h4>(Nama Section 2)</h4>
                        <br />
                        <div id=""vidSect1"" class=""embed-responsive embed-responsive-16by9"">
                            <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/dQw4w9WgXcQ?rel=0"" allowfullscreen></iframe>
                        </div>
                    </div>
                    <div class=""tab-pane");
            WriteLiteral(@" fade"" id=""sect3"">
                        <h4>(Nama Section 3)</h4>
                        <br />
                        <div id=""vidSect1"" class=""embed-responsive embed-responsive-16by9"">
                            <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/dQw4w9WgXcQ?rel=0"" allowfullscreen></iframe>
                        </div>
                    </div>
                    <div class=""tab-pane fade"" id=""sect4"">
                        <h4>(Nama Section 4)</h4>
                        <br />
                        <div id=""vidSect1"" class=""embed-responsive embed-responsive-16by9"">
                            <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/dQw4w9WgXcQ?rel=0"" allowfullscreen></iframe>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</div>

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "909fdac78dc1bff5aef0a8bfdf8f479064e9691b10032", async() => {
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
                            <textarea class=""form-control"" id=""exampleInputEmail1"" placeholder=""ketik ulasanmu disini ..."" rows=""3""></textarea>
                            <small class=""fo");
                WriteLiteral("rm-text text-muted\">Ulasanmu sangat penting bagi kami.</small>\r\n                        </div>\r\n                        <button type=\"submit\" class=\"btn btn-primary rounded float-right\">Send Feedback</button>\r\n                    ");
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
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral(@"<script type=""text/javascript"">
    var genButton = document.getElementById('gen-a-button');
    genButton.addEventListener('click', function () {
        let timestamp = Math.round(Date.now() / 1000);
        $.ajax({
            url: ""https://app.sandbox.midtrans.com/snap/v1/transactions"",
            type: ""POST"",
            headers: {
                ""Content-Type"": ""application/json"",
                ""Accept"": ""application/json"",
                ""Authorization"": ""Basic "" + ""U0ItTWlkLXNlcnZlci1sdHhEaS1iQ3hMSGV6Z281MlRHa183cXA6""
            },
            data: JSON.stringify({
                ""transaction_details"": {
                    ""order_id"": `PAY-CLASS-A-${timestamp}`,
                    ""gross_amount"": 2000000
                },
                ""credit_card"": {
                    ""secure"": true
                },
                ""customer_details"": {
                    ""first_name"": ""Dari"",
                    ""last_name"": ""Client"",
                    ""email"": ""Daclint@");
            WriteLiteral(@"mail.com"",
                    ""phone"": ""08110000000""
                }
            })
        }).done((result) => {
            snap.pay(result.token);
        }).fail((error) => {
            console.log(error);
        });
    });

    var genButton = document.getElementById('gen-b-button');
    genButton.addEventListener('click', function () {
        let timestamp = Math.round(Date.now() / 1000);
        console.log(timestamp);
        $.ajax({
            url: ""https://app.sandbox.midtrans.com/snap/v1/transactions"",
            type: ""POST"",
            headers: {
                ""Content-Type"": ""application/json"",
                ""Accept"": ""application/json"",
                ""Authorization"": ""Basic "" + ""U0ItTWlkLXNlcnZlci1sdHhEaS1iQ3hMSGV6Z281MlRHa183cXA6""
            },
            data: JSON.stringify({
                ""transaction_details"": {
                    ""order_id"": `PAY-CLASS-B-${timestamp}`,
                    ""gross_amount"": 3000000
                },
        ");
            WriteLiteral(@"        ""credit_card"": {
                    ""secure"": true
                },
                ""customer_details"": {
                    ""first_name"": ""Dari"",
                    ""last_name"": ""Client"",
                    ""email"": ""Daclint@mail.com"",
                    ""phone"": ""08110000000""
                }
            })
        }).done((result) => {
            snap.pay(result.token);
        }).fail((error) => {
            console.log(error);
        });
    });

    var genButton = document.getElementById('gen-c-button');
    genButton.addEventListener('click', function () {
        let timestamp = Math.round(Date.now() / 1000);
        $.ajax({
            url: ""https://app.sandbox.midtrans.com/snap/v1/transactions"",
            type: ""POST"",
            headers: {
                ""Content-Type"": ""application/json"",
                ""Accept"": ""application/json"",
                ""Authorization"": ""Basic "" + ""U0ItTWlkLXNlcnZlci1sdHhEaS1iQ3hMSGV6Z281MlRHa183cXA6""
            },");
            WriteLiteral(@"
            data: JSON.stringify({
                ""transaction_details"": {
                    ""order_id"": `PAY-CLASS-C-${timestamp}`,
                    ""gross_amount"": 2500000
                },
                ""credit_card"": {
                    ""secure"": true
                },
                ""customer_details"": {
                    ""first_name"": ""Dari"",
                    ""last_name"": ""Client"",
                    ""email"": ""Daclint@mail.com"",
                    ""phone"": ""08110000000""
                }
            })
        }).done((result) => {
            snap.pay(result.token);
        }).fail((error) => {
            console.log(error);
        });
    });
</script>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Client.Models.Class> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
