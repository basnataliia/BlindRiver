using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class newsPublicController : Controller
    {
        //
        // GET: /newsPublic/
        //created object of NewsLinq class
        NewsLinq newsObj = new NewsLinq();

        //gets all news and displays the news 
        public ActionResult Index()
        {
            //variable=object.fx.
            var indexObj = newsObj.getNews();

            return View(indexObj);
        }

    }
}
