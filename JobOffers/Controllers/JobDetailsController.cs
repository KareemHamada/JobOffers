using Bl;
using Domains;
using JobOffers.Utilites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace JobOffers.Controllers
{
    [Authorize(Roles = "Publisher")]
    public class JobDetailsController : Controller
    {
        ICategories _clsCategory;
        IJobDetails _clsJobDetails;
        IJobLocations _clsJobLocation;
        IJobTypes _clsJobTypes;
        IApplyForJob _clsApplyForJob;
        public JobDetailsController(ICategories clsCategory, IJobDetails clsJobDetails, IJobLocations clsJobLocation, IJobTypes clsJobTypes, IApplyForJob clsApplyForJob)
        {
            _clsCategory = clsCategory;
            _clsJobDetails = clsJobDetails;
            _clsJobLocation = clsJobLocation;
            _clsJobTypes = clsJobTypes;
            _clsApplyForJob = clsApplyForJob;
        }

        
        public IActionResult List()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(_clsJobDetails.GetByUserId(userId));
        }

        public IActionResult Edit(int? jobId)
        {
            ViewBag.lstCategories = _clsCategory.GetAll();
            ViewBag.lstLocations = _clsJobLocation.GetAll();
            ViewBag.lstJobTyes = _clsJobTypes.GetAll();
            var jobDetail = new JobDetail();
            if (jobId != null)
                jobDetail = _clsJobDetails.GetById(Convert.ToInt32(jobId));

            return View(jobDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Route("~/admin")]
        public async Task<IActionResult> Save(JobDetail jobDetail, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.lstCategories = _clsCategory.GetAll();
                ViewBag.lstLocations = _clsJobLocation.GetAll();
                ViewBag.lstJobTyes = _clsJobTypes.GetAll();
                return View("Edit", jobDetail);

            }

            if (Files.Count != 0)
                jobDetail.CompanyLogo = await Helper.UploadImage(Files, "Companies");

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            jobDetail.userId = userId;

            _clsJobDetails.Save(jobDetail);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int jobId)
        {
            _clsJobDetails.Delete(jobId);
            return RedirectToAction("List");
        }

        public IActionResult JobApplicants(int jobId)
        {
            var jobApplicants = _clsApplyForJob.GetByJobId(jobId);
            ViewBag.Number = jobApplicants.Count();

            return View(jobApplicants);
        }


        public IActionResult DownloadPdf(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads/PDF", fileName);
            var memoryStream = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memoryStream);
            }
            memoryStream.Seek(0, SeekOrigin.Begin);
            return File(memoryStream, "application/pdf", fileName);
        }
    }
}
