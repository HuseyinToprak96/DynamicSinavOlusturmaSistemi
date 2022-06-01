using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapping
{
   public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Kategori, KategoriDto>().ReverseMap()
                .ForMember(x=>x.Sinavlar,opt=>opt.MapFrom(x=>x.Sinavlar));
            CreateMap<Sinav, SinavDto>().ReverseMap()
                .ForMember(x=>x.SinavKategorileri,opt=>opt.MapFrom(x=>x.Kategoriler))
                .ForMember(x=>x.Sinav_Kullanicilari,opt=>opt.MapFrom(x=>x.GirecekOlanlar));
            CreateMap<Soru, SoruDto>().ReverseMap()
                .ForMember(x=>x.Cevaplar,opt=>opt.MapFrom(x=>x.cevaplar));
            CreateMap<Cevap, CevapDto>().ReverseMap();
            CreateMap<SinavKategorisi, SinavKategorisiDto>().ReverseMap()
                .ForMember(x=>x.Sorular,opt=>opt.MapFrom(x=>x.Sorular));
            CreateMap<Kullanici, KullaniciDto>();
            CreateMap<Kullanici, LoginDto>().ReverseMap();
            CreateMap<Kullanici, GirenDto>().ReverseMap();
            CreateMap<Sinav, JustSinavDto>();
            CreateMap<Sinav_Kullanici, Sinav_KullaniciDto>().ReverseMap();
        }
    }
}
