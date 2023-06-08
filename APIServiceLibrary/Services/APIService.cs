using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using APIServiceLibrary.DTO;
using System.Net.Http;

namespace APIServiceLibrary.Services
{
    public class APIService : IAPIService
    {
        public async Task<ResultsDTO> GetOneDriver()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://randomuser.me/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var driver = new ResultsDTO();

            try
            {
                var response = await client.GetAsync("https://randomuser.me/api/").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    driver = JsonConvert.DeserializeObject<ResultsDTO>(responseBody);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during the API request: {ex.Message}");
            }

         


            return driver;

        }
    }
}
