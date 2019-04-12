using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blinkblink.Models;

namespace Blinkblink.Controllers
{
    public class HomeController : Controller
    {
        private DBBlinkContext _dBBlinkContext;
        public HomeController(DBBlinkContext dBBlinkContext)
        {
            _dBBlinkContext = dBBlinkContext;
        }
        public IActionResult Index()
        {
            return View(_dBBlinkContext.Idols);
        }
        public IActionResult Photos()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Bio()
        {
            return View();
        }
        public IActionResult Contact()
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
