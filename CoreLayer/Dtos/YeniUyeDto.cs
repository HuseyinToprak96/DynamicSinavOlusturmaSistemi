using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class YeniUyeDto
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Numara { get; set; }
        public Yetki yetki { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
