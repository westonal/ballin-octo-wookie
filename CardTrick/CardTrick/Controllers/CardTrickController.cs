using System.Web.Mvc;

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
            return RedirectToAction("SubmitTrick");
        }

        public ActionResult SubmitTrick(string cards)
        {
            return View();
        }
    }
}