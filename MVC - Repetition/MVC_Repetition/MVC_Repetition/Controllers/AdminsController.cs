using Microsoft.AspNetCore.Mvc;
using MVC_Repetition.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Repetition.Controllers
{
    public class AdminsController
    {
        public class AdminController : Controller
        {
            private readonly AuthService _auth;

            public AdminController(AuthService auth)
            {
                _auth = auth;
            }
            public IActionResult Index()
            {
                return View();
            }

            //public async Task<IActionResult> AddRoleForUser(AddRoleVm addrole)
            //{
            //    // din kod här

            //}
        }
    }
}
