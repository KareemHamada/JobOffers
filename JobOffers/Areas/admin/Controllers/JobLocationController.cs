using Bl;
using Domains;
using JobOffers.Utilites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JobOffers.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    public class JobLocationController : Controller
    {
        IJobLocations _clsJobLocation;
        public JobLocationController(IJobLocations clsJobLocation)
        {
            _clsJobLocation = clsJobLocation;
        }
        public IActionResult List()
        {
            return View(_clsJobLocation.GetAll());
        }

        public IActionResult Edit(int? jobLocationId)
        {
            var jobLocation = new JobLocation();
            if (jobLocationId != null)
                jobLocation = _clsJobLocation.GetById(Convert.ToInt32(jobLocationId));

            return View(jobLocation);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(JobLocation jobLocation)
        {
            if (!ModelState.IsValid)
                return View("Edit", jobLocation);

            _clsJobLocation.Save(jobLocation);
            return RedirectToAction("List");
        }


        public IActionResult Delete(int jobLocationId)
        {
            _clsJobLocation.Delete(jobLocationId);
            return RedirectToAction("List");
        }
    }
}
