﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class KategoriDto
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public List<SinavDto> Sinavlar { get; set; }
    }
}
