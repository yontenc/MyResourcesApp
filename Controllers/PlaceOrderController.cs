using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyResourcesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enums;
using MyResourcesApp.Common;
using Microsoft.EntityFrameworkCore;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;


namespace MyResourcesApp.Controllers
{
 
    public class PlaceOrderController : Controller
    {
        //region private variables
        private readonly ApplicationContext _db;
        private decimal totalOrder;
        private decimal PricePerUnit;
        private decimal TransportRate;
        private decimal Distance;
        private decimal Balance;
        //endregion
       

        //region private method
        private Decimal getBalanceAmt(String CID)
        {
            List<DepositAdance> depositAdancesList = new List<DepositAdance>();
            depositAdancesList = (from da in _db.advance
                                  where da.CustomerCID == CID
                                  select da).ToList();
            foreach (var depositItem in depositAdancesList)
            {
                Balance = depositItem.Balance;
            }
            return Balance;
        }
        //endregion

        //region public method
        public PlaceOrderController(ApplicationContext db)
        {
            _db = db;
      
        }
        public IActionResult OrderDetails()
        {
           
            var orderInfoList = _db.order.ToList();
            return View(orderInfoList);

        }
        public IActionResult GetPendingOrderList()
        {

            var pendingOrderList = (from order in _db.order
                                            where order.OrderStatusID == (char) OrderStatus.Pending
                                            select order).ToList(); ;

            return View(pendingOrderList);

        }
        public IActionResult ViewPlaceOrder()
        {
        
            List<Product> productList = new List<Product>();
            productList = (from p in _db.product
                           select p).ToList();

            productList.Insert(0, new Product { productName = "Select" });
            ViewBag.ListOfProduct = productList;
            ViewBag.requiredDetails = TempData["Required"];
            return View();
        }

