using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public enum Yetki { Admin=1,Ogretmen=2,Ogrenci=3}
   public class Kullanici:BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Numara { get; set; }
        public Yetki yetki { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public List<Sinav_Kullanici> KullanicininSinavlari { get; set; }
        public List<Sinav> OlusturduguSinavlar { get; set; }
    }
}
