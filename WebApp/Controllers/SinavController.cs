using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class SinavController : Controller
    {
        private readonly API_SinavService _SinavService;

        public SinavController(API_SinavService sinavService)
        {
            _SinavService = sinavService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _SinavService.List());
        }
    }
}
