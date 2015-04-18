using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class homeController : Controller
    {
        //creating object for Homepage modules
        HomepageModule homeModuleObj = new HomepageModule();
        //creating object for menu links
        linksmenu menuObj = new linksmenu();
        //creating object for custom pages
        custompages objCustPage = new custompages();

        public homeController()
        {
            //creating an array of menu links
            ViewData["MenuItems"] = menuObj.getLinks();
        }


        //brMenu objMenu = new brMenu();
        ImageSlider objImage = new ImageSlider();

        //Home page view
        public ActionResult Index()
        {
            var img = objImage.getImages();
            return View(img);
        }


        //Main menu - partial view
        public ActionResult menu()
        {
            return PartialView();
        }

        //responsive menu - partial view
        public ActionResult responsiveMenu()
        {
            return PartialView();
        }

        //Slider - partial view
        public ActionResult Slider()
        {
            var img = objImage.getImages();
            return PartialView(img);
        }

        //Home Page Modules - partial view
        public ActionResult HomepageModules()
        {
            var modules = homeModuleObj.getModules();
            return PartialView(modules);
        }

        //get custom pages - partial view
        public ActionResult customPages()
        {
            var pages = objCustPage.getPages();
            return PartialView(pages);
        }

        //get page by id for homepage links to work to custom page URLs
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

        public ActionResult NotFound() {
            return View();
        }

    }
}
