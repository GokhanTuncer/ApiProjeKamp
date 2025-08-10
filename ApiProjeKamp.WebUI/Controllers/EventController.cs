using ApiProjeKamp.WebUI.DTOs.EventDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class EventController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EventController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> EventList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7246/api/YummyEvents");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEventDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDTO createEventDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createEventDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7246/api/YummyEvents", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("EventList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7246/api/YummyEvents?id=" + id);

            return RedirectToAction("EventList");


        }
        [HttpGet]
        public async Task<IActionResult> UpdateEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7246/api/YummyEvents/GetYummyEvent?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetEventByIDDTO>(jsonData);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEvent(UpdateEventDTO updateEventDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateEventDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7246/api/Events", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("EventList");
            }
            return View();

        }
    }
}
