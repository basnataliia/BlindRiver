using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using BlindRiver.Models;


namespace BlindRiver.Controllers
{
    public class HomepageModuleController : Controller
    {
        HomepageModule objModule = new HomepageModule();
        linksmenu objLink = new linksmenu();

        public ActionResult Index()
        {
            var modules = objModule.getModules();
            return View(modules);
        }

        public ActionResult Update(int id, string name)
        {
            var modules = objModule.getModuleById(id);
            if(modules == null)
            {
                return View("NotFound");
            }
            else
            {
                ViewBag.mainmenulink = objLink.getLinks();
                return View("Update", modules);
                //return View(modules);
            }
        }

        [HttpPost]
        public ActionResult Update(int id, homemodule module, HttpPostedFileBase ImagePath)
        {

            if (ImagePath != null && ImagePath.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ImagePath.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                ImagePath.SaveAs(path);
                module.image_path = fileName;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    objModule.commitUpdate(id, module.image_path, module.link_url, module.description, module.link_name);


                    ViewBag.mainmenulink = objLink.getLinks();
                    //return View("Index");
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
