using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstASPNetProject.Models;
using Microsoft.AspNetCore.Routing;

namespace FirstASPNetProject.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LinkGenerator _linkGenerator;

        public HomeController(ILogger<HomeController> logger,
                              LinkGenerator linkGenerator)
        {
            _logger = logger;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("")]
        [HttpGet("/")]
        [HttpGet("[action]")]

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Link()
        {
            var link = _linkGenerator.GetPathByAction("Privacy", "Home");
            return Content(link);
        }

        private static User _User = new User
        {
                dataNascimento = (DateTime.Today).AddYears(-1)
        };

        [HttpGet("[action]")]
        public IActionResult Idade()
        {            
            return View(_User);
        }

        [HttpPost("[action]")]
        public IActionResult Idade(User user)
        {            
            if(ModelState.IsValid)
            {
                _User.dataNascimento = user.dataNascimento;
                return RedirectToAction("Idade");
            }
            else
            {
                return View(user);
            }
        }

        [HttpGet("[action]")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
