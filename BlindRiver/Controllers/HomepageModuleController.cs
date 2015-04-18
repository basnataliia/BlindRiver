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
        //creating object for homepage module
        HomepageModule objModule = new HomepageModule();
        //creating object for main menu links
        linksmenu objLink = new linksmenu();

        //getting all modules and showing them on Home page as partial view
        [Authorize(Users = "admin")]
        public ActionResult Index()
        {
            var modules = objModule.getModules();
            return View(modules);
        }

        //update homepage module section
        [Authorize(Users = "admin")]
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
            }
        }

        [HttpPost]
        public ActionResult Update(int id, homemodule module, HttpPostedFileBase ImagePath)
        {

            if (ImagePath != null && ImagePath.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ImagePath.FileName);
                //saving path pf the image
                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                ImagePath.SaveAs(path);
                module.image_path = fileName;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    objModule.commitUpdate(id, module.image_path, module.link_url, module.description, module.link_name);

                    //Saving links in ViewBag from mainmenulink table 
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
