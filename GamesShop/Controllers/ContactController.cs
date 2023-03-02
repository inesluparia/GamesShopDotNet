using Microsoft.AspNetCore.Mvc;

namespace GamesShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
