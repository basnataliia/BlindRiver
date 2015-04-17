//Public page controller for service page
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//includes model
using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class servicePublicController : Controller
    {
        //
        // GET: /servicePublic/

        //created object of serviceLinq class
        ServiceLinq serviceObj = new ServiceLinq(); 

        //gets all the services and display on the view
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
