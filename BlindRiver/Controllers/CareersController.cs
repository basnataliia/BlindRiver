﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//namespace required for file uploads
using System.IO;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    [ValidateInput(false)] //do not validate natively so HTML can be inputted with ckeditor
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
        public ActionResult submitapplication(careerapp App, HttpPostedFileBase resumePath)
        {

            if (resumePath != null && resumePath.ContentLength > 0)
            {
                var fileName = Path.GetFileName(resumePath.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/resumes"), fileName);
                resumePath.SaveAs(path);
                App.resume = fileName;
            }

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

        [Authorize(Users = "admin")]
        public ActionResult JobOpportunitiesManager() {
            var opps = objCareer.getOpps();
            return View(opps);
        }

        [Authorize(Users = "admin")]
        public ActionResult JobApplicationsManager()
        {
            var apps = objApp.getApps();
            return View(apps);
        }

        [Authorize(Users = "admin")]
        public ActionResult CareerManager() {
            return View();
        }

        [Authorize(Users = "admin")]
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

        [Authorize(Users = "admin")]
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

        [Authorize(Users = "admin")]
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

        [Authorize(Users = "admin")]
        public ActionResult DeleteOpp(int id)
        {
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
        public ActionResult DeleteOpp(int id, careeropp opp)
        {
            try
            {
                objCareer.deleteOpp(id);
                return RedirectToAction("JobOpportunitiesManager");
            }
            catch
            {
                return View();
            }
        }

    }
}