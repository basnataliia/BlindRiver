using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class ServiceController : Controller
    {
        //
        // GET: /Service/
        //created object of  serviceLinq class
        ServiceLinq serviceObj = new ServiceLinq();

        //gets all the services and displays them on admin index page
        public ActionResult Index()
        {
            var indexObj = serviceObj.getService();
            return View(indexObj);
        }

        //gets details of every service by their id which is selected
        public ActionResult Details(int id)
        {
            var servicesobj = serviceObj.getServiceByID(id);

            if (servicesobj == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(servicesobj);
            }
        }

        //insert is authorised to admin only
        [Authorize(Users = "admin")]
        //insert
        public ActionResult Insert()
        {
            return View();
        }
        //takes values from user and insert into database
        [HttpPost]
        public ActionResult Insert(service services)
        {
           if (ModelState.IsValid)
            {
                try
                {
                    serviceObj.commitInsert(services);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        //delete is authorised to admin user only
        [Authorize(Users = "admin")]
        //deletes the serivce according to which id is selected
        public ActionResult Delete(int id)
        {
            var serviceDel = serviceObj.getServiceByID(id);
            if (serviceDel == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(serviceDel);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, service service)
        {
            try
            {
                serviceObj.commitDelete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //update is also authorised to admin user only 
        [Authorize(Users = "admin")]
        //selected service(by checking its id) is updated 
        public ActionResult Update(int id)
        {
            var serviceUpd = serviceObj.getServiceByID(id);
            if (serviceUpd == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(serviceUpd);
            }
        }

        [HttpPost]
        public ActionResult Update(int id, service serviceUpd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    serviceObj.commitUpdate(id, serviceUpd.service_name, serviceUpd.details, serviceUpd.photo);
                    return RedirectToAction("Details/" + id);
                }
                catch
                {
                    return View();
                }

            }
            return View();
        }

        //not found page is diplayed when 
        public ActionResult NotFound()
        {
            return View();
        }
    }
}
