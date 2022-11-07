using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewGen.Models;

namespace NewGen.Controllers
{
    public class AccountController : Controller
    {   
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpPost]
        public async Task <IActionResult> Logout()
        {  
           await signInManager.SignOutAsync();
           return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Register()
        {   
           return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Register(Register model)
        {
             if(ModelState.IsValid)
            {
                var user = new IdentityUser{UserName = model.Email, Email = model.Email};
                var result = await userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Employee");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View(model);  
        }
        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {  
           ViewData["ReturnUrl"] = returnUrl;  
           return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Login(Login model, string? returnUrl)
        {   
            ViewData["ReturnUrl"] = returnUrl;
            returnUrl = returnUrl ?? Url.Content("~/");
            
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password,model.RememberMe,false);

                if(result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                }

            ModelState.AddModelError(string.Empty,"Invalid Login Attempt");
            
            }
            return View(model);  
        }
    }
}