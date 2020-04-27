using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyOrange.IServices;

namespace MyOrange.Web.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ICustomerService customerService;
        private readonly IDocumentService documentService;

        [BindProperty]
        public int ActiveCustomersCount { get; private set; }

        [BindProperty]
        public int DocumentsCount { get; private set; }

        public DashboardModel(ICustomerService customerService, IDocumentService documentService)
        {
            this.customerService = customerService;
            this.documentService = documentService;
        }

        public void OnGet()
        {
            ActiveCustomersCount = customerService.GetActive();
            DocumentsCount = documentService.GetCount();

        }

        public void OnGetGenerate()
        {

        }

        public void OnGetAction()
        {

        }

        public void OnGetAnotherAction()
        {

        }

        public void OnGetSomethingElseAction()
        {

        }
    }
}