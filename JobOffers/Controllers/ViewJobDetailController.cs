using Bl;
using Microsoft.AspNetCore.Mvc;

namespace JobOffers.Controllers
{
    public class ViewJobDetailController : Controller
    {
        IJobDetails _clsJobDetails;
        public ViewJobDetailController(IJobDetails clsJobDetails)
        {
            _clsJobDetails = clsJobDetails;
        }
        public IActionResult Details(int jobId)
        {

            return View(_clsJobDetails.GeViewtById(jobId));
        }
    }
}
