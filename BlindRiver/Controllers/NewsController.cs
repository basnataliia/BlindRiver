//admin page 
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
        //created object of NewsLinq class
        NewsLinq newsObj = new NewsLinq();

        //gets all the news as list 
        // and is sent to the view
        public ActionResult Index()
        {
            //variable=object.fx.
            var indexObj = newsObj.getNews();

            return View(indexObj);
        }

        //shows a news that has been selecte
        //and displays all its details
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

        //insert shows the admin a form to insert news
        [Authorize(Users = "admin")]
        public ActionResult Insert()
        {
            return View();
        }

        // insert post, the form value is inserted in the database
        // that has been sent by the admin
        [HttpPost]
        public ActionResult Insert(news_post post)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    post.date = DateTime.Now;
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
        // shows the details of the news record that has been requested 
        // for deletion
        [Authorize(Users = "admin")]
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

        // delete post, deletes the record that has been selected
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
        // shows a form to the admin where details of the record are display
        // that needs to be updated
        [Authorize(Users = "admin")]
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

        // update post
        // the changed values in the form has been sent to the db,
        // and is updated against the particular record.
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
        // this view is display when a page is not found
        public ActionResult NotFound()
        {
            return View();
        }

    }
}