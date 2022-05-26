using CoreLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Methods;

namespace WebMVC.ViewModels
{
    public class VM_Sinav
    {
        public SinavDto sinavDto { get; set; }
        public JustSinavDto JustSinav { get; set; }
        public SinavMethods methods { get; set; }
    }
}
