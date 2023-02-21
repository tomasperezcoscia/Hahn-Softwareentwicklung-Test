using Hahn_Softwareentwicklung.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hahn_Softwareentwicklung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MenuesController(ApplicationContext context)
        {
            _context = context;
        }

        //GET: api/Menues
        [HttpGet]
        public ActionResult<IEnumerable<Menu>> GetListOfRegisteredMenues()
        {
            return _context.Menues.ToList();
        }

        //GET: api/Menues/Roles
        [HttpGet("Roles")]
        public ActionResult<IEnumerable<Role>> GetListOfRegisteredRoles()
        {
            return _context.Roles.ToList();
        }

        //GET: api/Menues/Roles/{id}
        [HttpGet("Roles/{id}")]
        public ActionResult<IEnumerable<Menu>> GetListOfMenuesForRole(int id)
        {
            var menus = from menuRole in _context.MenuRoles
                        join menu in _context.Menues on menuRole.menuId equals menu.Id
                        where menuRole.roleId == id
                        select menu;

            return menus.ToList();
        }
    }
}
