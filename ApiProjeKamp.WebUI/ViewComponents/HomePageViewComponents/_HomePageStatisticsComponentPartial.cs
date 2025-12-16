using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebUI.ViewComponents.HomePageViewComponents
{
    public class _HomePageStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomePageStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client1 = _httpClientFactory.CreateClient();
            var response = await client1.GetAsync("https://localhost:7246/api/Statistics/ProductCount");
            var jsonData1 = await response.Content.ReadAsStringAsync();
            ViewBag.v1 = jsonData1;

            var client2 = _httpClientFactory.CreateClient();
            var response2 = await client2.GetAsync("https://localhost:7246/api/Statistics/ReservationCount");
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            ViewBag.v2 = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var response3 = await client1.GetAsync("https://localhost:7246/api/Statistics/ChefCount");
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            ViewBag.v3 = jsonData3;

            var client4 = _httpClientFactory.CreateClient();
            var response4 = await client4.GetAsync("https://localhost:7246/api/Statistics/TotalGuestCount");
            var jsonData4 = await response4.Content.ReadAsStringAsync();
            ViewBag.v4 = jsonData1;

            return View();
        }
    }

}
