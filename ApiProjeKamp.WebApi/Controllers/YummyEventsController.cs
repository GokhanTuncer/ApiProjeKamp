using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {
        private readonly ApiContext _context;

        public YummyEventsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult YummyEventList()
        {
            var values = _context.YummyEvents.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateYummyEvent(YummyEvent YummyEvent)
        {
            _context.YummyEvents.Add(YummyEvent);
            _context.SaveChanges();
            return Ok("Etkinlik Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteYummyEvent(int id)
        {
            var YummyEvent = _context.YummyEvents.Find(id);
            _context.YummyEvents.Remove(YummyEvent);
            _context.SaveChanges();
            return Ok("Etkinlik Silme işlemi başarılı");
        }
        [HttpGet("GetYummyEvent")]
        public IActionResult GetYummyEvent(int id)
        {
            var value = _context.YummyEvents.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateYummyEvent(YummyEvent YummyEvent)
        {
            _context.YummyEvents.Update(YummyEvent);
            _context.SaveChanges();
            return Ok("Etkinlik Güncelleme işlemi başarılı");
        }
    }
}
