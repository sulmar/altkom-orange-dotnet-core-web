using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyOrange.IServices;
using MyOrange.Models;

namespace MyOrange.Web.Pages.Customers
{

    [BindProperties(SupportsGet = true)]
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