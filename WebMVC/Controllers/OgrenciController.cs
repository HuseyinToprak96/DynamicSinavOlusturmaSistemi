using CoreLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Filters;

namespace WebMVC.Controllers
{
    
    public class OgrenciController : Controller
    {
        [AdminFilter]
        [OgretmenFilter]
        public IActionResult Liste()
        {
            return View();
        }
        [AdminFilter]
        public IActionResult OgrenciEkle()
        {
            return View();
        }
        [AdminFilter]
        [HttpPost]
        public IActionResult OgrenciEkle(KullaniciDto kullaniciDto)
        {
            return View();
        }
        [AdminFilter]
        public IActionResult KayitSil(int id)
        {
            return RedirectToAction("Liste");
        }
        [OgrenciFilter]
        public IActionResult Profilim()
        {
            int id = (int)HttpContext.Session.GetInt32("ID");
            return View();
        }
    }
}
