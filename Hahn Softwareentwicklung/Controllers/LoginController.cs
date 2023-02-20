using Hahn_Softwareentwicklung.Entities;
using Hahn_Softwareentwicklung.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Hahn_Softwareentwicklung.Controllers
{
    [Route("api/workers")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public LoginController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel model)
        {
            Debug.WriteLine("LoginViewModel: " + JsonConvert.SerializeObject(model));

            if (!ModelState.IsValid)
            {
                return BadRequest(new { error = "Invalid model" });
            }

            var worker = _context.Workers.SingleOrDefault(w => w.Email == model.Email);

            if (worker == null)
            {
                return NotFound(new { error = "Email not found" });
            }

            if (worker.Password != model.Password)
            {
                return Unauthorized(new { error = "Invalid password" });
            }

            var role = _context.Roles.SingleOrDefault(r => r.Id == worker.RoleId);

            return Ok(new
            {
                workerId = worker.Id,
                workerFullName = worker.Name,
                workerEmail = worker.Email,
                workerRole = (role == null) ? "No Role" : role.Name,
                workerRoleId= worker.RoleId
            });

        }
    }
}
