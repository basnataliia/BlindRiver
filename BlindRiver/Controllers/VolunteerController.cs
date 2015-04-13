using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//namespace required for file uploads
using System.IO;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class VolunteerController : Controller
    {

        VolunteerOpportunities objVolOp = new VolunteerOpportunities();
        //
        // GET: /Volunteer/

        public ActionResult Index()
        {
            var VolOp = objVolOp.getVolOps();
            return View(VolOp);
        }

        public ActionResult Admin()
        {
            var VolOp = objVolOp.getVolOps();
            return View(VolOp);
        }


        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Volunteer_Opportunity VolOp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objVolOp.commitInsert(VolOp);
                    return RedirectToAction("Admin");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult Update(int id)
        {
            var VolOp = objVolOp.getVolOpByID(id);
            if (VolOp == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(VolOp);
            }
        }
        [HttpPost]
        public ActionResult Update(int id, Volunteer_Opportunity VolOp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objVolOp.commitUpdate(id, VolOp.position, VolOp.description, VolOp.code);
                    // return RedirectToAction("Details/" + id);
                    return RedirectToAction("Admin");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var VolOp = objVolOp.getVolOpByID(id);
            if (VolOp == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(VolOp);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, Volunteer_Opportunity VolOp)
        {
            try
            {
                objVolOp.commitDelete(id);
                return RedirectToAction("Admin");
            }
            catch
            {
                return View();
            }
        }

        //models for job applications
        Volunteer_Apps objVolApp = new Volunteer_Apps();
        public ActionResult ApplicationAdmin()
        {
            var apps = objVolApp.getVolApps();
            return View(apps);  
        }

        public ActionResult Application()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Application(Volunteer_Application VolApp, HttpPostedFileBase resumePath)
        {
            if (resumePath != null && resumePath.ContentLength > 0)
            {
                var fileName = Path.GetFileName(resumePath.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/resumes"), fileName);
                resumePath.SaveAs(path);
                VolApp.Resume = fileName;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    objVolApp.commitInsert(VolApp);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        //Update and Delete

        public ActionResult AppDelete(int id)
        {
            var VolApp = objVolApp.getAppById(id);
            if (VolApp == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(VolApp);
            }
        }
        [HttpPost]
        public ActionResult AppDelete(int id, Volunteer_Application VolApp)
        {
            try
            {
                objVolApp.commitDelete(id);
                return RedirectToAction("ApplicationAdmin");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AppUpdate(int id)
        {
            var VolApp = objVolApp.getAppById(id);
            if (VolApp == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(VolApp);
            }
        }
        [HttpPost]
        public ActionResult AppUpdate(int id, Volunteer_Application VolApp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objVolApp.commitUpdate(id, objVolApp.First_Name, objVolApp.Last_Name);
                    // return RedirectToAction("Details/" + id);
                    return RedirectToAction("AppAdmin");
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

