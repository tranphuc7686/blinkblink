using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blinkblink.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Blinkblink.Controllers
{
    public class HomeController : Controller
    {
        private DBBlinkContext _dBBlinkContext;
        private readonly IHostingEnvironment _appEnvironment;
        public HomeController(DBBlinkContext dBBlinkContext, IHostingEnvironment appEnvironment)
        {
            _dBBlinkContext = dBBlinkContext;
            _appEnvironment = appEnvironment;
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
        [Route("{id}")]
        public IActionResult Single(string id)
        {
            return View(_dBBlinkContext.Images.Include(x => x.Idol).Where(e => e.Idol.Id.Equals(id)).ToList());

        }

        [HttpPost] //Postback

        public async Task<IActionResult> Upload_Image(IFormFile file)

        {

            //--------< Upload_ImageFile() >--------

            //< check >

            if (file == null || file.Length == 0) return Content("file not selected");

            //</ check >



            //< get Path >

            string path_Root = _appEnvironment.WebRootPath;

            string path_to_Images = path_Root + "\\User_Files\\Images\\" + file.FileName;

            //</ get Path >



            //< Copy File to Target >

            using (var stream = new FileStream(path_to_Images, FileMode.Create))

            {

                await file.CopyToAsync(stream);

            }

            //</ Copy File to Target >



            //< output >

            ViewData["FilePath"] = path_to_Images;

            return RedirectToAction("Index");

            //</ output >

            //--------</ Upload_ImageFile() >--------

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
