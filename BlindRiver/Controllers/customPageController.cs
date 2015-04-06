using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//namespace for images
using System.IO;
using BlindRiver.Models;
namespace BlindRiver.Controllers
{
    public class customPageController : Controller
    {
        custompages objCustPage = new custompages();


        public ActionResult Index()
        {
            var pages = objCustPage.getPages();
            return View(pages);
        }

        public ActionResult PageDetails(int id)
        {
            var pageD = objCustPage.getPageById(id);
            if (pageD == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(pageD);
            }
        }

       

    }
}
