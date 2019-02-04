using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC01.Controllers
{

    //[Route("product")]
    public class ProductController : Controller
    {
        //[HttpGet("testy")]
        public IActionResult Testy()
        {
            return View();
        }

        //[HttpGet("Yrittää")]
        public IActionResult Yrittää()
        {
            return View();
        }
    }
}
