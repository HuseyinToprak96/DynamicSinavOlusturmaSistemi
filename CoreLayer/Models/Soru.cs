using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public enum SoruTipi { Test=1, ÇoktanSeçmeli=2}
   public class Soru:BaseEntity
    {
        public string soru { get; set; }
        public int? KategoriId { get; set; }
        public SoruTipi soruTipi { get; set; }
        public SinavKategorisi sinavKategorisi { get; set; }
        public List<Cevap> Cevaplar { get; set; }
    }
}
