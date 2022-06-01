using CoreLayer.Dtos;
using CoreLayer.Models;
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

        public static SinavDto _sinav = new SinavDto();

        public SinavController()
        {
            //SinavAPI sinavService
            //_SinavService = sinavService;
           // _sinav = new SinavDto();
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
            _sinav.Aciklama = justSinav.Aciklama;
            _sinav.GecmeNotu = justSinav.GecmeNotu;
            _sinav.Sure = justSinav.Sure;
            _sinav.KategoriId = justSinav.KategoriId;
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
        public int KategoriEkle(string KategoriAdi)
        {
            //dtos[0].
            _sinav.Kategoriler.Add(new SinavKategorisiDto { KategoriAdi=KategoriAdi });
            return (_sinav.Kategoriler.Count-1);
        }
        public bool KategoriKaldir(int indis)
        {
            _sinav.Kategoriler.Remove(_sinav.Kategoriler[indis]);
            return true;
        }
        public static void KategoriyeSoruEkle(SoruDto soruDto)
        {
            var kategori = _sinav.Kategoriler.Where(x => x.Id == soruDto.KategoriId).SingleOrDefault();
            kategori.Sorular.Add(soruDto);
        }

        public JsonResult SoruTipleri()
        {
            return Json(SoruTipi.GetNames(typeof(SoruTipi)));
        }
        public static int ind = new int();
        [HttpPost]
        public int SoruEkle(int soruTipi,int katIndis,string soru)
        {
            _sinav.Kategoriler[katIndis].Sorular.Add(new SoruDto { soruTipi = (SoruTipi)soruTipi, soru = soru });
            ind= _sinav.Kategoriler[katIndis].Sorular.Count - 1;
            return _sinav.Kategoriler[katIndis].Sorular.Count - 1;
        }
        public int Indis(int katId)
        {
            return _sinav.Kategoriler[katId].Sorular.Count - 1;
        }
        //[HttpPost]
        //public int SoruuEkle(SoruDto soru)
        //{
        //    _sinav.Kategoriler[0].Sorular.Add(soru);
        //    return _sinav.Kategoriler[0].Sorular.Count - 1;
        //}
        [HttpPost]
        public void CevapEkle(int katIndis,int soruIndis,string cevap,bool dogruMu)
        {
            _sinav.Kategoriler[katIndis].Sorular[ind].cevaplar.Add(new CevapDto { cevap = cevap, DogruMu = dogruMu });
        }
        [HttpPost]
        public JsonResult Guncelle()
        {
           return Json(_sinav);
        }
        //public async Task Kaydet()
        //{
        //    await _SinavService.Add(_sinav);
        //}
        [HttpPost]
        public bool ekleSoru(SoruDto sor,int katIndis)
        {
            _sinav.Kategoriler[katIndis].Sorular.Add(sor);
            return true;
        }
        
        public IActionResult SinavGiris()
        {
            return View(_sinav);
        }
        public JsonResult Sorular()
        {
            return Json(_sinav.Kategoriler);
        }
    }
}
