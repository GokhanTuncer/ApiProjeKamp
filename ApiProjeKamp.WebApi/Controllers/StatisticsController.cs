using ApiProjeKamp.WebApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ApiContext _context;

        public StatisticsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet("ReservationCount")]
        public IActionResult ReservationCount()
        {
            var reservationCount = _context.Reservations.Count();
            return Ok(reservationCount);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var productCount = _context.Products.Count();
            return Ok(productCount);
        }
        [HttpGet("ChefCount")]
        public IActionResult ChefCount()
        {
            var chefCount = _context.Chefs.Count();
            return Ok(chefCount);
        }
        [HttpGet("TotalGuestCount")]
        public IActionResult TotalGuestCount()
        {
            var totalGuestCount = _context.Reservations.Sum(r => r.CountOfPeople);
            return Ok(totalGuestCount);
        }

    }
}
