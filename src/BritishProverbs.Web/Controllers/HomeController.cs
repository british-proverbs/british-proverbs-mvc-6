using BritishProverbs.Web.Models;
using Microsoft.AspNet.Mvc;

namespace BritishProverbs.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new ProverbViewModel());
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
