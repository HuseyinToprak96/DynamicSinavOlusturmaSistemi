using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
   public class Sinav_Kullanici:BaseEntity
    {
        public int KullaniciId { get; set; }
        public int SinavId { get; set; }
        public SinavSonucu sinavSonucu { get; set; }
        public Sinav sinav { get; set; }
        public Kullanici kullanici { get; set; }
    }
}
