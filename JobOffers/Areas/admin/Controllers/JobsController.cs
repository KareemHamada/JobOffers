using Bl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace JobOffers.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    public class JobsController : Controller
    {
        IJobDetails _clsJobDetails;
        IApplyForJob _clsApplyForJob;

        public JobsController(IJobDetails clsJobDetails, IApplyForJob clsApplyForJob)
        {
            _clsJobDetails = clsJobDetails;
            _clsApplyForJob = clsApplyForJob;

        }

        public IActionResult List()
        {
            return View(_clsJobDetails.GetAllViews());
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
