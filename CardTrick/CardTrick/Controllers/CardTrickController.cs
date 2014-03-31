using System.Web.Mvc;
using CardTrick.Models;

namespace CardTrick.Controllers
{
    public class CardTrickController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string cards)
        {
            return RedirectToAction("YourCardIs", new {card = "AH"});
        }

        public ActionResult YourCardIs(string card)
        {
            return View(new TrickResult {CardImage = card + ".png"});
        }
    }
}