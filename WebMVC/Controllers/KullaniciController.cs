﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class KullaniciController : Controller
    {
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
    }
}
