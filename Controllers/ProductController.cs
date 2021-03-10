using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyResourcesApp.Models;

namespace MyResourcesApp.Controllers
{
    public class ProductController : Controller

    {
        private readonly ApplicationContext _db;

        public ProductController(ApplicationContext db)
        {
            _db = db;
        }
        //site inforamtion
        public IActionResult RegisterProduct()
        {
            var productInfoList = _db.product.ToList();
            return View(productInfoList);
        }
    }
}

