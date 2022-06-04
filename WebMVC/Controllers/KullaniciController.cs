using CoreLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Filters;
using WebMVC.Services;

namespace WebMVC.Controllers
{
    public class KullaniciController : Controller
    {
        //private readonly KullaniciAPI _kullanici;

        //public KullaniciController(KullaniciAPI kullanici)
        //{
        //    _kullanici = kullanici;
        //}
        public IActionResult Index()
        {
            return View();
        }
        [AdminFilter]
        public JsonResult Liste()
        {
            return Json("Kullanicilar");
        }
        [OgretmenFilter]
        public JsonResult OgrenciListesi()
        {
            return Json("Öğrenci Listesi");
        }
        [AdminFilter]
        public JsonResult OgretmenListesi()
        {
            return Json("Ogretmen Listesi");
        }
        [LoginFilter]
        public IActionResult Profil()
        {
            var id = HttpContext.Session.GetInt32("ID");

            return View();
        }
        [AdminFilter]
        public IActionResult KisiEkle()
        {
            return View();
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult KisiEkle(YeniUyeDto yeniUyeDto)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

    }
}