        public JsonResult GetSite(String CID)
        {
        
            List<Site> siteList = new List<Site>();
            siteList = (from s in _db.site
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
            siteList = (from s in _db.site
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

        [HttpPost]
        public async Task<IActionResult> SaveOrder(PlaceOrder placeOrder)
        
        {
         
            if (ModelState.IsValid)
            {
                if (CalculateOrder(placeOrder) > getBalanceAmt(placeOrder.CID))
                {

                    var requiredDetails = new List<string> {
                                           "Total Order Amount:  Nu." + totalOrder,
                                             "Advance Balance: Nu." + Balance,
                                            "Required Amount: Nu."+(totalOrder-Balance)
                                                };
                    TempData["Required"] = requiredDetails;
                    return RedirectToAction("ViewPlaceOrder");
                }
                else
                {
                    var getDepositAdvanceDetails = await _db.advance.FindAsync(placeOrder.CID);
                    var getSiteDetails = await _db.site.FindAsync(placeOrder.SiteID);
                    var getCustomerDetails = await _db.customer.FindAsync(placeOrder.CID);
                    //save new record to orders table
                    placeOrder.PriceAmount = totalOrder;
                    placeOrder.TransportAmount = (TransportRate * placeOrder.Quantity + Distance);
                    placeOrder.AdvanceBalance = getDepositAdvanceDetails.Balance -totalOrder;
                    placeOrder.CustomerName = getCustomerDetails.CustomerName;
                    placeOrder.SiteName = getSiteDetails.SiteName;
                    placeOrder.OrderStatusName = "Pending";
                    placeOrder.OrderStatusID = (Char)OrderStatus.Pending;
                    _db.order.Add(placeOrder);
                    await _db.SaveChangesAsync();
                    string subject = "Your ordered";
                    string body = "Your Order is placed successfully with order Id: " + placeOrder.OrderID + "."; 
                    CommonService.SendEmail(getCustomerDetails.EmailAddress, subject, body);

                    return RedirectToAction("OrderDetails");
                }
              }
            return View("PlaceOrder");
        }
        [HttpPost]
        public async Task<IActionResult> ApproveOrder(int OrderID)
        {

            if (ModelState.IsValid)
            {
               //get the order details for approve
                PlaceOrder placeOrder = await _db.order.FindAsync(OrderID);
                //get customer details for updating advance balance
                var getCustomerDetails = await _db.customer.FindAsync(placeOrder.CID);
                //Update the advance balance
                var getDepositAdvanceDetails = await _db.advance.FindAsync(placeOrder.CID);
                    getDepositAdvanceDetails.CustomerCID = placeOrder.CID;
                    getDepositAdvanceDetails.Amount = getDepositAdvanceDetails.Amount;
                    getDepositAdvanceDetails.Balance = getDepositAdvanceDetails.Balance - placeOrder.PriceAmount;
                    _db.advance.Update(getDepositAdvanceDetails);
                    await _db.SaveChangesAsync();

                    //save new record to orders table
                    placeOrder.AdvanceBalance = getDepositAdvanceDetails.Balance - placeOrder.PriceAmount;
                    placeOrder.OrderStatusID = (Char)OrderStatus.Delivered;
                    placeOrder.OrderStatusName ="Delivered";
                    _db.order.Update(placeOrder);
                    await _db.SaveChangesAsync();
                //send mail for successful ordered delivered
                string subject = "Your Ordered Is Delivered";
                string body = "Your Order with order Id:" + placeOrder.OrderID + "is delivered on" + new DateTime() + ".";
                CommonService.SendEmail(getCustomerDetails.EmailAddress, subject, body);
                return RedirectToAction("OrderDetails");
                //}


            }
            return View("OrderDetails");
        }
        [HttpPost]
        public async Task<IActionResult> CancelOrder(int OrderID)
        {
            PlaceOrder placeOrder = await _db.order.FindAsync(OrderID);
            var getDepositAdvanceDetails = await _db.advance.FindAsync(placeOrder.CID);
            //update order
            placeOrder.OrderStatusID = (char)OrderStatus.Canceled;
            placeOrder.OrderStatusName = "Canceled";
            _db.order.Update(placeOrder);
            await _db.SaveChangesAsync();
            //update advance balance
            getDepositAdvanceDetails.Balance = getDepositAdvanceDetails.Balance + placeOrder.PriceAmount;
            _db.advance.Update(getDepositAdvanceDetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("OrderDetails");
        }
        
        //edit order 
        public async Task<IActionResult> EditOrderInfo(int? OrderID)
        {
            if (OrderID == null)
            {
                return RedirectToAction("OrderDetails");
            }
            var getOrderDetails = await _db.order.FindAsync(OrderID);
            List<Product> productList = new List<Product>();
            productList = (from p in _db.product
                           select p).ToList();

            List<Site> siteList = new List<Site>();
            siteList = (from s in _db.site
                        where s.CustomerID == getOrderDetails.CID
                        select s).ToList();
            siteList.Insert(0, new Site { SiteID = 0, SiteName = "Select" }); 
            ViewBag.ListOfSite = siteList;

            productList.Insert(0, new Product { productName = "Select" });
            ViewBag.ListOfProduct = productList;
           
            return View(getOrderDetails);
        }

        //edit pending order
        [HttpPost]
        public async Task<IActionResult> EditOrderInfo(PlaceOrder placeOrder)
        {
            if (ModelState.IsValid)
            {
                if (CalculateOrder(placeOrder) > getBalanceAmt(placeOrder.CID))
                {
                    var requiredDetails = new List<string> {
                                           "Total Order Amount:  Nu." + totalOrder,
                                             "Advance Balance: Nu." + Balance,
                                            "Required Amount: Nu."+(totalOrder-Balance)
                                                };
                    TempData["Required"] = requiredDetails;
                    return RedirectToAction("ViewPlaceOrder");
                }
                else
                {
                    //get site details for saving site name
                    var getSiteDetails = await _db.site.FindAsync(placeOrder.SiteID);
                     //update order table
                    placeOrder.PriceAmount = totalOrder;
                    placeOrder.TransportAmount = (TransportRate * placeOrder.Quantity + Distance);
                    placeOrder.AdvanceBalance = Balance - totalOrder;
                    placeOrder.SiteName = getSiteDetails.SiteName;
                    _db.order.Update(placeOrder);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("OrderDetails");
                }
               
            }
            return View(placeOrder);
        }

        //generate report with CId and Product wise 
        public async Task<IActionResult> GenerateReport(String? cid, String? productName)
        {

            if (cid == null || cid.Equals(""))
            {

               return RedirectToAction("OrderDetails");
            }
            Decimal advanceBalance = getBalanceAmt(cid);
         var orderDetails = _db.order.Where(b => b.CID == cid)
                             .GroupBy(b => b.CID)
                             .Select(g => new PlaceOrder{
                                 CID = cid,
                                 PriceAmount = g.Sum(b => b.PriceAmount),
                                 TransportAmount = g.Sum(b => b.TransportAmount),
                                 AdvanceBalance = advanceBalance 
                             }).FirstOrDefault();

            List<PlaceOrder> getCustomerOrderList = new List<PlaceOrder>();
            getCustomerOrderList.Add(orderDetails);
            var getCustomerWiseProductDetails = await _db.order.Where(x => x.CID == cid).ToListAsync();
            ViewBag.CustomerOrderDetails = getCustomerOrderList;
            ViewBag.CustomerProductDetails = getCustomerWiseProductDetails;
            return View();
        }

        //download odf form
        [HttpPost]
        public FileResult Export(string GridHtml)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Order_Report.pdf");
            }
        }
        //endregion
    
    }

}

