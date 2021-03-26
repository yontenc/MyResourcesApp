using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyResourcesApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyResourcesApp.Controllers
{
    public class LoginController : Controller
    {
        //private readonly UserManager<IdentityUser> userManager;
        //private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationContext _db;

        //public LoginController(UserManager<IdentityUser> userManager,
        //    SignInManager<IdentityUser> signInManager)
        //public LoginController(UserManager<IdentityUser> userManager,
        //    SignInManager<IdentityUser> signInManager,ApplicationContext db)
        //{
        //    this.userManager = userManager;
        //    this.signInManager = signInManager;
        //    _db = db; 
        //}
        public LoginController(ApplicationContext db)
        {

            _db = db;
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserInfo model)
        {
            if (ModelState.IsValid)
            {
                //var result = await signInManager.PasswordSignInAsync(model.UserID, model.Password,false,false);

                var userInfos = await _db.user.SingleOrDefaultAsync(user => user.UserID == model.UserID && user.Password == model.Password);
                //var result = await _db.user.SingleOrDefault(user => user.UserID == model.UserID);
                //List<UserInfo> userInfos = new List<UserInfo>();
                //var userInfos = (from u in _db.user
                //            where u.UserID == model.UserID && u.Password == model.Password
                //            select u).ToList();

                if (userInfos.Equals(0))
                {
                    return View();
                }
                else
                {
                    if (userInfos.LoginCout.Equals(1))
                    {

                      
                        return View("ChangedPassword",userInfos);
                    }
                    else
                    {
                        var loginInfo = new List<string>
                    {
                        userInfos.UserName
                    };

                        TempData["UserInfo"] = loginInfo;


                        return RedirectToAction("Index", "Home");
                    }

                   
                }

                //}

                //ModelState.AddModelError("", "Ïnvalid Login Attempt");

            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            //await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

    }
}
