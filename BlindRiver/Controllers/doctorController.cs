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

    }
}
