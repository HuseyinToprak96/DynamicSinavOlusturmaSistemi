using CoreLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebMVC.Services
{
    public class KullaniciAPI
    {

        private readonly HttpClient _httpClient;

        public KullaniciAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<KullaniciDto>> List()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<KullaniciDto>>>("Kullanici/Listele");
            return response.Data;
        }
        public async Task<KullaniciDto> Find(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<KullaniciDto>>($"Kullanici/Bul?id={id}");
            return response.Data;
        }
        public async Task<KullaniciDto> Add(KullaniciDto kullaniciDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Kullanici/Ekle", kullaniciDto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<KullaniciDto>>();
            return responseBody.Data;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Kullanici/Kaldir?id={id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> Update(SinavDto sinavDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Kullanici/Guncelle", sinavDto);
            return response.IsSuccessStatusCode;
        }
        public async Task<GirenDto> Login(LoginDto loginDto)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<GirenDto>>($"Kullanici/loginDto?={loginDto}");
            return response.Data;
        }

    }
}
