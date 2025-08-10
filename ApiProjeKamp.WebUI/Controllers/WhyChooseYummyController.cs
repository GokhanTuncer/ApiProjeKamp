using ApiProjeKamp.WebUI.DTOs.ServiceDTOs;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class WhyChooseYummyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WhyChooseYummyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> WhyChooseYummyList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7246/api/Services");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateWhyChooseYummy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhyChooseYummy(CreateServiceDTO createWhyChooseYummyDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createWhyChooseYummyDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7246/api/Services", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("WhyChooseYummyList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteWhyChooseYummy(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7246/api/Services?id=" + id);

            return RedirectToAction("WhyChooseYummyList");


        }
        [HttpGet]
        public async Task<IActionResult> UpdateWhyChooseYummy(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7246/api/Services/GetWhyChooseYummy?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetServiceByIDDTO>(jsonData);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWhyChooseYummy(UpdateServiceDTO updateWhyChooseYummyDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateWhyChooseYummyDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7246/api/Services", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("WhyChooseYummyList");
            }
            return View();

        }
    }
}
