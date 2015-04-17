using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;


namespace BlindRiver.Controllers
{
    public class SurveyController : Controller
    {
        //
        // GET: /Survey/
        Surveys objSurvey = new Surveys();

        public ActionResult Index()
        {
            return View();
        }
        //Index page includes the survey users will fill out
        [HttpPost]
        public ActionResult Index(Survey Surveys)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //If users successfully Insert survey, they will be directed back to the Index page
                    objSurvey.commitInsert(Surveys);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        //Admin page will display all survey entries 
         [Authorize(Users = "admin")]
        public ActionResult Admin()
        {
            var Surveys = objSurvey.getSurvey();
            return View(Surveys);
        }

        //Delete page will display selected survey entry that you want to delete by retrieving the id.
         [Authorize(Users = "admin")]
        public ActionResult Delete(int id)
        {
            var Surveys = objSurvey.getSurveyByID(id);
            if (Surveys == null)
            {
                return View();
            }
            else
            {
                return View(Surveys);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, Survey Surveys)
        {
            try
            {
                //Once successfully deleted, user will be redirected to admin page
                objSurvey.commitDelete(id);
                return RedirectToAction("Admin");
            }
            catch
            {
                return View();
            }
        }

    }
}
