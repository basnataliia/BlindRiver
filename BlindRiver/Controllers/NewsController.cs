using System;
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

        //insert
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(news_post post)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    newsObj.commitInsert(post);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        //delete
        public ActionResult Delete(int id)
        {
            var newsDel = newsObj.getNewsByID(id);
            if (newsDel == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(newsDel);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, news_post news)
        {
            try
            {
                newsObj.commitDelete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //update
        public ActionResult Update(int id)
        {
            var newsUpd = newsObj.getNewsByID(id);
            if (newsUpd == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(newsUpd);
            }
        }

        [HttpPost]
        public ActionResult Update(int id, news_post newsUpd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    newsObj.commitUpdate(id, newsUpd.date, newsUpd.heading, newsUpd.details);
                    return RedirectToAction("Details/" + id);
                }
                catch
                {
                    return View();
                }

            }
            return View();
        }

        //not found
        public ActionResult NotFound()
        {
            return View();
        }

    }
}