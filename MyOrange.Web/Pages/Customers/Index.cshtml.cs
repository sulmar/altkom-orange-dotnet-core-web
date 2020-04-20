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
    public class IndexModel : PageModel
    {
        private readonly ICustomerService customerService;

        public IndexModel(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public IList<Customer> Customers { get; set; }

        public void OnGet()
        {
            Customers = customerService.Get();
        }
    }
}