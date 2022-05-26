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
    public class SinavController : BaseController
    {
        private readonly ISinavService _service;
        private readonly IMapper _mapper;
        public SinavController(ISinavService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Listele()
        {
            return CreateActionResult(CustomResponseDto<List<SinavDto>>.success(200, _mapper.Map<List<SinavDto>>(await _service.getAllAsync())));
        }
        [HttpGet]
        public async Task<IActionResult> Bul(int id)
        {
            return CreateActionResult(CustomResponseDto<SinavDto>.success(200, _mapper.Map<SinavDto>(await _service.getByIdAsync(id))));
        }
        [HttpGet]
        public async Task<IActionResult> Sinav(int id)
        {
            return CreateActionResult(await _service.Sinav(id));
        }
        [HttpGet]
        public async Task<IActionResult> SinavaGireceklerListesi(int id)
        {
            return CreateActionResult(CustomResponseDto<List<KullaniciDto>>.success(200, _mapper.Map<List<KullaniciDto>>(await _service.GirecekListesi(id))));
        }
        [HttpPost]
        public async Task<IActionResult> Ekle(SinavDto sinavDto)
        {
            return CreateActionResult(CustomResponseDto<Sinav>.success(200, await _service.AddAsync(_mapper.Map<Sinav>(sinavDto))));
        }
        [HttpPost]
        public async Task<IActionResult> HepsiniEkle(IEnumerable<Sinav> sinavlar)
        {
            return CreateActionResult(CustomResponseDto<IEnumerable<Sinav>>.success(200, await _service.AddRangeAsync(sinavlar)));
        }
        [HttpDelete]
        public async Task<IActionResult> Kaldir(int id)
        {
            await _service.Remove(await _service.getByIdAsync(id));
            return CreateActionResult(CustomResponseDto<NoContentDto>.success(200));
        }
        [HttpPut]
        public async Task<IActionResult> Guncelle(Sinav sinav)
        {
            await _service.Update(sinav);
            return CreateActionResult(CustomResponseDto<NoContentDto>.success(200));
        }
    }
}
