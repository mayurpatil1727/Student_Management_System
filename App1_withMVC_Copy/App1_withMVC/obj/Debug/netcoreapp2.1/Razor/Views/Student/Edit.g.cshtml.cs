#pragma checksum "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea4911d87cb0b6b8f8d3a423ba27d48c6bcfdb5e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Edit), @"mvc.1.0.view", @"/Views/Student/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Student/Edit.cshtml", typeof(AspNetCore.Views_Student_Edit))]
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
#line 1 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\_ViewImports.cshtml"
using App1_withMVC;

#line default
#line hidden
#line 2 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\_ViewImports.cshtml"
using App1_withMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea4911d87cb0b6b8f8d3a423ba27d48c6bcfdb5e", @"/Views/Student/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0871692f683653794183833f75722434b8612e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<App1_withMVC.Models.StudentModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
  
    ViewData["Title"] = "ProfilePage";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(137, 160, true);
            WriteLiteral("\r\n\r\n\r\n<h2 class=\"container-fluid text-info bg-warning \">Edit ProfilePage</h2>\r\n\r\n<div>\r\n\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(298, 45, false);
#line 17 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
       Write(Html.DisplayNameFor(model => model.StudentID));

#line default
#line hidden
            EndContext();
            BeginContext(343, 71, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            <input type=\"text\"  id=\"ID1\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 414, "\"", 464, 1);
#line 20 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
WriteAttributeValue("", 422, Html.DisplayFor(model => model.StudentID), 422, 42, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(465, 70, true);
            WriteLiteral(" placeholder=\"\"  readonly>  \r\n        </dd>\r\n        <dt>\r\n           ");
            EndContext();
            BeginContext(536, 45, false);
#line 23 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
      Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(581, 87, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            <input type=\"text\" class=\"editable\" id=\"FN1\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 668, "\"", 718, 1);
#line 26 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
WriteAttributeValue("", 676, Html.DisplayFor(model => model.FirstName), 676, 42, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(719, 61, true);
            WriteLiteral("  placeholder=\"\" >\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(781, 44, false);
#line 29 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(825, 87, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            <input type=\"text\" class=\"editable\" id=\"LN1\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 912, "\"", 961, 1);
#line 32 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
WriteAttributeValue("", 920, Html.DisplayFor(model => model.LastName), 920, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(962, 59, true);
            WriteLiteral(" placeholder=\"\">\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1022, 48, false);
#line 35 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
       Write(Html.DisplayNameFor(model => model.StudentEmail));

#line default
#line hidden
            EndContext();
            BeginContext(1070, 87, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            <input type=\"text\" class=\"editable\" id=\"EM1\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1157, "\"", 1210, 1);
#line 38 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
WriteAttributeValue("", 1165, Html.DisplayFor(model => model.StudentEmail), 1165, 45, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1211, 60, true);
            WriteLiteral("  placeholder=\"\">\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1272, 51, false);
#line 41 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
       Write(Html.DisplayNameFor(model => model.StudentPassword));

#line default
#line hidden
            EndContext();
            BeginContext(1323, 89, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>  \r\n            <input type=\"text\" class=\"editable\" id=\"PW1\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1412, "\"", 1468, 1);
#line 44 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
WriteAttributeValue("", 1420, Html.DisplayFor(model => model.StudentPassword), 1420, 48, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1469, 59, true);
            WriteLiteral(" placeholder=\"\">\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1529, 40, false);
#line 47 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
       Write(Html.DisplayNameFor(model => model.Sque));

#line default
#line hidden
            EndContext();
            BeginContext(1569, 138, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n                <div>\r\n                    <select id=\"SQ1\" class=\"abc\" required>\r\n                        ");
            EndContext();
            BeginContext(1707, 44, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d486a271ab744e10b6f8dff9550dceb3", async() => {
                BeginContext(1726, 16, false);
#line 52 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
                                     Write(ViewBag.tuv.Sque);

#line default
#line hidden
                EndContext();
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
            EndContext();
            BeginContext(1751, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 53 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
                         foreach (var item2 in ViewBag.ghi)
                        {

#line default
#line hidden
            BeginContext(1841, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(1869, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6c2176005b147f99922b8cc4fb237c1", async() => {
                BeginContext(1897, 17, false);
#line 55 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
                                                  Write(item2.SecurityQue);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 55 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
                               WriteLiteral(item2.Qid);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1923, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 56 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
                        }

#line default
#line hidden
            BeginContext(1952, 101, true);
            WriteLiteral("                    </select>\r\n                </div>   \r\n\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2054, 40, false);
#line 62 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
       Write(Html.DisplayNameFor(model => model.Sans));

#line default
#line hidden
            EndContext();
            BeginContext(2094, 87, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            <input type=\"text\" class=\"editable\" id=\"SA1\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2181, "\"", 2226, 1);
#line 65 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
WriteAttributeValue("", 2189, Html.DisplayFor(model => model.Sans), 2189, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2227, 502, true);
            WriteLiteral(@" placeholder="" "">
        </dd>
        <dt>
            Education
        </dt>
        <dd>
            <table>
                <thead>
                    <tr>
                        <th class=""col-md-1"">Qualification</th>
                        <th class=""col-md-1"">Institute Name</th>
                        <th class=""col-md-1"">Passing Year</th>
                        <th class=""col-md-1"">Score</th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 81 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
                     foreach (var item in ViewBag.DynamicQual3)
                    {

#line default
#line hidden
            BeginContext(2817, 201, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            <div>\r\n                                <select id=\"QU1\"  class=\"abcd\" required>\r\n                                    ");
            EndContext();
            BeginContext(3018, 47, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e8ea5813af274b3ea560cc731dc3caf4", async() => {
                BeginContext(3038, 18, false);
#line 87 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
                                                  Write(item.Qualification);

#line default
#line hidden
                EndContext();
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
            EndContext();
            BeginContext(3065, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 88 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
                                     foreach (var item2 in ViewBag.jkl)
                                    {

#line default
#line hidden
            BeginContext(3179, 40, true);
            WriteLiteral("                                        ");
            EndContext();
            BeginContext(3219, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b41149a9b08747d0bc07e6919336f135", async() => {
                BeginContext(3247, 11, false);
#line 90 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
                                                              Write(item2.Qname);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 90 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
                                           WriteLiteral(item2.Qid);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3267, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 91 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
                                    }

#line default
#line hidden
            BeginContext(3308, 201, true);
            WriteLiteral("                                </select>\r\n                            </div>\r\n                        </td>\r\n                        <td class=\"col-md-1\"> <input type=\"text\" id=\"IN1\" class=\"editable1\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3509, "\"", 3531, 1);
#line 95 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
WriteAttributeValue("", 3517, item.InstName, 3517, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3532, 114, true);
            WriteLiteral(" placeholder=\"\"></td>\r\n                        <td class=\"col-md-1\"> <input type=\"text\" id=\"PY1\" class=\"editable1\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3646, "\"", 3668, 1);
#line 96 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
WriteAttributeValue("", 3654, item.PassYear, 3654, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3669, 114, true);
            WriteLiteral(" placeholder=\"\"></td>\r\n                        <td class=\"col-md-1\"> <input type=\"text\" id=\"SC1\" class=\"editable1\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3783, "\"", 3802, 1);
#line 97 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
WriteAttributeValue("", 3791, item.Score, 3791, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3803, 52, true);
            WriteLiteral(" placeholder=\"\"></td>\r\n\r\n                    </tr>\r\n");
            EndContext();
#line 100 "C:\Users\Mayur.Patil\Desktop\App1_withMVC_Copy\App1_withMVC\Views\Student\Edit.cshtml"
                    }

#line default
#line hidden
            BeginContext(3878, 262, true);
            WriteLiteral(@"                </tbody>
            </table>
        </dd>
    </dl>
</div>

<div class=Center align='center'>
    <button type=""submit"" id=""saveEditedProfile"" class=""container-fluid text-info bg-warning  "">Save</button>
</div>












");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<App1_withMVC.Models.StudentModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
