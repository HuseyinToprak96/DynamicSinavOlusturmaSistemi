using CoreLayer.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.KodUretme
{
    public class KodUretme
    {
        private readonly IKullaniciService _kullaniciService;
        public KodUretme(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }
        public async Task<int> NoUret()
        {
            Random random = new Random();
            var Numaralar = await _kullaniciService.allNumber();
            int yeniNo;
            string str="";
            while (true) { 
            yeniNo = random.Next(1, 99999);
                for (int i = 0; i < 5-yeniNo.ToString().Length; i++)
                    str += 0;

                str+= yeniNo.ToString();
                if (!Numaralar.Contains(str))
                    break;
}
            return yeniNo;

        }
    }
}
