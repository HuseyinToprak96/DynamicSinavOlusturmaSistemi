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
            CreateMap<Sinav, SinavDto>()
                .ForMember(x=>x.Kategoriler,opt=>opt.MapFrom(x=>x.SinavKategorileri));
            CreateMap<Soru, SoruDto>()
                .ForMember(x=>x.cevaplar,opt=>opt.MapFrom(x=>x.Cevaplar));
            CreateMap<Cevap, CevapDto>();
            CreateMap<SinavKategorisi, SinavKategorisiDto>()
                .ForMember(x=>x.Sorular,opt=>opt.MapFrom(x=>x.Sorular));
            CreateMap<Kullanici, KullaniciDto>();
            CreateMap<Kullanici, LoginDto>().ReverseMap();
            CreateMap<Sinav, JustSinavDto>();
        }
    }
}
