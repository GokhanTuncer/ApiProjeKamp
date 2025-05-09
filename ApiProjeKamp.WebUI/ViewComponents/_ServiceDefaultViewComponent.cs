using ApiProjeKamp.WebUI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKamp.WebUI.ViewComponents
{
    public class _ServiceDefaultViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServiceDefaultViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7246/api/Services/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDTO>>(jsonData);
            }
            else
            {
               
            }
            return View();
        }
    }
}
