using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.DTOs.ImageDTOs;
using ApiProjeKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ImagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ImageList()
        {
            var values = _context.Images.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateImage(CreateImageDTO createImageDTO)
        {
            var value = _mapper.Map<Image>(createImageDTO);
            _context.Images.Add(value);
            _context.SaveChanges();
            return Ok("Resim Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteImage(int id)
        {
            var Image = _context.Images.Find(id);
            _context.Images.Remove(Image);
            _context.SaveChanges();
            return Ok("Resim Silme işlemi başarılı");
        }
        [HttpGet("GetImage")]
        public IActionResult GetImage(int id)
        {
            var value = _context.Images.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateImage(UpdateImageDTO updateImageDTO)
        {
            var value = _mapper.Map<Image>(updateImageDTO);
            _context.Images.Update(value);
            _context.SaveChanges();
            return Ok("Resim Güncelleme işlemi başarılı");
        }
    }
}
