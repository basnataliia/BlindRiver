using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class CareersController : Controller
    {
        //models for career opportunities
        careers objCareer = new careers();

        public ActionResult index()
        {
            var allCareers = objCareer.getOpps();
            return View(allCareers);
        }

        public ActionResult apply(int id)
        {
            var career = objCareer.getCareerById(id);
            if (career == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(career);
            }
        }

       

        //models for public job applications
        careerApp objApp = new careerApp();

        //submit (insert) job application into careerapps table
        public ActionResult submitapplication()
        {
            return View();
        }

        [HttpPost]
        public ActionResult submitapplication(careerapp App) {
            if (ModelState.IsValid) {
                try
                {
                    objApp.insertApp(App);
                    return View("thanks");
                }
                catch {
                    return View("error");
                }                
            }
            return View();
        }

        

    }
}
