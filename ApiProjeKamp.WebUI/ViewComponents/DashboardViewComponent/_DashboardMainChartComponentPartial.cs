using ApiProjeKamp.WebUI.DTOs.ReservationDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKamp.WebUI.ViewComponents.DashboardViewComponent
{
    public class _DashboardMainChartComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardMainChartComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7246/");

            var response = await client.GetAsync("api/Reservations/GetReservationStats");
            var json = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<ReservationChartDTO>>(json);

            return View(data);
        }
    }
}
