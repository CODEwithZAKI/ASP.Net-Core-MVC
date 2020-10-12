using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
namespace CODEwithZAKI.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.name = "zakicade";
            ViewBag.Data = data;
            return View();
        }
        public ViewResult AboutUs()
        {
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
