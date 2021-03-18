using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyResourcesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AutoMapper;

namespace MyResourcesApp.Controllers
{
 
    public class PlaceOrderController : Controller
    {
        private readonly ApplicationContext _db;
        private decimal totalOrder;
        private decimal PricePerUnit;
        private decimal TransportRate;
        private decimal Distance;
        private decimal Balance;
        public PlaceOrderController(ApplicationContext db)
        {
            _db = db;
      
        }
        public IActionResult OrderDetails()
        {
           
            var orderInfoList = _db.orders.ToList();
            return View(orderInfoList);

        }
        public IActionResult ViewPlaceOrder()
        {
            //TempData["TotalOrderAmt"] = 0;
            List<Product> productList = new List<Product>();
            productList = (from p in _db.product
                        select p).ToList();
            
            productList.Insert(0, new Product { productName = "Select" });
            ViewBag.ListOfProduct = productList;
            return View();
        }

        public JsonResult GetSite(String CID)
        {
        
            List<Site> siteList = new List<Site>();
            siteList = (from s in _db.siteInfo
                        where s.CustomerID == CID
                        select s).ToList();
            siteList.Insert(0, new Site { SiteID = 0, SiteName = "Select" });
            ViewBag.ListOfSite = siteList;
            return Json(new SelectList(siteList, "SiteID", "SiteName"));

        }

        public Decimal CalculateOrder(PlaceOrder placeOrder)
        {
            List<Product> productList = new List<Product>();
            productList = (from p in _db.product
                           where p.productName == placeOrder.productName
                           select p).ToList();
            List<Site> siteList = new List<Site>();
            siteList = (from s in _db.siteInfo
                        where s.SiteID == placeOrder.SiteID && s.CustomerID == placeOrder.CID
                        select s).ToList();
            foreach (var productItem in productList)
            {
                PricePerUnit = productItem.PricePerUnit;
                TransportRate = productItem.TransportRate;
            }
            foreach(var sitesItem in siteList)
            {
                Distance = sitesItem.Distance;
            }
            totalOrder = (PricePerUnit * placeOrder.Quantity) + (TransportRate * placeOrder.Quantity *Distance);
            return totalOrder;
        }

        private Decimal getBalanceAmt(String CID)
        {
            List<DepositAdance> depositAdancesList = new List<DepositAdance>();
            depositAdancesList = (from da in _db.advanceDeposit
                           where da.CustomerCID ==CID
                           select da).ToList();
            foreach(var depositItem in depositAdancesList)
            {
                Balance = depositItem.Balance;
            }
            return Balance;
        } 

        public String GetRequiredAmountDetails()
        {
            decimal RequiredAmt = (totalOrder - Balance);
            string message = "You cannot place order since you have Advance balance: " + Balance + ",Total order Amount :" + totalOrder +
                "and you need to deposit advance amount: " + RequiredAmt;
            return message;
        }


        [HttpPost]
        public async Task<IActionResult> ViewPlaceOrder(PlaceOrder placeOrder)
        //public IActionResult SaveOrder(PlaceOrder placeOrder)
        {
         
            if (ModelState.IsValid)
            {
                if (CalculateOrder(placeOrder) > getBalanceAmt(placeOrder.CID))
                {

                    //////ViewBag.TotalOrderAmt = CalculateOrder(placeOrder);
                    //TempData["TotalOrderAmt"] = totalOrder;
                    //TempData["BalanceAmt"] = Balance;

                    TempData["RequiredAmt"] = (totalOrder - Balance);

                    ModelState.AddModelError("CID",  totalOrder.ToString("0.00"));
                          ModelState.AddModelError("PriceAmount",  totalOrder.ToString("0.00"));
                          ModelState.AddModelError("SiteID",  totalOrder.ToString("0.00"));
                    //var editMode = Mapper.Map<ProductDetails>(PrjEdit/*M*/ode);
                    ModelState.AddModelError("PriceAmount", "Date must be current date or in the past.");
                    return View(placeOrder);
                    //return View("OrderDetails","PlaceOrder");
                }
                //var orderInfo = _db.orders.Find(placeOrder.CID, placeOrder.productName);
                var orderInfo = _db.orders.SingleOrDefault(user => user.CID == placeOrder.CID && user.productName == placeOrder.productName);
                if (orderInfo != null)
                {
                    //Update the advance balance
                    var getDepositAdvanceDetails = await _db.advanceDeposit.FindAsync(placeOrder.CID);
                    getDepositAdvanceDetails.CustomerCID = placeOrder.CID;
                    getDepositAdvanceDetails.Amount = getDepositAdvanceDetails.Amount;
                    getDepositAdvanceDetails.Balance = getDepositAdvanceDetails.Balance - totalOrder;
                    _db.advanceDeposit.Update(getDepositAdvanceDetails);
                    await _db.SaveChangesAsync();

                    //update order table
                    //var getOrderDetails = await _db.orders.FindAsync(placeOrder.CID);
                    //PlaceOrder order = new PlaceOrder();
                    orderInfo.CID = placeOrder.CID;
                    orderInfo.productName = placeOrder.productName;
                    orderInfo.Quantity = orderInfo.Quantity + placeOrder.Quantity;
                    orderInfo.SiteID = placeOrder.SiteID;
                    orderInfo.PriceAmount = orderInfo.PriceAmount + totalOrder;
                    orderInfo.TransportAmount = orderInfo.TransportAmount + (TransportRate * placeOrder.Quantity + Distance);
                    orderInfo.AdvanceBalance = getDepositAdvanceDetails.Balance;
                    //orderInfo.OrderStatus = (char)OrderStatus.Delivered;
                    _db.orders.Update(orderInfo);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("OrderDetails");
                }
                else
                {
                    //Update the advance balance
                    var getDepositAdvanceDetails = await _db.advanceDeposit.FindAsync(placeOrder.CID);
                    getDepositAdvanceDetails.CustomerCID = placeOrder.CID;
                    getDepositAdvanceDetails.Amount = getDepositAdvanceDetails.Amount;
                    getDepositAdvanceDetails.Balance = getDepositAdvanceDetails.Balance - totalOrder;
                    _db.advanceDeposit.Update(getDepositAdvanceDetails);
                    await _db.SaveChangesAsync();

                    //save new record to orders table
                    placeOrder.PriceAmount = totalOrder;
                    placeOrder.TransportAmount = (TransportRate * placeOrder.Quantity + Distance);
                    placeOrder.AdvanceBalance = getDepositAdvanceDetails.Balance;
                    _db.Add(placeOrder);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("OrderDetails");
                }


            }
            return View("PlaceOrder");
        }

        private void LogException(Exception e)
        {
            throw new NotImplementedException();
        }
    }
}
