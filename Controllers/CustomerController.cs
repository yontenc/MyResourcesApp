using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyResourcesApp.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MyResourcesApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly ILogger<CustomerController> _logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public CustomerController(ApplicationContext db , ILogger<CustomerController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _db = db;
            _logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
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
                //var result = await userManager.CreateAsync(cus);
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
                    //save User Info
                    UserInfo userInfo = new UserInfo();
                    userInfo.UserID = cus.CID;
                    userInfo.UserName = cus.CustomerName;
                    userInfo.EmailAddress = cus.EmailAddress;
                    userInfo.Password = "12345";
                    userInfo.CreatedDate = new DateTime();
                    userInfo.LoginCout = 1;

                    _db.user.Add(userInfo);
                    await _db.SaveChangesAsync();
                    return View("Login");
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
            // Find the customer by name
            var customer = await _db.customer.FindAsync(cid);

            // Get the customers sites
            var sites = from s in _db.site
                         where s.CustomerID == cid
                         select s;
            //Get the Customer Advance deposites
            var advanceDeposits = from ad in _db.advance
                        where ad.CustomerCID == cid
                        select ad;

            if (sites.ToList().Count != 0 || advanceDeposits.ToList().Count != 0)
            {
               
                if (sites.ToList().Count > 0 && advanceDeposits.ToList().Count == 0)
                {
                    ViewBag.ScreenName = "Site Registration";
                }
                else if(advanceDeposits.ToList().Count > 0 && sites.ToList().Count == 0) {
                    ViewBag.ScreenName = "Deposit Advance";
                }
                else
                {
                    ViewBag.ScreenName = "Site Registration And Deposit Advance";
                }
                ViewBag.CustomerID = cid;
                return View("ForeignKeyConstriant");
            }
            else {
              
                _db.customer.Remove(customer);
                await _db.SaveChangesAsync();
            }
           
          
            return RedirectToAction("RegisterCustomer");
        }

    }
}
