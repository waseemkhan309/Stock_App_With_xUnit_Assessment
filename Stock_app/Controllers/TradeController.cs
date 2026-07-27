using Microsoft.AspNetCore.Mvc;

namespace Stock_app.Controllers
{
    public class TradeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
