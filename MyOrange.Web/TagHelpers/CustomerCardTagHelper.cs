using Microsoft.AspNetCore.Razor.TagHelpers;
using MyOrange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOrange.Web.TagHelpers
{

    public class CustomerCardTagHelper : TagHelper
    {
        public Customer Customer { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string fullname = String.Format("{0} {1}", Customer.FirstName, Customer.LastName);

            // string interpolation
            string fullname2 = $"{Customer.FirstName} {Customer.LastName}";


            string content = $@"<div class='card shadow mb-4'>
    <div class='card-header'>
        <h6 class='text-primary'>Overview</h6>
    </div>

    <div class='col-md-8'>
        <div class='card-body'>
            <h3 class='card-title'>{Customer.FirstName} {Customer.LastName}</h3>
            <p class='card-text'>{Customer.Email}</p>
        </div>
    </div>
</div>";


            output.Attributes.SetAttribute("class", "shadow mb-4");
            output.TagName = "div";
            output.Content.SetHtmlContent(content);


        }
    }
}
