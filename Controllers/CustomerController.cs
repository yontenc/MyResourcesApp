using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyResourcesApp.Models;
using Microsoft.Extensions.Logging;

namespace MyResourcesApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly ILogger<CustomerController> _logger;


        public CustomerController(ApplicationContext db , ILogger<CustomerController> logger)
        {
            _db = db;
            _logger = logger;
        }
        public IActionResult RegisterCustomer()
        {
            _logger.LogDebug("Getting Customer Info");
            var customerInfoList = _db.customer.ToList();
            return View(customerInfoList);

        }

        public IActionResult EnterNewCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnterNewCustomer(Customer cus)
        {
            if (ModelState.IsValid)
            {
                var customerInfo = _db.customer.Find(cus.CID);
                if (customerInfo?.CID != null)
                {
                    ViewBag.CID = customerInfo.CID;
                    return View("Customer_IdExists");

              //      throw new ArgumentException(
              //$"Cid already exists for: {customerInfo.CID}.", nameof(customerInfo.CID));
                }
                else
                {
                    _db.Add(cus);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("RegisterCustomer");
                }
               
              
            }
            return View(cus);
        }

        public async Task<IActionResult> EditCustomerInfo(String cid)
        {
            if (cid == null || cid.Equals(""))
            {
                return RedirectToAction("RegisterCustomer");
            }

            var getCustomerDetails = await _db.customer.FindAsync(cid);
            return View(getCustomerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomerInfo(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _db.Update(customer);
                await _db.SaveChangesAsync();
                TempData["message"] = customer.CustomerName + " was edited";
                return RedirectToAction("RegisterCustomer");
            }
            return View(customer);
        }

        public async Task<IActionResult> ViewCustomerInfo(String? cid)
        {

            if (cid == null || cid.Equals(""))
            {
               
                return RedirectToAction("RegisterCustomer");
            }
            _logger.LogWarning("Customer with:" + cid + "does not exists");
            var viewCustomerDetails = await _db.customer.FindAsync(cid);
            return View(viewCustomerDetails);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteCustomerInfo(String cid)
        {
            var viewCustomerDetails = await _db.customer.FindAsync(cid);
            _db.customer.Remove(viewCustomerDetails);
            await _db.SaveChangesAsync();
            TempData["message"] = cid + " was deleted";
            return RedirectToAction("RegisterCustomer");
        }

    }
}
