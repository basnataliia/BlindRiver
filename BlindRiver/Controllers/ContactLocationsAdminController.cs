using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class ContactLocationsAdminController : Controller
    {
        contact_map_locations objLocation = new contact_map_locations(); 

        public ActionResult Index()
        {
            var locations = objLocation.getLocations();
            return View(locations);
        }

        //add new location
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(contact_location location)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objLocation.commitInsert(location);
                    return RedirectToAction("Index");
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
