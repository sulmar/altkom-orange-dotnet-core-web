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
    public class DetailsModel : PageModel
    {
        private readonly ICustomerService customerService;

        public Customer Customer { get; set; }

        public DetailsModel(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public void OnGet(int id)
        {
            Customer = customerService.Get(id);
        }
    }
}