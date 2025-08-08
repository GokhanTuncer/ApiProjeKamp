using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.DTOs.CategoryDTO;
using ApiProjeKamp.WebApi.DTOs.FeatureDTOs;
using ApiProjeKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            var value = _mapper.Map<Category>(createCategoryDTO);           
            _context.Categories.Add(value);
            _context.SaveChanges();
            return Ok("Kategori Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok("Kategori Silme işlemi başarılı");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var value = _mapper.Map<Category>(updateCategoryDTO);
            _context.Categories.Update(value);
            _context.SaveChanges();
            return Ok("Kategori Güncelleme işlemi başarılı");
        }
    }
}
