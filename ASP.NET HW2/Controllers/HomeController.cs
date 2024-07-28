using ASP.NET_HW2.Entities;
using ASP.NET_HW2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace ASP.NET_HW2.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
           
            return View();
        }

        
       
    }
}
