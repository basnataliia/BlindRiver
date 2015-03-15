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

    }
}
