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

        [HttpPost]
        public ActionResult Index(Survey Surveys)
        {
            if (ModelState.IsValid)
            {
                try
                {
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

        public ActionResult Admin()
        {
            var Surveys = objSurvey.getSurvey();
            return View(Surveys);
        }

        public ActionResult Delete(int id)
        {
            var Surveys = objSurvey.getSurveyByID(id);
            if (Surveys == null)
            {
                return View("");
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
