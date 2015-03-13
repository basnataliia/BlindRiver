﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class adminController : Controller
    {
        Models.ImageSlider dbproduct = new Models.ImageSlider();

        [Authorize(Users = "Natalie")]
        public ActionResult test()
        {
            return View();
        }

       
        public ActionResult sliderAdmin()
        {
            var img = dbproduct.getImages();
            return View(img);
        }

        [HttpPost]
        public ActionResult sliderAdmin(HttpPostedFileBase ImagePath)
        {
            if (ImagePath != null && ImagePath.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ImagePath.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                ImagePath.SaveAs(path);

                var NewProduct = new sliderimage();
                //NewProduct.ImagePath = path;
                NewProduct.ImagePath = fileName;
                dbproduct.commitInsert(NewProduct);
            }

            return RedirectToAction("sliderAdmin");
        }

        public ActionResult ImageEdit(int Id)
        {
            var img = dbproduct.getImageById(Id);
            if (img == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(img);
            }

        }

        public ActionResult DeleteImage(int Id)
        {
            var img = dbproduct.getImageById(Id);
            if(img == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(img);
            }
        }

        [HttpPost]
        public ActionResult DeleteImage(int Id, sliderimage img)
        {
            try
            {
                dbproduct.commitDelete(Id);
                return RedirectToAction("sliderAdmin");
            }

            catch
            {
                return View();
            }

        }

    }
}
