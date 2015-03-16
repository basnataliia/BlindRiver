using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class BookAppController : Controller
    {
        //
        // GET: /BookApp/

        bookappLinq bookObj = new bookappLinq();

        public ActionResult Index()
        {
            return View();
        }

        //details
       public ActionResult Details(int id)
        {
            var bookDetail = bookObj.getRequeststByID(id);
            if (bookDetail == null)
            {
                return View("Index");
            }
            else
            {
                return View(bookDetail);
            }
        }

        //insert
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(bookApp book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bookObj.commitInsert(book);
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
        public ActionResult Delete(int id)
        {
            var bookDel = bookObj.getRequeststByID(id);
            if (bookDel == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(bookDel);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, bookApp book)
        {
            try
            {
                bookObj.commitDelete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //update
        public ActionResult Update(int id)
        {
            var bookUpd = bookObj.getRequeststByID(id);
            if (bookUpd == null)
            {
                return View();
            }
            else
            {
                return View(bookUpd);
            }
        }

        [HttpPost]
        public ActionResult Update(int id, bookApp bookUpd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bookObj.commitUpdate(id, bookUpd.name, bookUpd.phone, bookUpd.email, bookUpd.doa, bookUpd.purpose);
                    return RedirectToAction("Details/" + id);
                }
                catch
                {
                    return View("Not Found");
                }
                
            }
            return View();
        }
    }
}
