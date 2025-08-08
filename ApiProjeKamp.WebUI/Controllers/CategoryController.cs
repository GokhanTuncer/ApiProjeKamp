using ApiProjeKamp.WebUI.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7246/api/Categories");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7246/api/Categories", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7246/api/Categories?id=" + id);

            return RedirectToAction("CategoryList");


        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7246/api/Categories/GetCategory?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetCategoryByIDDTO>(jsonData);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7246/api/Categories", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return View();

        }
    }
}
