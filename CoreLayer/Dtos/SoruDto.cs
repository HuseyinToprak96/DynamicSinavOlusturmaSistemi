using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class SoruDto
    {
        public int Id { get; set; }
        public string soru { get; set; }
        public int? KategoriId { get; set; }
        public SoruTipi soruTipi { get; set; }
        public List<CevapDto> cevaplar { get; set; } = new List<CevapDto>();
    }
}
