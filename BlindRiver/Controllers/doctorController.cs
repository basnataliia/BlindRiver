using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(doctor doc) 
        {
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

        public ActionResult NoFound()
        {
            return View();
        }

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
        public ActionResult Update(int id, doctor doc) {
            if (ModelState.IsValid) {
                try
                {
                    objDoc.updateDoctor(id, doc.firstName, doc.lastName, doc.title, doc.department, doc.email, doc.phone, doc.image);
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
