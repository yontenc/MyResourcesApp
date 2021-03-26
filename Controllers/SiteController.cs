using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyResourcesApp.Models;
using System.Net.Mail;
using System.Net;
using Enums;
//using Amazon.DynamoDBv2;

namespace MyResourcesApp.Controllers
{
    public class SiteController : Controller
    {
        private readonly ApplicationContext _db;

        public SiteController(ApplicationContext db)
        {
            _db = db;
        }
        //site inforamtion
        public IActionResult RegisterSite()
        {
            var siteInfoList = _db.site.ToList();
            return View(siteInfoList);
        }

        public IActionResult EnterNewSite()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnterNewSite(Site site)
        {
            if (ModelState.IsValid)
            {
                var siteDetails = _db.site.SingleOrDefault(s => s.SiteName == site.SiteName && s.CustomerID == site.CustomerID);
                if (siteDetails?.SiteName == site.SiteName)
                {
                    ViewBag.CustomerID = site.CustomerID;
                    ViewBag.SiteName = site.SiteName;
                    return View("Site_IdExists");
                }
                else {
                    _db.Add(site);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("RegisterSite");
                }

              
            }
            return View(site);
        }

        public async Task<IActionResult> EditSiteInfo(int? siteId)
        {
            if (siteId == null)
            {
                return RedirectToAction("RegisterSite");
            }
            var getSiteDetails = await _db.site.FindAsync(siteId);
           var getOrderDetails = _db.order.FirstOrDefault(o => o.SiteName == getSiteDetails.SiteName && o.CID == getSiteDetails.CustomerID && o.OrderStatusID == (char)OrderStatus.Pending);
            if (getOrderDetails != null)
            {
                ViewBag.CustomerID = getSiteDetails.CustomerID;
                ViewBag.SiteName = getSiteDetails.SiteName;
                return View("PendingOrder_Exists");
            }
            return View(getSiteDetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditSiteInfo(Site site)
        {
            if (ModelState.IsValid)
            {
                _db.Update(site);
                await _db.SaveChangesAsync();
                return RedirectToAction("RegisterSite");
            }
            return View(site);
        }

        public async Task<IActionResult> ViewSiteInfo(int? siteId)
        {
            if (siteId == null)
            {
                return RedirectToAction("SiteRegister");
            }

            var getSiteDetails = await _db.site.FindAsync(siteId);
            return View(getSiteDetails);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteSiteInfo(int siteId)
        {
            var getSiteDetails = await _db.site.FindAsync(siteId);
            var getOrderDetails = _db.order.FirstOrDefault(o => o.SiteName == getSiteDetails.SiteName && o.CID == getSiteDetails.CustomerID && o.OrderStatusID == (char)OrderStatus.Pending);
            if (getOrderDetails != null)
            {
                ViewBag.CustomerID = getSiteDetails.CustomerID;
                ViewBag.SiteName = getSiteDetails.SiteName;
                return View("PendingOrder_Exists");
            }
            else
            {
                _db.site.Remove(getSiteDetails);
                await _db.SaveChangesAsync();
 
                return RedirectToAction("RegisterSite");
            }

            //return RedirectToAction("RegisterSite");
        }
    }
}
