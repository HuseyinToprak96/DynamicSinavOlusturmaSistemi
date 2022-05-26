using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Cevap:BaseEntity
    {
        public string cevap { get; set; }
        public bool DogruMu { get; set; }
        public int? SoruId { get; set; }
        public Soru soru { get; set; }
    }
}
