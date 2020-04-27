using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOrange.Web.Filters
{
    public class MyPageFilter : IPageFilter
    {
        private readonly IWebHostEnvironment env;

        public MyPageFilter(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            if (context.HandlerMethod.HttpMethod == "Get" && context.HandlerMethod.MethodInfo.Name == "OnGet")
            {
                // code placed here will only execute if the OnGet() method has been selected

                context.HttpContext.Response.Headers.Add("environment", env.EnvironmentName);
            }
        }
    }
}
