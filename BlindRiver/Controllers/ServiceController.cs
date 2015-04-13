using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//namespace required for file (images are being uploaded) uploads
using System.IO;

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
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(service services, HttpPostedFileBase picLocation)
        {
            //for pic upload
            if (picLocation != null && picLocation.ContentLength > 0)
            {
                var servicePicName = Path.GetFileName(picLocation.FileName);

                var location = Path.Combine(Server.MapPath("~/Content/servicePics"), servicePicName);
                picLocation.SaveAs(location);
                services.photo = servicePicName;
            }

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
