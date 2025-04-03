using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.DTOs.ProductDTOs;
using ApiProjeKamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _productValidator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> productValidator, ApiContext context, IMapper mapper)
        {
            _productValidator = productValidator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _context.Products.ToList();
            return Ok(values);

        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _productValidator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Ürün ekleme işlemi başarılı");
            }

        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("Ürün silme işlemi başarılı");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _context.Products.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = _productValidator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Ok("Ürün ekleme işlemi başarılı");
            }
        }
        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDTO createProductDTO)
        {
            var value =_mapper.Map<Product>(createProductDTO);
            _context.Products.Add(value);
            _context.SaveChanges();
            return Ok("Kategorili ürün ekleme işlemi başarılı");
        }

    }
}
