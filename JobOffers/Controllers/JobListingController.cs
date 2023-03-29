using Bl;
using Domains;
using JobOffers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JobOffers.Controllers
{
    public class JobListingController : Controller
    {

        ICategories _clsCategory;
        IJobDetails _clsJobDetails;
        IJobLocations _clsJobLocation;
        IJobTypes _clsJobTypes;

        //UserManager<IdentityUser> _userManager;
        public JobListingController(ICategories clsCategory, IJobDetails clsJobDetails, IJobLocations clsJobLocation, IJobTypes clsJobTypes)
        {
            _clsCategory = clsCategory;
            _clsJobDetails = clsJobDetails;
            _clsJobLocation = clsJobLocation;
            _clsJobTypes = clsJobTypes;
        }
        

        public IActionResult Index(int categoryId, List<int> jobTypesIds, int locationId, string salary,string postedDate,string jobNameText, int? pageNumber)
        {
            VmJobListing vm = new VmJobListing();
            List<VwJob> AllJobs = _clsJobDetails.GetAllViews();
            if (categoryId != 0)
            {
                AllJobs = AllJobs.Where(a=>a.categoryId == categoryId).ToList();
            }

            if (jobTypesIds.Count != 0)
            {
                AllJobs = AllJobs.Where(j => jobTypesIds.Contains(j.JobTypeId)).ToList();
            }

            if (locationId != 0)
            {
                AllJobs = AllJobs.Where(a => a.JobLocationId == locationId).ToList();
            }
            if (salary != null)
            {
                if (salary == "MaxLength")
                {
                    AllJobs = AllJobs.OrderByDescending(a=>a.MaxSalary).ToList();
                }
                else if(salary == "MinLength")
                {
                    AllJobs = AllJobs.OrderBy(a=>a.MinSalary).ToList();
                }
               
            }

            if (jobNameText != null)
            {
                
              AllJobs = AllJobs.Where(a => a.JobName.Contains(jobNameText)).ToList();

            }

            //vm.lstAllJobs = AllJobs.OrderBy(a=>a.PostedDate).ToList();
            vm.lstCategories = _clsCategory.GetAll();
            vm.lstJobLocations = _clsJobLocation.GetAll();
            vm.lstJobTypes = _clsJobTypes.GetAll();
            vm.jobNums = AllJobs.Count();



            const int pageSize = 10;
            var dataCount = vm.jobNums;
            vm.TotalPages = (int)Math.Ceiling((double)dataCount / pageSize);
            vm.PageNumber = pageNumber ?? 1;
            if (vm.PageNumber < 1)
            {
                vm.PageNumber = 1;
            }
            if (vm.PageNumber > vm.TotalPages)
            {
                vm.PageNumber = vm.TotalPages;
            }

            vm.lstAllJobs = AllJobs.Skip((vm.PageNumber - 1) * pageSize).Take(pageSize).OrderByDescending(a => a.PostedDate).ToList();


            return View(vm);
        }

    }
}
