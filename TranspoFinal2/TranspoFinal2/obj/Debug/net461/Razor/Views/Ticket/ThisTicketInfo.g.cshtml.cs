#pragma checksum "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Ticket\ThisTicketInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e07379ed938a4a0985ca94d49bb152b1aa9c5eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket_ThisTicketInfo), @"mvc.1.0.view", @"/Views/Ticket/ThisTicketInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ticket/ThisTicketInfo.cshtml", typeof(AspNetCore.Views_Ticket_ThisTicketInfo))]
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
#line 1 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\_ViewImports.cshtml"
using TranspoFinal2;

#line default
#line hidden
#line 2 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\_ViewImports.cshtml"
using TranspoFinal2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e07379ed938a4a0985ca94d49bb152b1aa9c5eb", @"/Views/Ticket/ThisTicketInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d195f188aa809560850673945ee9e3e284bdef3", @"/Views/_ViewImports.cshtml")]
    public class Views_Ticket_ThisTicketInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TranspoFinal2.Models.Transactions>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("sampleform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteTicket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Ticket\ThisTicketInfo.cshtml"
  
    ViewData["Title"] = "Ticket Info";

#line default
#line hidden
            BeginContext(89, 371, true);
            WriteLiteral(@"
<!DOCTYPE html>
<link href=""//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css"" rel=""stylesheet"" id=""bootstrap-css"">
<script src=""//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js""></script>
<script src=""//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js""></script>
<!------ Include the above in your HEAD tag ---------->
<html>
");
            EndContext();
            BeginContext(460, 438, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b0db66df3c246a684ffe1c49c25e00e", async() => {
                BeginContext(466, 425, true);
                WriteLiteral(@"
    <link href=""https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"" rel=""stylesheet""
          integrity=""sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO"" crossorigin=""anonymous"">
    <style>
        body {
            background: linear-gradient( #de9b35, #FEB58A) fixed; /* W3C, IE 10+ / Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
        }
    </style>

");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(898, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(902, 3442, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55d2f6e1cabc42e9bbae4c2c64249140", async() => {
                BeginContext(908, 931, true);
                WriteLiteral(@"
    <br />
    <br />
    <br />
    <!-- Top header -->

    <div class=""w-50 px-3 py-3 pt-md-4 pb-md-4 mx-auto text-center"">
        <h1 class=""display-4 font-weight-bold"">Your Ticket Info</h1>
        <p class=""lead"">

        </p>
    </div>
    <!-- Cards container -->
    <div class=""container text-center"">
        <div class=""row"">
            <!-- Card #1, Starter -->
            <div class=""col-lg-4 col-md-6 col-sm-10 pb-4 d-block m-auto"">

            </div>
            <!-- Card #2, Intermediate -->
            <div class=""col-lg-4 col-md-6 col-sm-10 pb-4 d-block m-auto""  style=""background: #fff;"">
                <div class=""pricing-item"" style=""box-shadow: 0px 0px 30px -7px rgba(0,0,0,0.29);"">

                    <div class=""pricing-price pb-1 text-primary color-primary-text "">
                        <h1 style=""font-weight: 1000; font-size: 3.5em;"">
                            ");
                EndContext();
                BeginContext(1840, 14, false);
#line 48 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Ticket\ThisTicketInfo.cshtml"
                       Write(Model.route_ID);

#line default
#line hidden
                EndContext();
                BeginContext(1854, 202, true);
                WriteLiteral("\r\n                        </h1>\r\n                    </div>\r\n                    <div class=\"pt-4 pb-3\" style=\"letter-spacing: 2px\">\r\n                        <h4> <span style=\"font-size: 20px;\">₪</span>");
                EndContext();
                BeginContext(2057, 18, false);
#line 52 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Ticket\ThisTicketInfo.cshtml"
                                                               Write(Model.money_amount);

#line default
#line hidden
                EndContext();
                BeginContext(2075, 212, true);
                WriteLiteral("</h4>\r\n                    </div>\r\n                    <div class=\"pricing-description\">\r\n                        <ul class=\"list-unstyled mt-3 mb-4\">\r\n                            <li class=\"pl-3 pr-3\">Seat Num: ");
                EndContext();
                BeginContext(2288, 12, false);
#line 56 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Ticket\ThisTicketInfo.cshtml"
                                                       Write(ViewBag.seat);

#line default
#line hidden
                EndContext();
                BeginContext(2300, 204, true);
                WriteLiteral("</li>\r\n                            <li class=\"pl-3 pr-3\"></li>\r\n                        </ul>\r\n                    </div>\r\n                    <div class=\"pricing-button pb-4\">\r\n\r\n                        ");
                EndContext();
                BeginContext(2504, 1158, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "325d8942c453437e95974cbe501f7b74", async() => {
                    BeginContext(2566, 30, true);
                    WriteLiteral("\r\n                            ");
                    EndContext();
                    BeginContext(2596, 40, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f09c09660cfc42c98f649e66f20604e3", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 63 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Ticket\ThisTicketInfo.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.the_ID);

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2636, 1019, true);
                    WriteLiteral(@"
                            <input id=""Create"" type=""button"" value=""Delete Ticket"" class=""btn btn-lg btn-primary w-75"" style=""position:center"" />

                            <script src=""https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js""></script>
                            <script type=""text/javascript"">
                                $(function () {
                                    $(""#Create"").click(function (e) {
                                        if (confirm(""Are you sure you want to delete this ticket?"")) {
                                            console.log('Form is submitting');
                                            $(""#sampleform"").submit();
                                        } else {
                                            console.log('User clicked no.');
                                        }
                                    });
                                });
                            </script>
                        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3662, 675, true);
                WriteLiteral(@"
                    </div>
                </div>
            </div>
            <!-- Card #3, Professional -->
            <div class=""col-lg-4 col-md-6 col-sm-10 pb-4 d-block m-auto"">

            </div>
        </div>
    </div>


    <script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.bundle.min.js""
            integrity=""sha384-pjaaA8dDz/5BgdFUPX6M/9SUZv4d12SUPF0axWc+VRZkx5xU3daN+lYb49+Ax+Tl""
            crossorigin=""anonymous""></script>
    <script src=""https://code.jquery.com/jquery-3.3.1.min.js""
            integrity=""sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=""
            crossorigin=""anonymous""></script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4344, 11, true);
            WriteLiteral("\r\n</html>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TranspoFinal2.Models.Transactions> Html { get; private set; }
    }
}
#pragma warning restore 1591
