using CoreLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class API_SinavService
    {
        private readonly HttpClient _httpClient;

        public API_SinavService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<JustSinavDto>> List()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<JustSinavDto>>>("Sinav/Listele");
            return response.Data;
        }
        public async Task<SinavDto> Find(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<SinavDto>>($"Employee/Find?id={id}");
            return response.Data;
        }
        public async Task<SinavDto> Add(SinavDto sinavDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Employee/Add", sinavDto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<SinavDto>>();
            return responseBody.Data;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Employee/Delete?id={id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> Update(SinavDto sinavDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Employee/Update", sinavDto);
            return response.IsSuccessStatusCode;
        }
    }


}
