using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyOrange.IServices;
using MyOrange.Models;

namespace MyOrange.Web.Pages.Customers
{

    [BindProperties(SupportsGet = true)]
     // [Authorize(Roles = "Developer, Trainer")]
    public class IndexModel : PageModel
    {
        private readonly ICustomerService customerService;

        //[BindProperty(SupportsGet = true)]
        public string Country { get; set; }

        //[BindProperty(SupportsGet = true)]
        public string FirstName { get; set; }

        public IndexModel(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public IList<Customer> Customers { get; set; }
      
        public void OnGet()
        {
            var roles = this.User.FindAll(ClaimTypes.Role);

            var mobilephone = this.User.FindFirstValue(ClaimTypes.MobilePhone);

            // smsService.Send(mobilephone, "Hello");

            if (string.IsNullOrEmpty(Country) && string.IsNullOrEmpty(FirstName))
            {
                Customers = customerService.Get();
            }
            else
            {
                Customers = customerService.Get(Country, FirstName);
            }

        }
    }
}