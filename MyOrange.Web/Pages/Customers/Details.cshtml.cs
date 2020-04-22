using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyOrange.IServices;
using MyOrange.Models;
using Microsoft.AspNetCore.Http;

namespace MyOrange.Web.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomerService customerService;

        public Customer Customer { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Message { get; set; }
        
        [TempData]
        public string MessageTemp { get; set; }

        public string MessageSession { get; set; }

        public DetailsModel(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public void OnGet(int id)
        {
            MessageSession = HttpContext.Session.GetString("key1");
            //HttpContext.Session.Remove("key1");
            //HttpContext.Session.Clear();

            Customer = customerService.Get(id);

            var message = TempData.Peek("MessageTemp");

            TempData.Keep("MessageTemp");
            TempData.Remove("MessageTemp");

            TempData.Keep();
            TempData.Clear();

        }
    }
}