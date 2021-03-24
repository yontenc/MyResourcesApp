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

using Microsoft.EntityFrameworkCore;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using Rotativa;

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
        public IActionResult ViewPlaceOrder()
        {
            //TempData["TotalOrderAmt"] = 0;
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

     
        public String GetRequiredAmountDetails()
        {
            decimal RequiredAmt = (totalOrder - Balance);
            string message = "You cannot place order since you have Advance balance: " + Balance + ",Total order Amount :" + totalOrder +
                "and you need to deposit advance amount: " + RequiredAmt;
            return message;
        }


        [HttpPost]
        public async Task<IActionResult> SaveOrder(PlaceOrder placeOrder)
        //public IActionResult SaveOrder(PlaceOrder placeOrder)
        {
         
            if (ModelState.IsValid)
            {
                if (CalculateOrder(placeOrder) > getBalanceAmt(placeOrder.CID))
                {

                    //////ViewBag.TotalOrderAmt = CalculateOrder(placeOrder);
                    //TempData["TotalOrderAmt"] = totalOrder;
                    //TempData["BalanceAmt"] = Balance;

                    var requiredDetails = new List<string> {
                                           "Total Order Amount:  Nu." + totalOrder,
                                             "Advance Balance: Nu." + Balance,
                                            "Required Amount: Nu."+(totalOrder-Balance)
                                                };
                    TempData["Required"] = requiredDetails;
                    return RedirectToAction("ViewPlaceOrder");
                    //return View("OrderDetails","PlaceOrder");
                }
                //var orderInfo = _db.orders.Find(placeOrder.CID, placeOrder.productName);
                var orderInfo = _db.order.SingleOrDefault(user => user.CID == placeOrder.CID && user.productName == placeOrder.productName);
                if (orderInfo != null)
                {
                    //Update the advance balance
                    var getDepositAdvanceDetails = await _db.advance.FindAsync(placeOrder.CID);
                    getDepositAdvanceDetails.CustomerCID = placeOrder.CID;
                    getDepositAdvanceDetails.Amount = getDepositAdvanceDetails.Amount;
                    getDepositAdvanceDetails.Balance = getDepositAdvanceDetails.Balance - totalOrder;
                    _db.advance.Update(getDepositAdvanceDetails);
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
                    _db.order.Update(orderInfo);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("OrderDetails");
                }
                else
                {
                    //Update the advance balance
                    var getDepositAdvanceDetails = await _db.advance.FindAsync(placeOrder.CID);
                    getDepositAdvanceDetails.CustomerCID = placeOrder.CID;
                    getDepositAdvanceDetails.Amount = getDepositAdvanceDetails.Amount;
                    getDepositAdvanceDetails.Balance = getDepositAdvanceDetails.Balance - totalOrder;
                    _db.advance.Update(getDepositAdvanceDetails);
                    await _db.SaveChangesAsync();

                    //save new record to orders table
                    placeOrder.PriceAmount = totalOrder;
                    placeOrder.TransportAmount = (TransportRate * placeOrder.Quantity + Distance);
                    placeOrder.AdvanceBalance = getDepositAdvanceDetails.Balance;
                    placeOrder.OrderStatusID = (Char)OrderStatus.Delivered;
                    _db.order.Add(placeOrder);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("OrderDetails");
                }


            }
            return View("PlaceOrder");
        }

        public async Task<IActionResult> GenerateReport(String? cid, String? productName)
        //public IActionResult GenerateReport(String? cid)
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


        [HttpPost]
        //[ValidateInput(false)]
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
    
    }

}

