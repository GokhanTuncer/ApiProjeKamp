using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.DTOs;
using ApiProjeKamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO createContactDTO)
        {
            var contact = new Contact
            {
                MapLocation = createContactDTO.MapLocation,
                Address = createContactDTO.Address,
                Phone = createContactDTO.Phone,
                Email = createContactDTO.Email,
                OpenHours = createContactDTO.OpenHours
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("İletişim bilgisi ekleme işlemi başarılı");
        }
    }
}
