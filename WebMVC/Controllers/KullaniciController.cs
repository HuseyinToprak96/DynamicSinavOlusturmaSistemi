using CoreLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public JsonResult Liste()
        {
            return Json("Kullanicilar");
        }
        public JsonResult OgrenciListesi()
        {
            return Json("Öğrenci Listesi");
        }
        public JsonResult OgretmenListesi()
        {
            return Json("Ogretmen Listesi");
        }
        public IActionResult Profil()
        {
            var id = HttpContext.Session.GetInt32("ID");

            return View();
        }
        public IActionResult KisiEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult KisiEkle(YeniUyeDto yeniUyeDto)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

    }
}
