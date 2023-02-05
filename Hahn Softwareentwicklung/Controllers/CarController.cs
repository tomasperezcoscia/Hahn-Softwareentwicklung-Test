using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hahn_Softwareentwicklung.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn_Softwareentwicklung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CarController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetCarList()
        {
            return _context.Cars.ToList();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public ActionResult<Car> GetCarById(int id)
        {
            var car = _context.Cars.Find(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // POST: api/Cars
        [HttpPost]
        public ActionResult<Car> AddCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();

            return CreatedAtAction("GetCar", new { id = car.CarID }, car);
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public ActionResult<Car> EditCarById(int id, Car car)
        {
            if (id != car.CarID)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public ActionResult<Car> DeleteCarById(int id)
        {
            var car = _context.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            _context.SaveChanges();

            return car;
        }
    }
}