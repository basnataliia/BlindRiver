using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class SliderAdminController : Controller
    {
        Models.ImageSlider objImage = new Models.ImageSlider();
        linksmenu objLink = new linksmenu();

        [Authorize(Users = "Natalie")]
        public ActionResult test()
        {
            return View();
        }

       
        public ActionResult Index()
        {
            var img = objImage.getImages();
            return View(img);
        }

        //insert
        public ActionResult Insert()
        {
            ViewBag.mainmenulink = objLink.getLinks();
            return View();
        }

        [HttpPost]
        public ActionResult Insert(sliderimage img, HttpPostedFileBase ImagePath)
        {
            if (ImagePath != null && ImagePath.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ImagePath.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                ImagePath.SaveAs(path);
                img.ImagePath = fileName;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    objImage.commitInsert(img);
                    //Saving links in ViewBag from mainmenulink table 
                    ViewBag.mainmenulink = objLink.getLinks();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

//update
        public ActionResult ImageEdit(int id)
        {
            var image = objImage.getImageById(id);
            if (image == null)
            {
                return View("NotFound");
            }
            else
            {
                ViewBag.mainmenulink = objLink.getLinks();
                return View(image);
            }
        }

        [HttpPost]
        public ActionResult ImageEdit(int id, sliderimage image, HttpPostedFileBase ImagePath)
        {

            if (ImagePath != null && ImagePath.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ImagePath.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                ImagePath.SaveAs(path);
                image.ImagePath = fileName;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    objImage.commitUpdate(id, image.ImagePath, image.Title, image.Description, image.Link);

                    //Saving links in ViewBag from mainmenulink table 
                    ViewBag.mainmenulink = objLink.getLinks();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }


//delete
        public ActionResult DeleteImage(int Id)
        {
            var img = objImage.getImageById(Id);
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
                objImage.commitDelete(Id);
                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }

        }

    }
}
