using System.Text;
using System.Text.Json;
using TaskManager.Share.Models;

namespace TaskManager.Frontend.WebRepository
{
    public class WebRepository : IWebRepository
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions _jsonDefaultOptions => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

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
            var responseJson = JsonSerializer.Deserialize<T>(responseString, _jsonDefaultOptions);

            return new Response<T>
            {
                Result = responseJson,
                IsSuccess = true
            };
        }

        public async Task<Response<T>> PostAsync<T>(string url, T model)
        {
            var requestStringBody = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(requestStringBody, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PostAsync(url, messageContent);

            if (!responseHttp.IsSuccessStatusCode)
            {
                return new Response<T>
                {
                    Message = "Fail to post new object.",
                    IsSuccess = false
                };
            }


            var responseString = await responseHttp.Content.ReadAsStringAsync();
            var responseJson = JsonSerializer.Deserialize<T>(responseString, _jsonDefaultOptions);

            return new Response<T>
            {
                Result = responseJson,
                IsSuccess = true
            };

        }

        public async Task<Response<T>> PutAsync<T>(string url, T model)
        {
            var requestStringBody = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(requestStringBody, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PutAsync(url, messageContent);

            if (!responseHttp.IsSuccessStatusCode)
            {
                return new Response<T>
                {
                    Message = "Fail to update object.",
                    IsSuccess = false
                };
            }


            var responseString = await responseHttp.Content.ReadAsStringAsync();
            var responseJson = JsonSerializer.Deserialize<T>(responseString, _jsonDefaultOptions);

            return new Response<T>
            {
                Result = responseJson,
                IsSuccess = true
            };
        }

        public async Task<Response<T>> DeleteAsync<T>(string url)
        {
            var responseHttp = await _httpClient.DeleteAsync(url);

            if (!responseHttp.IsSuccessStatusCode)
            {
                return new Response<T>
                {
                    Message = "Fail to delete object.",
                    IsSuccess = false
                };
            }

            return new Response<T>
            {
                IsSuccess = true
            };
        }
    }
}

