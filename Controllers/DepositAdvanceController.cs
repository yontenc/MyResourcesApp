using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyResourcesApp.Models;

namespace MyResourcesApp.Controllers
{
    public class DepositAdvanceController : Controller
    {
        private readonly ApplicationContext _db;
        private Decimal actualCreditedAmt;
        public DepositAdvanceController(ApplicationContext db)
        {
            _db = db;
        }
        public IActionResult DepositAdvance()
        {
            var advanceDepositList = _db.advanceDeposit.ToList();
            return View(advanceDepositList);
        }

        public IActionResult EnterNewDepositAdvance()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnterNewDepositAdvance(DepositAdance depositAdance)
        {
            if (ModelState.IsValid)
            {
                //get Customer Id form customer registration
                // Get the customers sites
                var customer = from c in _db.customer
                            where c.CID == depositAdance.CustomerCID
                            select c;
                if(customer.ToList().Count == 0)
                {
                    ViewBag.CustomerID = depositAdance.CustomerCID;
                    return View("DoesNotExists_ID");
                }

                var depositAdvanceInfo = _db.advanceDeposit.SingleOrDefault(p => p.CustomerCID == depositAdance.CustomerCID);

                if (depositAdvanceInfo?.CustomerCID == depositAdance.CustomerCID)
                {
                   
                    var getDepositAdvanceDetails = await _db.advanceDeposit.FindAsync(depositAdance.CustomerCID);
                    getDepositAdvanceDetails.CustomerCID = depositAdance.CustomerCID;
                    getDepositAdvanceDetails.Amount = depositAdance.Amount;
                    getDepositAdvanceDetails.Balance = getDepositAdvanceDetails.Balance + depositAdance.Amount;
                    _db.Update(getDepositAdvanceDetails);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("DepositAdvance");
                }
                else
                {
                    depositAdance.Balance = depositAdance.Amount;
                    _db.Add(depositAdance);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("DepositAdvance");
                }
            }
            //enter history
            DepositAdvanceHistory depositAdvanceHistory = new DepositAdvanceHistory();
            depositAdvanceHistory.CustomerCID = depositAdance.CustomerCID;
            depositAdvanceHistory.DepositAmount = depositAdance.Amount;
            depositAdvanceHistory.BalanceAmount = depositAdvanceHistory.BalanceAmount;
            depositAdvanceHistory.DepositTime = new DateTime();
            _db.depositAdvanceHistory.Add(depositAdvanceHistory);
            await _db.SaveChangesAsync();

            return View(depositAdance);
        }

        public async Task<IActionResult> EditDepositAdvanceInfo(String customerCID)
        {
            if (customerCID == null || customerCID.Equals(""))
            {
                return RedirectToAction("DepositAdvance");
            }

            var getDepositAdvanceDetails = await _db.advanceDeposit.FindAsync(customerCID);
            return View(getDepositAdvanceDetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditDepositAdvanceInfo(DepositAdance depositAdance)
        {
            if (ModelState.IsValid)
            {
                var getDepositAdvanceDetails = _db.advanceDeposit.SingleOrDefault(p => p.CustomerCID == depositAdance.CustomerCID);
    
                getDepositAdvanceDetails.CustomerCID = depositAdance.CustomerCID;
              
                if (depositAdance.Amount> getDepositAdvanceDetails.Amount)
                {
                    actualCreditedAmt= getDepositAdvanceDetails.Amount - depositAdance.Amount;
                    getDepositAdvanceDetails.Balance = getDepositAdvanceDetails.Balance + actualCreditedAmt;
                }
                if(depositAdance.Amount == getDepositAdvanceDetails.Amount)
                {
                    getDepositAdvanceDetails.Balance = getDepositAdvanceDetails.Balance;
                }
                if(depositAdance.Amount < getDepositAdvanceDetails.Amount) {
                    actualCreditedAmt = getDepositAdvanceDetails.Amount - depositAdance.Amount;
                getDepositAdvanceDetails.Balance = getDepositAdvanceDetails.Balance  + actualCreditedAmt;
                }
                getDepositAdvanceDetails.Amount = depositAdance.Amount;

                _db.Update(getDepositAdvanceDetails);
                await _db.SaveChangesAsync();
                return RedirectToAction("DepositAdvance");
            }
            return View(depositAdance);
        }

        public async Task<IActionResult> ViewDepositAdvanceInfo(string? customerCID)
        {
            if (customerCID == null)
            {
                return RedirectToAction("DepositAdvance");
            }
            var getDepositAdvanceDetails = await _db.advanceDeposit.FindAsync(customerCID);
            return View(getDepositAdvanceDetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAdvanceDepositInfo(String customerCID)
        {

            var getAdvanceDepositDetails = await _db.advanceDeposit.FindAsync(customerCID);
            _db.advanceDeposit.Remove(getAdvanceDepositDetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("DepositAdvance");
        }
    }
}
