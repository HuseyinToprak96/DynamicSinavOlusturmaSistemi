using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class CevapDto
    {
        public int Id { get; set; }
        public string cevap { get; set; }
        public bool DogruMu { get; set; }
        public int? SoruId { get; set; }

    }
}
