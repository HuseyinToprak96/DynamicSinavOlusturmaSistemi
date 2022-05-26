using CoreLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Services;

namespace WebMVC.Controllers
{
    public class SinavController : Controller
    {
       // private readonly SinavAPI _SinavService;

        public static SinavDto _sinav;

        public SinavController()
        {
            //SinavAPI sinavService
            //_SinavService = sinavService;
            _sinav = new SinavDto();
         //   _sinav.Kategoriler = new List<SinavKategorisiDto>();
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _SinavService.List());
        //}
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SinavEkle(JustSinavDto justSinav)
        {
            _sinav.SinavAdi = justSinav.SinavAdi;
            //_sinav.Aciklama = justSinav.Aciklama;
            //_sinav.GecmeNotu = justSinav.GecmeNotu;
            //_sinav.Sure = justSinav.Sure;
            //_sinav.KategoriId = justSinav.KategoriId;

            return Json(_sinav.SinavAdi);
        }
        public static void SinavOlustur()
        {
            //_sinav.Aciklama = _justSinav.Aciklama;
            //_sinav.GecmeNotu = _justSinav.GecmeNotu;
            //_sinav.SinavAdi =_.SinavAdi;
            //_sinav.Sure = dto.Sure;
            //_sinav.KategoriId = dto.KategoriId;
        }
        public JsonResult KategoriEkle(string KategoriAdi)
        {
            //dtos[0].
            _sinav.Kategoriler.Add(new SinavKategorisiDto { KategoriAdi=KategoriAdi });
            return Json(_sinav.Kategoriler.Count-1);
        }
        public static void KategoriyeSoruEkle(SoruDto soruDto)
        {
            var kategori = _sinav.Kategoriler.Where(x => x.Id == soruDto.KategoriId).SingleOrDefault();
            kategori.Sorular.Add(soruDto);
        }
        //public async Task Kaydet()
        //{
        //    await _SinavService.Add(_sinav);
        //}



    }
}
