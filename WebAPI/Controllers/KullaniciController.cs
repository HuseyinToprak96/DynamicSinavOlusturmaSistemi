using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Interfaces.Service;
using CoreLayer.Models;
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
    public class KullaniciController : BaseController
    {
        private readonly IKullaniciService _service;
        private readonly IMapper _mapper;
        public KullaniciController(IKullaniciService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Listele()
        {
            return CreateActionResult(CustomResponseDto<List<KullaniciDto>>.success(200, _mapper.Map<List<KullaniciDto>>(await _service.getAllAsync())));
        }
        [HttpGet]
        public async Task<IActionResult> Bul(int id)
        {
            return CreateActionResult(CustomResponseDto<KullaniciDto>.success(200, _mapper.Map<KullaniciDto>(await _service.getByIdAsync(id))));
        }
        [HttpGet]
        public async Task<IActionResult> KullanicininSinavlari(int id)
        {
            return CreateActionResult(await _service.KullanicininSinavlari(id));
        }
        [HttpGet]
        public async Task<IActionResult> OgrenciListesi()
        {
            return CreateActionResult(await _service.OgrenciListesi());
        }
        [HttpPost]
        public async Task<IActionResult> Ekle(KullaniciDto kullaniciDto)
        {
            return CreateActionResult(CustomResponseDto<Kullanici>.success(200, await _service.AddAsync(_mapper.Map<Kullanici>(kullaniciDto))));
        }
        [HttpDelete]
        public async Task<IActionResult> Kaldir(int id)
        {
            await _service.Remove(await _service.getByIdAsync(id));
            return CreateActionResult(CustomResponseDto<NoContentDto>.success(200));
        }
        [HttpPut]
        public async Task<IActionResult> Guncelle(KullaniciDto kullaniciDto)
        {
            await _service.Update(_mapper.Map<Kullanici>(kullaniciDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.success(200));
        }
    }
}
