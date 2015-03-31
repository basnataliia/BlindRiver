using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class VolunteerController : Controller
    {

        VolunteerOpportunities objVolOp = new VolunteerOpportunities();
        //
        // GET: /Volunteer/

        public ActionResult Index()
        {
            var VolOp = objVolOp.getVolOps();
            return View(VolOp);
        }

    }
}
