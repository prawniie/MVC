using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc02.Data;
using Mvc02.Services;
using Mvc02.ViewModel;

namespace Mvc02.Controllers
{

    public class AdminsController : Controller
    {

        //private readonly ApplicationDbContext _context;

        //public AdminsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly AuthService _auth;

        public AdminsController(AuthService auth)
        {
            _auth = auth;
        }
        public IActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> AddRoleForUser(AddRoleVm addrole)
        {
            bool Userexist = await _auth.UserExist(addrole.Admin.Email);

            //ModelState.AddModelError(addrole.Admin.Email);

            if (!ModelState.IsValid)
            {
                return View("index");
            }
            else
            {
                if (Userexist)
                {

                    bool roleExist = await _auth.RoleExist(addrole.Admin.Role);

                    if (!roleExist)
                    {
                        await _auth.CreateRole(addrole.Admin.Role);
                    }

                    await _auth.AddRoleToUser(addrole);
                    return View("SuccessAddRole", addrole);

                } else
                {
                    ModelState.AddModelError("UserDontExist", $"User with email {addrole.Admin.Email} doesn't exist");
                    return View("index");

                }

            }

        }
    }
}