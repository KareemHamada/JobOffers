using Bl;
using Domains;
using JobOffers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JobOffers.Controllers
{
    public class HomeController : Controller
    {
        IJobDetails _clsJobDetails;
        ICategories _clsCategories;
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        JobOfferContext context;
        IJobLocations _clsJobLocation;

        public HomeController(IJobDetails clsJobDetails, ICategories clsCategories, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,JobOfferContext ctx, IJobLocations clsJobLocation)
        {
            _clsJobDetails = clsJobDetails;
            _clsCategories = clsCategories;
            _userManager = userManager;
            _roleManager = roleManager;
            context = ctx;
            _clsJobLocation = clsJobLocation;

        }


        public List<string> GetImagePathForCategory(int categoryId)
        {
            var category = _clsCategories.GetById(categoryId);

            return new List<string> { category.ImageName, category.CategoryName };
        }

        public IActionResult Index()
        {
            VmHomePage vm = new VmHomePage();
            vm.lstAllJobs = _clsJobDetails.GetAllViews().Take(4).ToList();
            var categoriesWithItemCountAndImage = _clsJobDetails.GetAllViews()
                .GroupBy(item => item.categoryId)
                .Select(group => new CategoryCountHomeView
                {
                    Name = GetImagePathForCategory(group.Key)[1],
                    ItemCount = group.Count(),
                    ImagePath = GetImagePathForCategory(group.Key)[0]
                });


            ViewBag.lst = categoriesWithItemCountAndImage;
            //foreach (var category in categoriesWithItemCount)
            //{
            //    Console.WriteLine($"{category.Category}: {category.Count}");
            //}
            vm.lstJobLocations = _clsJobLocation.GetAll();

            return View(vm);
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        
    }
}