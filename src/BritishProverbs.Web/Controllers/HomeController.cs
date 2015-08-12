using System.Threading.Tasks;
using BritishProverbs.Domain;
using BritishProverbs.Web.Models;
using Microsoft.AspNet.Mvc;

namespace BritishProverbs.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBritishProverbsContext _context;

        public HomeController(IBritishProverbsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var proverb = await _context.GetRandomAsync();

            return View(new ProverbViewModel
            {
                Content = proverb.Content
            });
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
