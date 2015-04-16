using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class bookAppPublicController : Controller
    {
        //
        // GET: /bookAppPublic/


        bookappLinq bookObj = new bookappLinq();     

        //insert
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(bookApp book)
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
            else
            {
                return View();
            }
        }
    }
}
