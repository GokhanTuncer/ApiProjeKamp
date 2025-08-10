using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.DTOs.AboutDTOs;
using ApiProjeKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public AboutsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _context.Abouts.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDTO createAboutDTO)
        {
            var value = _mapper.Map<About>(createAboutDTO);
            _context.Abouts.Add(value);
            _context.SaveChanges();
            return Ok("Hakkımda alanı Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var About = _context.Abouts.Find(id);
            _context.Abouts.Remove(About);
            _context.SaveChanges();
            return Ok("Hakkımda alanı Silme işlemi başarılı");
        }
        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            var value = _mapper.Map<About>(updateAboutDTO);
            _context.Abouts.Update(value);
            _context.SaveChanges();
            return Ok("Hakkımda alanı Güncelleme işlemi başarılı");
        }
    }
}
