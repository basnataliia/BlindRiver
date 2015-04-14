using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class servicePublicController : Controller
    {
        //
        // GET: /servicePublic/
        ServiceLinq serviceObj = new ServiceLinq(); 

        public ActionResult Index()
        {
            var servicesobj = serviceObj.getService();

            if (servicesobj == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(servicesobj);
            }
        }

    }
}
