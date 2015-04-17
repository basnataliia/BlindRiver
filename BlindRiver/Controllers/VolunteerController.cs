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


        //Admin page will retrieve all volunteer opportunities by using getVolOps
        [Authorize(Users = "admin")]
        public ActionResult Admin()
        {
            var VolOp = objVolOp.getVolOps();
            return View(VolOp);
        }

        [Authorize(Users = "admin")]
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
                    //When insert volunteer opportunity is successful, user redirected to Admin page
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

        //Update volunteer Opportunities 
        [Authorize(Users = "admin")]
        public ActionResult Update(int id)
        {
            var VolOp = objVolOp.getVolOpByID(id);
            if (VolOp == null)
            {
                return View();
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
                    // When update success, users are redirected to Admin page
                    return RedirectToAction("Admin");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        //Delete Volunteer Opportunities
        [Authorize(Users = "admin")]
        public ActionResult Delete(int id)
        {
            var VolOp = objVolOp.getVolOpByID(id);
            if (VolOp == null)
            {
                return View();
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
                //when volunteer opportunities successfully deleted, users are redirected to admin page
                objVolOp.commitDelete(id);
                return RedirectToAction("Admin");
            }
            catch
            {
                return View();
            }
        }

        //MODELS FOR VOLUNTEER APPLICATIONS
        //creating new instance
        Volunteer_Apps objVolApp = new Volunteer_Apps();
        [Authorize(Users = "admin")]
        public ActionResult ApplicationAdmin()
        {
            var apps = objVolApp.getVolApps();
            return View(apps);  
        }

        public ActionResult Application()
        {
            return View();
        }
        
        //In application page, this allows the resumes to be uploaded and be enetered into a resume folder in the content folder
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
        [Authorize(Users = "admin")]
        public ActionResult AppDelete(int id)
        {
            var VolApp = objVolApp.getAppById(id);
            if (VolApp == null)
            {
                return View();
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
                //If Volunteer Application successfully delted, redirected to ApplicationAdmin page
                objVolApp.commitDelete(id);
                return RedirectToAction("ApplicationAdmin");
            }
            catch
            {
                return View();
            }
        }
        //Application Update
        [Authorize(Users = "admin")]
        public ActionResult AppUpdate(int id)
        {
            var VolApp = objVolApp.getAppById(id);
            if (VolApp == null)
            {
                return View();
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
                //Volunteer Application update to all fields of database
                try
                {
                    objVolApp.commitUpdate(id, VolApp.First_Name, VolApp.Last_Name, VolApp.Email, VolApp.Phone, VolApp.Address1,
                        VolApp.Address2, VolApp.City, VolApp.Province, VolApp.Postal_Code, VolApp.Position_Code, VolApp.Resume);
                    //If successfully updated, user is redirected to ApplicationAdmin page
                    return RedirectToAction("ApplicationAdmin");
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

