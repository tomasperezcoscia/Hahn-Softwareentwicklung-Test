using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hahn_Softwareentwicklung.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn_Softwareentwicklung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CarsController(ApplicationContext context)
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
        public ActionResult<Car> GetCarById(Guid id)
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
            car.Id = Guid.NewGuid();
            _context.Cars.Add(car);
            _context.SaveChanges();

            return car;
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public ActionResult<Car> EditCarById(Guid id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public ActionResult<Car> DeleteCarById(Guid id)
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