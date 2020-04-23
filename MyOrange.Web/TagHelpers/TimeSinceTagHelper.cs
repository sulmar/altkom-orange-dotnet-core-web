using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace MyOrange.Web.TagHelpers
{
    [HtmlTargetElement("time-since")]
    public class TimeSinceTagHelper : TagHelper
    {
        public string CompareDateTime { get; set; }

        private readonly ITimeSinceService timeSinceService;

        public TimeSinceTagHelper(ITimeSinceService timeSinceService)
        {
            this.timeSinceService = timeSinceService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetContent(timeSinceService.TimeSince(Convert.ToDateTime(CompareDateTime)));
        }
    }
}
