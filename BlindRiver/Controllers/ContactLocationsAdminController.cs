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

        [Authorize(Users = "admin")]
        public ActionResult Index()
        {
            var locations = objLocation.getLocations();
            return View(locations);
        }

        //add new location
        [Authorize(Users = "admin")]
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

        //delete location
        [Authorize(Users = "admin")]
        public ActionResult Delete(int id)
        {
            var location = objLocation.getLocationById(id);
            if (location == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(location);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, contact_location contmessage)
        {
            try
            {
                objLocation.commitDelete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //update location
        [Authorize(Users = "admin")]
        public ActionResult Update(int id)
        {
            var location = objLocation.getLocationById(id);
            if (location == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(location);
            }
        }
        [HttpPost]
        public ActionResult Update(int id, contact_location contlocation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objLocation.commitUpdate(id, contlocation.title, contlocation.address, contlocation.phone, contlocation.fax, contlocation.latitude, contlocation.longitude);
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
