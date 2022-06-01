using CoreLayer.Dtos;
using CoreLayer.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly IKullaniciService _kullaniciService;

        public LoginController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }
        [HttpGet]
        public async Task<IActionResult> Giris(LoginDto loginDto)
        {
            return CreateActionResult(CustomResponseDto<GirenDto>.success(200,await _kullaniciService.Giris(loginDto.KullaniciAdi,loginDto.Sifre)));
        }
    }
}
