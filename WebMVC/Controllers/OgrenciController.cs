using CoreLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class OgrenciController : Controller
    {
        public IActionResult Liste()
        {
            return View();
        }
        public IActionResult OgrenciEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OgrenciEkle(KullaniciDto kullaniciDto)
        {
            return View();
        }
        public IActionResult KayitSil(int id)
        {
            return RedirectToAction("Liste");
        }
    }
}
