using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
   public class SinavSonucu:BaseEntity
    {
        [ForeignKey("sinav_Kullanici")]
        public int SinavKullaniciId { get; set; }
        public int DogruSayisi { get; set; }
        public int YanlisSayisi { get; set; }
        public int BosSayisi { get; set; }
        public double Puan { get; set; }
        public Sinav_Kullanici sinav_Kullanici { get; set; }

    }
}
