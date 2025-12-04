using ApiProjeKamp.WebUI.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace ApiProjeKamp.WebUI.ViewComponents.DashboardViewComponent
{
    public class _DashboardWidgetsComponentPartial  : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int r1,r2,r3,r4;
            Random random = new Random();
            r1 = random.Next(1, 35);
            r2 = random.Next(1, 35);
            r3 = random.Next(1, 35);
            r4 = random.Next(1, 35);

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7246/api/Reservations/GetTotalReservationCount");
                var jsonData = await response.Content.ReadAsStringAsync();
            ViewBag.v1 = jsonData;
            ViewBag.r1 = r1;

            var client2 = _httpClientFactory.CreateClient();
            var response2 = await client.GetAsync("https://localhost:7246/api/Reservations/GetTotalCustomerCount");
            var jsonData2 = await response.Content.ReadAsStringAsync();
            ViewBag.v2 = jsonData2;
            ViewBag.r2 = r2;


            var client3 = _httpClientFactory.CreateClient();
            var response3 = await client.GetAsync("https://localhost:7246/api/Reservations/GetPendingReservations");
            var jsonData3 = await response.Content.ReadAsStringAsync();
            ViewBag.v3 = jsonData3;
            ViewBag.r3 = r3;


            var client4 = _httpClientFactory.CreateClient();
            var response4 = await client.GetAsync("https://localhost:7246/api/Reservations/GetApprovedReservations");
            var jsonData4 = await response.Content.ReadAsStringAsync();
            ViewBag.v4 = jsonData4;
            ViewBag.r4 = r4;


            //var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
            return View();
        }
    }
}
