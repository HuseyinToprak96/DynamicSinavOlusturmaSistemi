using CoreLayer.Dtos;
using CoreLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Services;

namespace WebMVC.Controllers
{
    public class IOController : Controller
    {
        //private readonly KullaniciAPI _kullaniciAPI;

        //public IOController(KullaniciAPI kullaniciAPI)
        //{
        //    _kullaniciAPI = kullaniciAPI;
        //}

        public IActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Giris(LoginDto loginDto)
        {
            //          var result=await _kullaniciAPI.Login(loginDto);
            //            if (result!=null)
            //            {
            //                HttpContext.Session.SetString("yetki",((Yetki)result.yetki).ToString());
            //                HttpContext.Session.SetInt32("ID", result.Id);
            //return RedirectToAction("Index","Sayfa");
            //            }
            ViewBag.Hata = "Hatalı kullanıcı adı veya şifre";
            return View();

    }
    public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Sayfa");
        }
    }
}
