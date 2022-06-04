using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Filters;

namespace WebMVC.Controllers
{
    [OgrenciFilter]
    public class OnlineSinavController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
