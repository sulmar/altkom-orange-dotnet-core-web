using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOrange.Web.TagHelpers
{
    public class ProgressBarTagHelper : TagHelper
    {
        public string Title { get; set; }
        public int Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // C# 8.0
            string style = Value switch
            {
                var v when v >= 100 => "bg-success",
                var v when v >= 80 => "bg-info",
                var v when v >= 60 => string.Empty,
                var v when v >= 40 => "bg-warning",
                _ => "bg-danger" // default value
            };

            string content = $@"<div class='mb-4'>
                    <h4 class='small font-weight-bold'>{Title}<span class='float-right'>{Value}%</span></h4>
                    <div class='progress mb-4'>
                        <div class='progress-bar {style}' role='progressbar' style='width: {Value}%' aria-valuenow='{Value}' aria-valuemin='0' aria-valuemax='100'></div>
                    </div>
                </div>";

            output.Attributes.SetAttribute("class", "mb-4");
            output.TagName = "div";
            output.Content.SetHtmlContent(content);
        }
    }
}
