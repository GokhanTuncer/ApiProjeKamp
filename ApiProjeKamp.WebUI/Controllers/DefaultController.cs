using ApiProjeKamp.WebUI.DTOs.ContactDTOs;
using ApiProjeKamp.WebUI.DTOs.ReservationDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDTO createReservationDTO)
        {
            createReservationDTO.ReservationStatus = "Onay Bekliyor";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7246/api/Reservations", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
