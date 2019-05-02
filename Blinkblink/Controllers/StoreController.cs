using Blinkblink.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blinkblink.Controllers
{
    public class StoreController : Controller
    {
        private DBBlinkContext _dBBlinkContext;
        public StoreController(DBBlinkContext dBBlinkContext)
        {
        _dBBlinkContext= dBBlinkContext;
        }
        public IActionResult Store()
        {           
            return View(_dBBlinkContext.Categories);
        }
        [HttpGet]
        public JsonResult GetProduct(string id)
        {
            var resulf = _dBBlinkContext.Products.Where(o => o.CategoryId.Equals(id));
            return Json(resulf);
        }
        public IActionResult Product(string id)
        {
            var resulf = _dBBlinkContext.ImageProducts.Where(o => o.ProductId.Equals(id)).Include(x => x.Product);
            return View(resulf);
        }
    }
}
