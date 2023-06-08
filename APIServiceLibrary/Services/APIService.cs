using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIServiceLibrary.Services
{
    public class APIService
    {

        //public async Task<ProgramResponseDTO> GetOneDriver(int categoryId)
        //{
        //    using var client = new HttpClient();
        //    client.BaseAddress = new Uri("http://api.sr.se");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        //    var programs = new ProgramResponseDTO();

        //    HttpResponseMessage response =
        //        await client.GetAsync(
        //            $"/api/v2/programs?format=json&indent=true&pagination=false&programcategoryid={categoryId}");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseBody = await response.Content.ReadAsStringAsync();
        //        programs = JsonConvert.DeserializeObject<ProgramResponseDTO>(responseBody);
        //    }


        //    return programs;

        //}
    }
}
