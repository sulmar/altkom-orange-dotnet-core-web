using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyOrange.IServices;
using MyOrange.Models;

namespace MyOrange.Web.Pages.Documents
{
    public class IndexModel : PageModel
    {
        private readonly IDocumentService documentService;

        public IList<Document> Documents { get; set; }

        public IndexModel(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        public void OnGet()
        {
            Documents = documentService.Get();

        }
    }
}