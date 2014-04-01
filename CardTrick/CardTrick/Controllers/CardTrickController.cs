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
            get { return HttpContext.Session["cards"] as string ??
                "TC,3S,KH,7H,6C,QH,JD,TD,5S,7D,KD,7C,2S,8C,JH,2D,6D,AH,8H,4S,TS,4D,KC,QD,9H,8S,8D,5D,2C,QC,3D,3C,AS,9D,4C,6H,4H,5C,TH,JC,AC,9C,QS,7S,5H,6S,KS,9S,2H,3H,AD,JS,";
            }
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