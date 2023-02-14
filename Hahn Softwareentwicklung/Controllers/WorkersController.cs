using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hahn_Softwareentwicklung.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn_Softwareentwicklung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WorkersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Workers
        [HttpGet]
        public ActionResult<IEnumerable<Worker>> GetWorkersList()
        {
            return _context.Workers.ToList();
        }

        // GET: api/Workers/5
        [HttpGet("{id}")]
        public ActionResult<Worker> GetWorkerById(Guid id)
        {
            var worker = _context.Workers.Find(id);

            if (worker == null)
            {
                return NotFound();
            }

            return worker;
        }

        // POST: api/Workers
        [HttpPost]
        public ActionResult<Worker> AddWorker(Worker worker)
        {
            worker.WorkerId = Guid.NewGuid();
            _context.Workers.Add(worker);
            _context.SaveChanges();

            return worker;
        }

        // PUT: api/Workers/5
        [HttpPut("{id}")]
        public ActionResult<Worker> EditWorkerById(Guid id, Worker worker)
        {
            if (id != worker.WorkerId)
            {
                return BadRequest();
            }

            _context.Entry(worker).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Workers/5
        [HttpDelete("{id}")]
        public ActionResult<Worker> DeleteWorkerById(Guid id)
        {
            var worker = _context.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(worker);
            _context.SaveChanges();

            return worker;
        }
    }
}