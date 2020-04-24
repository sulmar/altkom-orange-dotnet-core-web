using Microsoft.AspNetCore.Mvc;
using MyOrange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOrange.Web.ViewComponents
{
    public class CustomerCardViewComponent : ViewComponent
    {


        public IViewComponentResult Invoke(Customer customer)
        {
            return View(customer);
        }
    }


}
