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
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }

        private readonly ICustomerService customerService;

        public DeleteModel(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public IActionResult OnGet(int id)
        {
            Customer = customerService.Get(id);

            if (Customer==null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            customerService.Remove(Customer.Id);

            return RedirectToPage("Index");
        }
    }
}