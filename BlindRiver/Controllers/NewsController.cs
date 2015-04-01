﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/
        NewsLinq newsObj = new NewsLinq();

        public ActionResult Index()
        {
            //variable=object.fx.
            var indexObj = newsObj.getNews();

            return View(indexObj);
        }

        public ActionResult Details(int id)
        {
            var newsobj = newsObj.getNewsByID(id);
            if (newsobj == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(newsobj);
            }
        }

        public ActionResult NotFound()
        {
            return View();
        }

    }
}
