using AdoteUmPet.Models;
using Newtonsoft.Json;
using System.Drawing;

namespace AdoteUmPet.ExternalAPIs
{
    [Serializable]
    public class DogApi : IApi
    {
        private readonly HttpClient _httpClientDog;
        public IApi NextApi { get; set; }

        public DogApi()
        {
            _httpClientDog = new HttpClient { BaseAddress = new Uri("https://dog.ceo/api/") };
            NextApi = new CatApi();
        }
        

        public async Task<string> RandomImage(TipoDePet type)
        {
            if (type != TipoDePet.Dog) { return await NextApi.RandomImage(type); }

            var request = new HttpRequestMessage(HttpMethod.Get, "breeds/image/random");

            var response = await _httpClientDog.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                ResponseApi resp = JsonConvert.DeserializeObject<ResponseApi>(json);
                
                return resp.message;
            }
            else
            {
                return null;
            }
        }
    }
}
