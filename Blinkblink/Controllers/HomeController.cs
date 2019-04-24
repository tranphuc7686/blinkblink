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
using System.Collections;
using Blinkblink.ViewModels;
using Blinkblink.Services;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Blinkblink.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HomeController : Controller
    {
        private DBBlinkContext _dBBlinkContext;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly HomeHelper _homeHelper;
        private static User _user;
        private static Idol _idol;

        public HomeController(DBBlinkContext dBBlinkContext, IHostingEnvironment appEnvironment)
        {
            _dBBlinkContext = dBBlinkContext;
            _appEnvironment = appEnvironment;
            _homeHelper = new HomeHelper(dBBlinkContext);
        }
        public IActionResult Index()
        {
            ClaimsPrincipal principal = HttpContext.User;
            string idUser = principal.Claims.ElementAt(1).Value;
            _user = _dBBlinkContext.Users.Where(o => o.Id.Equals(idUser)).FirstOrDefault();
            return View(_dBBlinkContext.Idols);
        }
       
        public IActionResult Privacy()
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
            _idol = _dBBlinkContext.Idols.Where(o => o.Id.Equals(id)).FirstOrDefault();
            ViewData["Images"] = _dBBlinkContext.Images
                .Include(x => x.Idol)
                .Where(e => e.Idol.Id.Equals(id))
                .OrderByDescending(o => o.DateTime)
                .ToList();
            ViewData["DataUpload"] = new UploadedImageData();
            return View();

        }

        public async Task<IActionResult> UploadFiles(UploadedImageData model)
        {
            IFormFile formFile = model.ImageFile;
            var filePathToCopy = "";
            var filePathToGet = "";
            int typeData = (formFile.ContentType.Equals("video/mp4") ? 2 : 1);
            if (formFile.Length > 0)
            {
                // full path to file in temp location
                filePathToCopy = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot\\User_Files\\Images\\",
                      formFile.FileName);
                filePathToGet = Path.Combine("\\User_Files\\Images\\",
                      formFile.FileName);
                using (var stream = new FileStream(filePathToCopy, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            _homeHelper.AddPathFilesProcess(model.Caption, filePathToGet, _idol,_user, typeData);

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return RedirectToAction("Single", new { id = _idol.Id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
