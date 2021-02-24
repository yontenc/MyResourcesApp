using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyResourcesApp.Models;

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
            var siteInfoList = _db.siteInfo.ToList();
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
                _db.Add(site);
                await _db.SaveChangesAsync();
                return RedirectToAction("RegisterSite");
            }
            return View(site);
        }

        public async Task<IActionResult> EditSiteInfo(int? siteId)
        {
            if (siteId == null)
            {
                return RedirectToAction("RegisterSite");
            }
            var getSiteDetails = await _db.siteInfo.FindAsync(siteId);
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

            var getSiteDetails = await _db.siteInfo.FindAsync(siteId);
            return View(getSiteDetails);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteSiteInfo(int siteId)
        {

            var getSiteDetails = await _db.siteInfo.FindAsync(siteId);
            _db.siteInfo.Remove(getSiteDetails);
            await _db.SaveChangesAsync();
            TempData["message"] = siteId + " was deleted";
            return RedirectToAction("RegisterSite");
        }
    }
}
