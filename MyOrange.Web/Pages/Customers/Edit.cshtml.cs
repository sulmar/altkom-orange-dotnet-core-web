using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyOrange.IServices;
using MyOrange.Models;

namespace MyOrange.Web.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ICustomerService customerService;
        private readonly ICountryService countryService;

        public EditModel(ICustomerService customerService, ICountryService countryService)
        {
            this.customerService = customerService;
            this.countryService = countryService;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public SelectList Countries { get; set; }

        public IActionResult OnGet(int id)
        {
            Countries = new SelectList(countryService.Get());

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