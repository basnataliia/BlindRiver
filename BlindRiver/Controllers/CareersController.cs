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

        public ActionResult JobOpportunitiesManager() {
            var opps = objCareer.getOpps();
            return View(opps);
        }

        public ActionResult JobApplicationsManager()
        {
            var apps = objApp.getApps();
            return View(apps);
        }

        public ActionResult CareerManager() {
            return View();
        }

        public ActionResult ApplicationDetails(int id) {
            var application = objApp.getAppById(id);
            if (application == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(application);
            }
        }

        public ActionResult AddJobOpportunity() {
            return View();
        }

        [HttpPost]
        public ActionResult AddJobOpportunity(careeropp opp) {
            if (ModelState.IsValid)
            {
                try
                {
                    objCareer.AddJobOpportunity(opp);
                    return RedirectToAction("JobOpportunitiesManager");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult EditJobOpportunity(int id) {
            var opp = objCareer.getCareerById(id);
            if (opp == null)
            {
                return View("NoFound");
            }
            else
            {
                return View(opp);
            }
        }

        [HttpPost]
        public ActionResult EditJobOpportunity(int id, careeropp opp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objCareer.updateOpp(id, opp.title, opp.department, opp.description, opp.jobtype, opp.location, opp.jobcode);
                    return RedirectToAction("JobOpportunitiesManager");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

    }
}
