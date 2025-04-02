using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.DTOs.FeatureDTOs;
using ApiProjeKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDTO>>(values));
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            var value = _mapper.Map<Feature>(createFeatureDTO);
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _context.Features.Find(id);
            return Ok(_mapper.Map<ResultFeatureDTO>(value));
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            var value = _mapper.Map<Feature>(updateFeatureDTO);
            _context.Features.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");
        }
    }
}
