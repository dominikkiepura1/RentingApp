using Microsoft.AspNetCore.Mvc;
using RentingApp.Data;
using RentingApp.Models;

namespace HotelCarReservation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarVersionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarVersionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCarVersions()
        {
            return Ok(_context.CarVersions.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCarVersion(int id)
        {
            var car = _context.CarVersions.Find(id);
            if (car == null)
                return NotFound();

            return Ok(car);
        }

        [HttpPost]
        public IActionResult CreateCarVersion(CarVersion car)
        {
            _context.CarVersions.Add(car);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCarVersion), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCarVersion(int id, CarVersion updatedCar)
        {
            var car = _context.CarVersions.Find(id);
            if (car == null)
                return NotFound();

            car.Model = updatedCar.Model;
            car.Brand = updatedCar.Brand;
            car.PricePerDay = updatedCar.PricePerDay;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCarVersion(int id)
        {
            var car = _context.CarVersions.Find(id);
            if (car == null)
                return NotFound();

            _context.CarVersions.Remove(car);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
