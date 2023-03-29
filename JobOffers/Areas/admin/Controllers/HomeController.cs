using Bl;
using JobOffers.Areas.admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JobOffers.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    public class HomeController : Controller
    {
        ICategories _ClsCategories;
        IJobLocations _ClsJobLocations;
        IJobTypes _ClsJobTypes;
        IJobDetails _ClsJobDetails;
        IApplyForJob _ClsApplyForJob;
        JobOfferContext context;
        public HomeController(ICategories ClsCategories, IJobLocations ClsJobLocations, IJobTypes ClsJobTypes, IJobDetails ClsJobDetails, IApplyForJob ClsApplyForJob,JobOfferContext ctx)
        {
            _ClsCategories = ClsCategories;
            _ClsJobLocations = ClsJobLocations;
            _ClsJobTypes = ClsJobTypes;
            _ClsJobDetails = ClsJobDetails;
            _ClsApplyForJob = ClsApplyForJob;
            context = ctx;
        }

        public IActionResult Index()
        {
            VmHomePage vm = new VmHomePage();
            vm.lstCategoriesNum = _ClsCategories.GetAll().Count();
            vm.lstLocationsNum = _ClsJobLocations.GetAll().Count();
            vm.lstJobTypesNum = _ClsJobTypes.GetAll().Count();
            vm.lstJobsNum = _ClsJobDetails.GetAll().Count();
            vm.lstApplyedJobsNum = _ClsApplyForJob.GetAll().Count();
            vm.lstUsersNum = context.Users.Count();
            return View(vm);
        }
    }
}
