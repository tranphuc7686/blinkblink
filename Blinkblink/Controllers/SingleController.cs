using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blinkblink.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace Blinkblink.Controllers
{
    public class SingleController : Controller
    {
        private DBBlinkContext _dBBlinkContext;
        public SingleController(DBBlinkContext dBBlinkContext)
        {
            _dBBlinkContext = dBBlinkContext;
        }
        [Route("Single/{id}")]
        public IActionResult Index(string id)
        {
            return View(_dBBlinkContext.Images.Include(x => x.Idol).Where(e => e.Idol.Id.Equals(id)).ToList());
        }
        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("Files");
        }
        
    }
}