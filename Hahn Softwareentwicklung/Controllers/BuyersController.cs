using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hahn_Softwareentwicklung.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn_Softwareentwicklung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BuyersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Buyers
        [HttpGet]
        public ActionResult<IEnumerable<Buyer>> GetListOfRegisteredBuyers()
        {
            return _context.Buyers.ToList();
        }

        // GET: api/Buyers/5
        [HttpGet("{id}")]
        public ActionResult<Buyer> GetBuyerById(Guid id)
        {
            var buyer = _context.Buyers.Find(id);

            if (buyer == null)
            {
                return NotFound();
            }

            return buyer;
        }

        // POST: api/Buyers
        [HttpPost]
        public ActionResult<Buyer> AddBuyer(Buyer buyer)
        {
            buyer.Id = Guid.NewGuid();
            _context.Buyers.Add(buyer);
            _context.SaveChanges();

            return buyer;
        }

        // PUT: api/Buyers/5
        [HttpPut("{id}")]
        public ActionResult<Buyer> EditBuyerById(Guid id, Buyer buyer)
        {
            if (id != buyer.Id)
            {
                return BadRequest();
            }

            _context.Entry(buyer).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Buyers/5
        [HttpDelete("{id}")]
        public ActionResult<Buyer> DeleteBuyerById(Guid id)
        {
            var buyer = _context.Buyers.Find(id);
            if (buyer == null)
            {
                return NotFound();
            }

            _context.Buyers.Remove(buyer);
            _context.SaveChanges();

            return buyer;
        }
    }
}