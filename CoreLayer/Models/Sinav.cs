using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
   public class Sinav:BaseEntity
    {
        public string SinavAdi { get; set; }
        public int? KategoriId { get; set; }
        public int Sure { get; set; }
        public string Aciklama { get; set; }
        public double GecmeNotu { get; set; }
        public List<SinavKategorisi> SinavKategorileri { get; set; }
        public List<Sinav_Kullanici> Sinav_Kullanicilari { get; set; }
        public Kategori kategori { get; set; }
        public Kullanici Olusturan { get; set; }

    }
}
