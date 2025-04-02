using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.DTOs.ContactDTOs;
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
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok("İletişim bilgisi silme işlemi başarılı");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO updateContactDTO)
        {
            var contact = new Contact
            {
                MapLocation = updateContactDTO.MapLocation,
                Address = updateContactDTO.Address,
                Phone = updateContactDTO.Phone,
                Email = updateContactDTO.Email,
                OpenHours = updateContactDTO.OpenHours,
                ContactID = updateContactDTO.ContactID
            };
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("İletişim bilgisi güncelleme işlemi başarılı");
        }
    }
}
