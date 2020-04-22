using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyOrange.IServices;
using MyOrange.Models;

namespace MyOrange.Web.Pages.Customers
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }

        private readonly ICustomerService customerService;
        private readonly ICountryService countryService;
        private readonly IWebHostEnvironment webHostEnvironment;

        [BindProperty]
        public IFormFile Photo { get; set; }

        public SelectList Countries { get; set; }

        public CreateModel(ICustomerService customerService, ICountryService countryService, IWebHostEnvironment webHostEnvironment)
        {
            this.customerService = customerService;
            this.countryService = countryService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
             Countries = new SelectList(countryService.Get());
            // niezłe
            // todo:

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Photo != null)
            {
                string file = Guid.NewGuid().ToString("N") + new FileInfo(Photo.FileName).Extension;
                var filename = Path.Combine(webHostEnvironment.WebRootPath, "uploads", file);
                using (var stream = new FileStream(filename, FileMode.Create))
                {
                    Photo.CopyTo(stream);
                }

                Customer.Photo = Path.Combine("/uploads", file);
            }

            customerService.Add(Customer);

            return RedirectToPage("Index");
        }
    }
}