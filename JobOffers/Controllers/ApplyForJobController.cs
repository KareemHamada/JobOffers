using Bl;
using Domains;
using JobOffers.Utilites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobOffers.Controllers
{
    [Authorize(Roles = ("Searcher"))]
    public class ApplyForJobController : Controller
    {

        IApplyForJob _clsApplyForJob;
        JobOfferContext context;

        public ApplyForJobController(IApplyForJob clsApplyForJob,JobOfferContext ctx)
        {
            _clsApplyForJob = clsApplyForJob;
            context = ctx;
        }
        public IActionResult List()
        {
            return View(_clsApplyForJob.GetByUserId(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        public IActionResult Edit(int jobId, int? applyForJobId)
        {
            ApplyForJob applyJob = new ApplyForJob();
            if (applyForJobId != null)
                applyJob = _clsApplyForJob.GetById(Convert.ToInt32(applyForJobId));
            else
                applyJob.JobDetailId = jobId;

            //applyJob.ApplyForJobId = applyForJobId;

            ViewBag.Result = TempData["Result"];

            return View(applyJob);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ApplyForJob job, IFormFile File)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }

            if(job.ApplyForJobId == 0)
            {
                job.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var check = context.TbApplyForJobs.Where(a => a.JobDetailId == job.JobDetailId && a.UserId == job.UserId && a.CurrentState == 1).ToList();
                if (check.Count > 0)
                {
                    TempData["Result"] = "Error";
                    return RedirectToAction("Edit");
                }
            }
            


            if (File.Length != 0)
                job.PdfResume = await Helper.UploadPDF(File, "PDF");

            _clsApplyForJob.Save(job);


            TempData["Result"] = "Success";

            //return;
            return RedirectToAction("Edit");
        }

        public IActionResult Delete(int applyForJobId)
        {
            _clsApplyForJob.Delete(applyForJobId);
            return RedirectToAction("List");
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
