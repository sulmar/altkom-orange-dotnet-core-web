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
    public class EditModel : PageModel
    {
        private readonly ICustomerService customerService;

        public EditModel(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnGet(int id)
        {
            Customer = customerService.Get(id);

            if (Customer == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            customerService.Update(Customer);

            return RedirectToPage("./Index");

        }
    }
}