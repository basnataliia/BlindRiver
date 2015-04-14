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
    public class doctorController : Controller
    {
        allDoctorsClass objDoc = new allDoctorsClass();


        public ActionResult Index()
        {
            var allDocs = objDoc.getDocs();
            return View(allDocs);
        }

        [Authorize(Users = "admin")]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(doctor doc, HttpPostedFileBase imgPath) 
        {
            if (imgPath != null && imgPath.ContentLength > 0)
            {
                var fileName = Path.GetFileName(imgPath.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                imgPath.SaveAs(path);
                doc.image = fileName;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    objDoc.insertDoctor(doc);
                    return RedirectToAction("Index");
                }
                catch {
                    return View();
                }
            }
            return View();
        }

        [Authorize(Users = "admin")]
        public ActionResult Manager() {
            var doc = objDoc.getDocs();
            return View(doc);
        }

        //public ActionResult Details(int Id)
        //{
        //    var Doctor = objDoc.getDocById(Id);
        //    if (Doctor == null)
        //    {
        //        return View("Index");
        //    }
        //    else
        //    {
        //        return View(Doctor);
        //    }
        //}

        [Authorize(Users = "admin")]
        public ActionResult Delete(int id)
        {
            var doc = objDoc.getDocById(id);
            if (doc == null)
            {
                return View("NoFound");
            }
            else
            {
                return View(doc);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, doctor doc) {
            try
            {
                objDoc.deleteDoctor(id);
                return RedirectToAction("Manager");
            }
            catch {
                return View();
            }
        }

        [Authorize(Users = "admin")]
        public ActionResult NoFound()
        {
            return View();
        }

        [Authorize(Users = "admin")]
        public ActionResult Update(int id) {
            var doc = objDoc.getDocById(id);
            if (doc == null)
            {
                return View("NoFound");
            }
            else {
                return View(doc);
            }
        }

        [HttpPost]
        public ActionResult Update(int id, doctor doc, HttpPostedFileBase imgPath)
        {

            if (imgPath != null && imgPath.ContentLength > 0)
            {
                var fileName = Path.GetFileName(imgPath.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                imgPath.SaveAs(path);
                doc.image = fileName;
            }

            if (ModelState.IsValid) {
                try
                {
                    objDoc.updateDoctor(id, doc.firstName, doc.lastName, doc.email, doc.phone, doc.department, doc.title, doc.image);
                    return RedirectToAction("Manager");
                }
                catch {
                    return View();
                }
            }
            return View();
        }

    }
}
