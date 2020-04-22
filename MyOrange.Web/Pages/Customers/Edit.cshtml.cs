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
    public class EditModel : PageModel
    {
        private readonly ICustomerService customerService;
        private readonly ICountryService countryService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditModel(ICustomerService customerService, ICountryService countryService, IWebHostEnvironment webHostEnvironment)
        {
            this.customerService = customerService;
            this.countryService = countryService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }
        public SelectList Countries { get; set; }

        public string Message { get; set; }


        [PageRemote(
            HttpMethod = "post", 
            PageHandler = "CheckEmail", 
            ErrorMessage = "Email Duplicated",
            AdditionalFields = "__RequestVerificationToken")]
        [BindProperty]
        public string Email { get; set; }


        // POST 
        public IActionResult OnPostCheckEmail()
        {
            var existing = new[] { "marcin.sulecki@gmail.com", "marcin.sulecki@akademia.altkom.pl", "marcin.sulecki@altkom.pl" };

            var valid = !existing.Contains(Email);

            return new JsonResult(valid);
        }

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

        public void OnPostSavePreferences()
        {
            if (Notify)
            {
                Message = "You have turned on email notifications";
            }
            else
            {
                Message = "You have turned off email notifications";
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // string file = Path.GetFileName(Photo.FileName);

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


            customerService.Update(Customer);

            return RedirectToPage("./Index");

        }
    }
}