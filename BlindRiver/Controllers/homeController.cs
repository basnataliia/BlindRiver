﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class homeController : Controller
    {
        HomepageModule homeModuleObj = new HomepageModule();

        linksmenu menuObj = new linksmenu();

        public homeController()
        {
            //creating an arraynof menu links
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
            //var menuItems = objMenu.getLinks();
            //return PartialView(menuItems);
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

    }
}
