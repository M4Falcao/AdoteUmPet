using AdoteUmPet.Models;
using Newtonsoft.Json;

namespace AdoteUmPet.ExternalAPIs
{
    public class CatApi : IApi
    {
        private readonly HttpClient _httpClientCat;
        public CatApi()
        {
            _httpClientCat = new HttpClient { BaseAddress = new Uri("https://api.thecatapi.com/") };
        }
        public async Task<string> RandomImage()
        {
            
            var request = new HttpRequestMessage(HttpMethod.Get, "v1/images/search");

            var response = await _httpClientCat.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResponseApiCat>>(json);


                return result[0].url;
            }
            else
            {
                return null;
            }
            
        }
    }
}
