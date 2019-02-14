using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC02.Data;
using MVC02.Models.ViewModels;
using MVC02.Services;

namespace Mvc02.Controllers
{

    public class AdminsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthService _auth;

        public AdminsController(ApplicationDbContext context, AuthService auth)
        {
            _context = context;
            _auth = auth;
        }

        public IActionResult Index()
        {
            var vm = new AddRoleVm
            {
                AllRoles = _context.Roles.Select(role => new SelectListItem() { Text = role.Name, Value = role.Name }),
                AllUsers = _context.Users.Select(user => new SelectListItem() { Text = user.Email, Value = user.Email })
            };
            return View(vm);
        }

        public async Task<IActionResult> AddRoleForUser(AddRoleVm addrole)
        {

                await _auth.AddRoleToUser(addrole);
                return View("SuccesAddRole", addrole);

        }
    }
}