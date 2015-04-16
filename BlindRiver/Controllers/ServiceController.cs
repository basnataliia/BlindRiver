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
        ServiceLinq serviceObj = new ServiceLinq();

        public ActionResult Index()
        {
            var indexObj = serviceObj.getService();
            return View(indexObj);
        }

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

        //insert
        [Authorize(Users = "admin")]
        public ActionResult Insert()
        {
            return View();
        }

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

        //delete
        [Authorize(Users = "admin")]
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

        //update
        [Authorize(Users = "admin")]
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

    }
}
