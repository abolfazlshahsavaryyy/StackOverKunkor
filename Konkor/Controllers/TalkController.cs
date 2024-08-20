using Microsoft.AspNetCore.Mvc;

namespace Konkor.Controllers
{
    public class TalkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
