using Bl;
using Domains;
using JobOffers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace JobOffers.Controllers
{
    public class UserController : Controller
    {
        //RoleManager<IdentityRole> roleManager;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> singInManager, RoleManager<IdentityRole> _roleManager)
        {
            _userManager = userManager;
            _signInManager = singInManager;
            //roleManager = _roleManager;
        }
        public IActionResult Login(string returnUrl)
        {
            UserModel model = new UserModel()
            {
                ReturnUrl = returnUrl,
            };
            return View(model);
        }
        public IActionResult Register()
        {
            

            return View(new UserModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            if (!ModelState.IsValid)
                return View("Register", model);

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            };

            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    

                    var myUser = await _userManager.FindByIdAsync(user.Id);
                    if(model.UserType == "Publisher")
                        await _userManager.AddToRoleAsync(myUser, "Publisher");
                    else
                        await _userManager.AddToRoleAsync(myUser, "Searcher");

                    var loginResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                    if (loginResult.Succeeded)
                        return Redirect("~/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "A user with that email address already exists.");
                    return View("Register");
                }
            }
            catch { }


            return View(new UserModel());
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)
        {
            //if (!ModelState.IsValid)
            //    return View("Register", model);

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email
            };
            try
            {

                var loginResult = await _signInManager.PasswordSignInAsync(user.Email, model.Password, true, true);

                if (loginResult.Succeeded)
                {
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                        return Redirect("~/");
                    else
                        return Redirect(model.ReturnUrl);
                }
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Email or password are not correct");
                //    return View("Login", model);
                //}

                //return Redirect("~/");



            }
            catch (Exception ex)
            {

            }


            return View(new UserModel());
        }


        public IActionResult AccessDenied()
        {
            return View();
        }


        public IActionResult Reg()
        {
            return View();
        }
    }
}
