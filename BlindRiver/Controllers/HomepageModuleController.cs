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

    }
}
