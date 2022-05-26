using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class SinavKategorisi:BaseEntity
    {
        public string KategoriAdi { get; set; }
        public int? SinavId { get; set; }
        public Sinav sinav { get; set; }
        public List<Soru> Sorular { get; set; }
    }
}
