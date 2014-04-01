using System;
using System.Web.Mvc;
using Cards;
using CardTrick.Models;
using TrickResult = CardTrick.Models.TrickResult;

namespace CardTrick.Controllers
{
    public sealed class CardTrickController : Controller
    {
        public string Cards
        {
            get { return HttpContext.Session["cards"] as string; }
            set { HttpContext.Session["cards"] = value; }
        }

        public ActionResult Prime()
        {
            return View(new CardsModel{Cards = Cards});
        }

        [HttpPost]
        public ActionResult Prime(string cards)
        {
            Cards = Deck.Load(cards).Serialize();
            return RedirectToAction("Start");
        }

        public ActionResult Start()
        {
            return View();
        }

        public ActionResult Cut()
        {
            return View();
        }

        public ActionResult Riffle()
        {
            return View();
        }

        public ActionResult Split()
        {
            return View();
        }

        public ActionResult MoveCard()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string cards)
        {
            try
            {
                var result = Trick.Perform(Cards, cards);
                if(result.Card==null)
                    throw new Exception("Sorry, unable to work it out");
                Cards = result.NewKnowledge;
                return RedirectToAction("YourCardIs", new {card = result.Card.ToString()});
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("Error", exception.Message);
                return View(new CardsModel{Cards = cards});
            }
        }

        public ActionResult YourCardIs(string card)
        {
            return View(new TrickResult { CardImage = card + ".png" });
        }
    }
}