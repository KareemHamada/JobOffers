using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JobOffers.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    public class JobTypeController : Controller
    {
        IJobTypes _clsIJobType;
        public JobTypeController(IJobTypes clsIJobType)
        {
            _clsIJobType = clsIJobType;
        }
        public IActionResult List()
        {
            return View(_clsIJobType.GetAll());
        }

        public IActionResult Edit(int? jobTypeId)
        {
            var jobType = new JobType();
            if (jobTypeId != null)
                jobType = _clsIJobType.GetById(Convert.ToInt32(jobTypeId));

            return View(jobType);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(JobType jobType)
        {
            if (!ModelState.IsValid)
                return View("Edit", jobType);

            _clsIJobType.Save(jobType);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int jobTypeId)
        {
            _clsIJobType.Delete(jobTypeId);
            return RedirectToAction("List");
        }
    }
}
