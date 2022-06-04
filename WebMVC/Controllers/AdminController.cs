using CoreLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Filters;

namespace WebMVC.Controllers
{
    [AdminFilter]
    public class AdminController : Controller
    {
        public IActionResult OgretmenListesi()
        {
            return View();
        }
        public JsonResult OgretmenEkle()
        {
            return Json("eklendi");
        }
        public JsonResult OgretmenSil(int id)
        {
            return Json("silindi");
        }
        public IActionResult SınavKategorileri()
        {
            return View();
        }
        public JsonResult SınavKategorisiEkle(KategoriDto kategoriDto)
        {
            return Json("eklendi");
        }
        public JsonResult SınavKategorisiSil(int id)
        {
            return Json("eklendi");
        }

    }
}
