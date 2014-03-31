using System.Collections.Generic;
using System.Web.Http;
using Cards;

namespace CardTrick.Controllers
{
    public class CardsToImagesController : ApiController
    {
        public IEnumerable<string> GetAll()
        {
            return new string[] {};
        }

        public IEnumerable<string> GetSingle(string id)
        {
            var result = new List<string>();
            var d = Deck.Load(id);
            while (!d.IsEmpty())
            {
                var card = d.TakeCard();
                if (card != null)
                    result.Add(card + ".png");
                else
                    result.Add("53.png");
            }
            return result.ToArray();
        }
    }
}