using CoreLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Services;

namespace WebMVC.Methods
{
    public class SinavMethods
    {
        public static SinavDto _sinav;
        private readonly SinavAPI _SinavService;

        public SinavMethods(SinavAPI sinavService)
        {
            _SinavService = sinavService;
        }

        public void SinavOlustur(JustSinavDto dto)
        {
            _sinav.Aciklama = dto.Aciklama;
            _sinav.GecmeNotu = dto.GecmeNotu;
            _sinav.SinavAdi = dto.SinavAdi;
            _sinav.Sure = dto.Sure;
            _sinav.KategoriId = dto.KategoriId;
        }
        public void SinavaKategoriEkle(List<SinavKategorisiDto> dtos)
        {
            _sinav.Kategoriler = dtos;
        }
        public void KategoriyeSoruEkle(SoruDto soruDto)
        {
            var kategori = _sinav.Kategoriler.Where(x => x.Id == soruDto.KategoriId).SingleOrDefault();
            kategori.Sorular.Add(soruDto);
        }
        public async Task Kaydet()
        {
            await _SinavService.Add(_sinav);
        }
    }
}
