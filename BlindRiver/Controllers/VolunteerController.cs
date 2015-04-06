using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        //models for public job applications
        Volunteer_Application objVolApp = new Volunteer_Application();

        public ActionResult ApplicationAdmin()
        {
            var apps = objApp.getVolApps();
            return View(apps);
        }

    }
}
