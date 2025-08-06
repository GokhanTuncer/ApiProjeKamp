using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.DTOs.MessageDTOs;
using ApiProjeKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public MessagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDTO>>(values));
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var value = _mapper.Map<Message>(createMessageDTO);
            _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok("Mesaj ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Mesaj Silme İşlemi Başarılı");
        }
        [HttpGet("GetMessage")]
        public IActionResult GetMessages()
        {
            var value = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDTO>>(value));
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            var value = _mapper.Map<Message>(updateMessageDTO);
            _context.Messages.Update(value);
            _context.SaveChanges();
            return Ok("Mesaj Güncelleme İşlemi Başarılı");
        }

        [HttpGet("MessageListByIsReadFalse")]
        public IActionResult MessageListByIsReadFalse()
        {
            var values = _context.Messages.Where(x => x.IsRead == false).ToList();
            return Ok(_mapper.Map<List<ResultMessageDTO>>(values));
        }
    }
}
