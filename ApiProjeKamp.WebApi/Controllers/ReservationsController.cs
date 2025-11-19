using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.DTOs.ReservationDTOs;
using ApiProjeKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ReservationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ReservationList()
        {
            var values = _context.Reservations.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateReservation(CreateReservationDTO createReservationDTO)
        {
            var value = _mapper.Map<Reservation>(createReservationDTO);
            _context.Reservations.Add(value);
            _context.SaveChanges();
            return Ok("Rezervasyon Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            var Reservation = _context.Reservations.Find(id);
            _context.Reservations.Remove(Reservation);
            _context.SaveChanges();
            return Ok("Rezervasyon Silme işlemi başarılı");
        }
        [HttpGet("GetReservation")]
        public IActionResult GetReservation(int id)
        {
            var value = _context.Reservations.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateReservation(UpdateReservationDTO updateReservationDTO)
        {
            var value = _mapper.Map<Reservation>(updateReservationDTO);
            _context.Reservations.Update(value);
            _context.SaveChanges();
            return Ok("Rezervasyon Güncelleme işlemi başarılı");
        }
    }
}
