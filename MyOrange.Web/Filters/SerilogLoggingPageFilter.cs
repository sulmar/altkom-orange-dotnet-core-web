using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyOrange.Web.Filters
{
    public class SerilogLoggingPageFilter : IPageFilter
    {
        private readonly IDiagnosticContext _diagnosticContext;
        public SerilogLoggingPageFilter(IDiagnosticContext diagnosticContext)
        {
            _diagnosticContext = diagnosticContext;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            var name = context.HandlerMethod?.Name ?? context.HandlerMethod?.MethodInfo.Name;
            if (name != null)
            {
                _diagnosticContext.Set("RazorPageHandler", name);
            }
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }
    }


  
}
