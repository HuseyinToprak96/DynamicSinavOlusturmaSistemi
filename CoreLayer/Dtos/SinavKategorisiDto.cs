using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class SinavKategorisiDto
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public int? SinavId { get; set; }
        public List<SoruDto> Sorular { get; set; } = new List<SoruDto>();
    }
}
