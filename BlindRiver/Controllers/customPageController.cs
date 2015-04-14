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
    [ValidateInput(false)] //do not validate natively so HTML can be inputted with ckeditor
    public class customPageController : Controller
    {
        custompages objPage = new custompages();

        [Authorize(Users = "admin")]
        public ActionResult Index()
        {
            var pages = objPage.getPages();
            return View(pages);
        }

        public ActionResult PageDetails(int id)
        {
            var pageD = objPage.getPageById(id);
            if (pageD == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(pageD);
            }
        }

        [Authorize(Users = "admin")]
        public ActionResult InsertPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertPage(custompage page, HttpPostedFileBase img)
        {
            if (img != null && img.ContentLength > 0)
            {
                var fileName = Path.GetFileName(img.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                img.SaveAs(path);
                page.img = fileName;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    objPage.insertPage(page);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View("InsertPage");
        }

        [Authorize(Users = "admin")]
        public ActionResult DeletePage(int id)
        {
            var doc = objPage.getPageById(id);
            if (doc == null)
            {
                return View("Error");
            }
            else
            {
                return View(doc);
            }
        }


        [HttpPost]
        public ActionResult DeletePage(int id, custompage page)
        {
            try
            {
                objPage.DeletePage(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Users = "admin")]
        public ActionResult UpdatePage(int id)
        {
            var page = objPage.getPageById(id);
            if (page == null)
            {
                return View("Index");
            }
            else
            {
                return View(page);
            }
        }

        [HttpPost]
        public ActionResult UpdatePage(int id, custompage page, HttpPostedFileBase imgPath)
        {

            if (imgPath != null && imgPath.ContentLength > 0)
            {
                var fileName = Path.GetFileName(imgPath.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                imgPath.SaveAs(path);
                page.img = fileName;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    objPage.updatePage(id, page.title, page.body, page.img, page.published);
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
