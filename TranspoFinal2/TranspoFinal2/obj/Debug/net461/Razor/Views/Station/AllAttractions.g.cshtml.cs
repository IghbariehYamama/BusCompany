#pragma checksum "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "deffd2ebf34b80bff192c131f9d207e7dfb673ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Station_AllAttractions), @"mvc.1.0.view", @"/Views/Station/AllAttractions.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Station/AllAttractions.cshtml", typeof(AspNetCore.Views_Station_AllAttractions))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"deffd2ebf34b80bff192c131f9d207e7dfb673ab", @"/Views/Station/AllAttractions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d195f188aa809560850673945ee9e3e284bdef3", @"/Views/_ViewImports.cshtml")]
    public class Views_Station_AllAttractions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ServiceReference1.Attraction>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/searchstyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SearchAttraction", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("text-align:center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml"
  
    ViewData["Title"] = "AllAttractions";

#line default
#line hidden
            BeginContext(87, 37, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            EndContext();
            BeginContext(124, 2236, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b18ebf2350424c61a403d9ae2aebafee", async() => {
                BeginContext(130, 199, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\">\r\n    ");
                EndContext();
                BeginContext(329, 54, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "31518e5fade34250be5d37da342945c5", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(383, 1970, true);
                WriteLiteral(@"



    <style>

        a {
            color: #69C;
            text-decoration: none;
        }

            a:hover {
                color: #F60;
            }

        h1 {
            font: 1.7em;
            line-height: 110%;
            color: #000;
        }

        h2 {
            text-align: center;
        }

        p {
            margin: 0 0 20px;
        }


        input {
            outline: none;
        }

            input[type=search] {
                -webkit-appearance: textfield;
                -webkit-box-sizing: content-box;
                font-family: inherit;
                font-size: 100%;
            }

            input::-webkit-search-decoration,
            input::-webkit-search-cancel-button {
                display: none;
            }


            input[type=search] {
                background: #ededed url(https://static.tumblr.com/ftv85bp/MIXmud4tx/search-icon.png) no-repeat 9px center;
                border: so");
                WriteLiteral(@"lid 1px #ccc;
                padding: 9px 10px 9px 32px;
                width: 55px;
                -webkit-border-radius: 10em;
                -moz-border-radius: 10em;
                border-radius: 10em;
                -webkit-transition: all .5s;
                -moz-transition: all .5s;
                transition: all .5s;
            }

                input[type=search]:focus {
                    width: 130px;
                    background-color: #fff;
                    border-color: #66CC75;
                    -webkit-box-shadow: 0 0 5px rgba(109,207,246,.5);
                    -moz-box-shadow: 0 0 5px rgba(109,207,246,.5);
                    box-shadow: 0 0 5px rgba(109,207,246,.5);
                }


            input:-moz-placeholder {
                color: #999;
            }

            input::-webkit-input-placeholder {
                color: #999;
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
            BeginContext(2360, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2362, 2278, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fdd174bbb17469287f45e12d93cece7", async() => {
                BeginContext(2368, 83, true);
                WriteLiteral("\r\n    <br />\r\n    <br />\r\n    <br />\r\n    <div class=\"container\">\r\n        <br />\r\n");
                EndContext();
#line 96 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml"
         if (ViewBag.l1.Length == 0)
        {


#line default
#line hidden
                BeginContext(2502, 75, true);
                WriteLiteral("            <h2> There are no attractions that are near this station</h2>\r\n");
                EndContext();
#line 100 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml"
        }

#line default
#line hidden
                BeginContext(2588, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 102 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml"
         if (ViewBag.l1.Length == 0)
        {

#line default
#line hidden
                BeginContext(2639, 43, true);
                WriteLiteral("            <h2>All Attractions Near</h2>\r\n");
                EndContext();
                BeginContext(2684, 8, true);
                WriteLiteral("        ");
                EndContext();
                BeginContext(2692, 175, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d266e1289d74cf9a3c68b87a1677c06", async() => {
                    BeginContext(2768, 14, true);
                    WriteLiteral("\r\n            ");
                    EndContext();
                    BeginContext(2782, 68, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "74c7a23595e64c35a8c7d481e0a98c23", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 107 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.attraction_name);

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2850, 10, true);
                    WriteLiteral("\r\n        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2867, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(2873, 32, true);
                WriteLiteral("        <br />\r\n        <br />\r\n");
                EndContext();
                BeginContext(2907, 429, true);
                WriteLiteral(@"        <table class=""table"">
            <thead class=""thead-dark"">
                <tr>
                    <th scope=""col"">#</th>
                    <th scope=""col"">Attraction Name</th>
                    <th scope=""col"">Attraction ID</th>
                    <th scope=""col"">Attraction Location</th>
                    <th scope=""col"">Actions</th>
                </tr>
            </thead>
            <tbody>
");
                EndContext();
#line 125 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml"
                 foreach (ServiceReference1.Attraction st in ((ServiceReference1.Attraction[])ViewBag.l1))
                {

#line default
#line hidden
                BeginContext(3463, 66, true);
                WriteLiteral("                    <tr>\r\n                        <th scope=\"row\">");
                EndContext();
                BeginContext(3530, 10, false);
#line 128 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml"
                                   Write(ViewBag.l2);

#line default
#line hidden
                EndContext();
                BeginContext(3540, 35, true);
                WriteLiteral("</th>\r\n                        <td>");
                EndContext();
                BeginContext(3576, 18, false);
#line 129 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml"
                       Write(st.attraction_name);

#line default
#line hidden
                EndContext();
                BeginContext(3594, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(3630, 16, false);
#line 130 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml"
                       Write(st.attraction_ID);

#line default
#line hidden
                EndContext();
                BeginContext(3646, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(3682, 22, false);
#line 131 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml"
                       Write(st.attraction_location);

#line default
#line hidden
                EndContext();
                BeginContext(3704, 65, true);
                WriteLiteral("</td>\r\n                        <td>\r\n                            ");
                EndContext();
                BeginContext(3770, 78, false);
#line 133 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml"
                       Write(Html.ActionLink("Info", "AttractionInfo", st, new { @class = "btn btn-dark" }));

#line default
#line hidden
                EndContext();
                BeginContext(3848, 60, true);
                WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
                EndContext();
#line 136 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml"
                    ViewBag.l2++;
                }

#line default
#line hidden
                BeginContext(3962, 44, true);
                WriteLiteral("\r\n\r\n            </tbody>\r\n        </table>\r\n");
                EndContext();
#line 142 "C:\Users\yamama\Desktop\projects\TranspoFinal2\TranspoFinal2\Views\Station\AllAttractions.cshtml"

        }

#line default
#line hidden
                BeginContext(4019, 614, true);
                WriteLiteral(@"


    </div>

    <script>
        function searchToggle(obj, evt) {
            var container = $(obj).closest("".search-wrapper"");
            if (!container.hasClass(""active"")) {
                container.addClass(""active"");
                evt.preventDefault();
            } else if (
                container.hasClass(""active"") &&
                $(obj).closest("".input-holder"").length == 0
            ) {
                container.removeClass(""active"");
                // clear input
                container.find("".search-input"").val("""");
            }
        }

    </script>

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
            BeginContext(4640, 13, true);
            WriteLiteral("\r\n\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceReference1.Attraction> Html { get; private set; }
    }
}
#pragma warning restore 1591
