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
            int c = 10;
        }
        //site inforamtion
        public IActionResult RegisterProduct()
        {
            var productInfoList = _db.product.ToList();
            return View(productInfoList);
        }

        public IActionResult EnterNewProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnterNewProduct(Product product)
        {
            if (ModelState.IsValid)
            { 
                var productInfo = _db.product.SingleOrDefault(p => p.productName ==  product.productName);
        
                if (productInfo?.productName == product.productName)
                {
                    ViewBag.productName = product.productName;

                    return View("Product_Exists");
                }
                else
                {
                    _db.Add(product);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("RegisterProduct");
                }


            }
            return View(product);
        }

        public async Task<IActionResult> EditProductInfo(String productName)
        {
            if (productName == null || productName.Equals(""))
            {
                return RedirectToAction("RegisterProduct");
            }

            var getProductDetails = await _db.product.FindAsync(productName);
            return View(getProductDetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditProductInfo(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Update(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("RegisterProduct");
            }
            return View(product);
        }


        public async Task<IActionResult> ViewProductInfo(string? productName)
        {
            if (productName == null)
            {
                return RedirectToAction("RegisterProduct");
            }

            var getProductDetails = await _db.product.FindAsync(productName);
            return View(getProductDetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProductInfo(String productName)
        {
            var viewProductDetails = await _db.product.FindAsync(productName);
            _db.product.Remove(viewProductDetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("RegisterProduct");
        }

    }
}

