using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CardTrick.Controllers
{
    public class CardsToImagesController : ApiController
    {
        public IEnumerable<string> GetAll()
        {
            return new string[] { "1.png", "2.png" };
        }

        public IEnumerable<string> GetSingle(string id)
        {
            return new string[] { "1.png", "2.png", id };
        }
    }
}
