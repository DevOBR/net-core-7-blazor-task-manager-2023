using System;
using System.Text.Json;
using TaskManager.Share.Models;

namespace TaskManager.Frontend.WebRepository
{
    public class WebRepository : IWebRepository
    {
        private readonly HttpClient _httpClient;

        public WebRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<T>> GetAsync<T>(string url)
        {
            var responseHttp = await _httpClient.GetAsync(url);

            if (!responseHttp.IsSuccessStatusCode)
            {
                return new Response<T>
                {
                    Message = "Fail to get results.",
                    IsSuccess = false
                };
            }

            var responseString = await responseHttp.Content.ReadAsStringAsync();
            var responseJson = JsonSerializer.Deserialize<T>(responseString);

            return new Response<T>
            {
                Result = responseJson,
                IsSuccess = true
            };
        }
    }
}

