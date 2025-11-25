using ApiProjeKamp.WebUI.DTOs.MessageDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static ApiProjeKamp.WebUI.Controllers.AIController;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MessageList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7246/api/Messages");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7246/api/Messages", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("MessageList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7246/api/Messages?id=" + id);

            return RedirectToAction("MessageList");


        }
        [HttpGet]
        public async Task<IActionResult> UpdateMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7246/api/Messages/GetMessage?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetMessageByIDDTO>(jsonData);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateMessageDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7246/api/Messages", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("MessageList");
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> AnswerMessageWithOpenAI(int id, string prompt)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7246/api/Messages/GetMessage?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetMessageByIDDTO>(jsonData);
            prompt = value.MessageDetails;

            var apiKey = "APIKEYGIR";      //API Key buraya

            using var client2 = new HttpClient();
            client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestData = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new {
                        //Ai'nin rolü
                        role = "system",
                        content = "Sen bir restaurant için kullanıcıların göndermiş oldukları mesajları olabildiğince olumlu ve detaylı,müşteri memnuniyeti gözeten cevaplar veren bir yapay zeka aracısın. Amaç, kullanıcı tarafından gönderilen mesajlara en olumlu ve en mantıklı cevapları vermek."
                    },
                    new
                    {
                        //Kullanıcının rolü

                        role = "user",
                        content = prompt

                    }
                },
                temperature = 0.5 //0, daha deterministik; 1, daha yaratıcı cevap
            };
            var response = await client2.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                var content = result.choices[0].message.content;
                ViewBag.answerAI = content;
            }
            else
            {
                ViewBag.answerAI = "Bir hata oluştu: " + response.StatusCode;
            }

            return View(value);
        }
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDTO createMessageDTO)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7246/api/Messages", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("MessageList");
            }
            return View();
        }
    }
}
