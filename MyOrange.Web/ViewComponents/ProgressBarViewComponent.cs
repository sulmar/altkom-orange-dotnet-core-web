using Microsoft.AspNetCore.Mvc;
using MyOrange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOrange.Web.ViewComponents
{
    public class ProgressBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string title, int value)
        {
            return View(new Project { Title = title , Value = value });
        }
    }
}
