using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class HomepageModuleController : Controller
    {
        HomepageModule objModule = new HomepageModule();

        public ActionResult Index()
        {
            var modules = objModule.getModules();
            return View(modules);
        }

        public ActionResult Update(int id)
        {
            var modules = objModule.getModuleById(id);
            if(modules == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(modules);
            }
        }

        [HttpPost]
        public ActionResult Update(int id, homemodule module)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objModule.commitUpdate(id, module.image_path, module.link_url, module.description, module.link_name);
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
