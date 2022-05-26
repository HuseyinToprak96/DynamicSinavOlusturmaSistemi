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
    public class KategoriController :BaseController
    {

        private readonly IService<Kategori> _service;
        private readonly IMapper _mapper;

        public KategoriController(IService<Kategori> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> Bul(int id)
        {
            return CreateActionResult(CustomResponseDto<Kategori>.success(200, await _service.getByIdAsync(id)));
        }

        [HttpGet]
        public async Task<IActionResult> Listele()
        {
            var dto = _mapper.Map<List<KategoriDto>>(await _service.getAllAsync());
            return CreateActionResult(CustomResponseDto<List<KategoriDto>>.success(200, dto));
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(KategoriDto kategoriDto)
        {
            var kategori = _mapper.Map<Kategori>(kategoriDto);

            var result = await _service.AddAsync(kategori);
            return CreateActionResult(CustomResponseDto<Kategori>.success(200, result));
        }

        [HttpDelete]
        public async Task<IActionResult> Kaldir(int id)
        {
            await _service.Remove(await _service.getByIdAsync(id));
            return CreateActionResult(CustomResponseDto<NoContentDto>.success(200));
        }

        [HttpPut]
        public async Task<IActionResult> Guncelle(KategoriDto kategoriDto)
        {
            await _service.Update(_mapper.Map<Kategori>(kategoriDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.success(200));
        }
    }
}
