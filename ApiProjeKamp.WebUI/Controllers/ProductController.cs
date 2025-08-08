using ApiProjeKamp.WebUI.DTOs.CategoryDTOs;
using ApiProjeKamp.WebUI.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ProductList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7246/api/Products");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7246/api/Categories");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
            List<SelectListItem> categories = values.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7246/api/Products/CreateProductWithCategory", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7246/api/Products?id=" + id);

            return RedirectToAction("ProductList");


        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7246/api/Products/GetProduct?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetProductByIDDTO>(jsonData);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7246/api/Products", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();

        }
    }
}
