using BusinessLogic.Logic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLogic.Json
{
    public class JsonService
    {
        private readonly HttpClient _httpClient;

        public JsonService(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
        }

        public  Image GetJsonFromUrlAsync<T>(string url)
        {
            try
            {
               //consume la url para traer el dato
                var response =  _httpClient.GetStringAsync(url);
                string dato= response.Result;
                //convierte la información a la clase Image 
                return JsonConvert.DeserializeObject<Image>(dato);
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine($"Request error: {httpRequestException.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
        }
    }
}
