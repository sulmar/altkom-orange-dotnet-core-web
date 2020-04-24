using Microsoft.AspNetCore.Mvc;
using MyOrange.IServices;

namespace MyOrange.Web.ViewComponents
{
    public class DocumentsViewComponent : ViewComponent
    {
        private readonly IDocumentService documentService;

        public DocumentsViewComponent(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        public IViewComponentResult Invoke(int customerId)
        {
            var documents = documentService.Get(customerId);

            return View(documents);
        }
    }


}
