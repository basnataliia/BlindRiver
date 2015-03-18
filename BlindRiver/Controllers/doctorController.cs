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

    }
}
