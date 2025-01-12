using Microsoft.AspNetCore.Mvc;
using RentingApp.Data;
using RentingApp.Models;

namespace HotelCarReservation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetReservations()
        {
            return Ok(_context.Reservations.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation == null)
                return NotFound();

            return Ok(reservation);
        }

        [HttpPost]
        public IActionResult CreateReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReservation(int id, Reservation updatedReservation)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation == null)
                return NotFound();

            reservation.Type = updatedReservation.Type;
            reservation.ItemId = updatedReservation.ItemId;
            reservation.StartDate = updatedReservation.StartDate;
            reservation.EndDate = updatedReservation.EndDate;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation == null)
                return NotFound();

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
