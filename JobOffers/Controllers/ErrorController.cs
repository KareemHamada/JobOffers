using Microsoft.AspNetCore.Mvc;

namespace JobOffers.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Handle(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("Error404");
            }
            else
            {
                return View("Error");
            }
        }
    }
}
