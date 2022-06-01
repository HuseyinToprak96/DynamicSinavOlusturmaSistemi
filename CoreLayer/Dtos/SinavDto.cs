using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class SinavDto
    {
        public int Id { get; set; }
        public int? KategoriId { get; set; }
        public string SinavAdi { get; set; }
        public int Sure { get; set; }
        public string Aciklama { get; set; }
        public double GecmeNotu { get; set; }
        public List<Sinav_KullaniciDto> GirecekOlanlar { get; set; } = new List<Sinav_KullaniciDto>();
        public List<SinavKategorisiDto> Kategoriler { get; set; } = new List<SinavKategorisiDto>();
     
    }
}
