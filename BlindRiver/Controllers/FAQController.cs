using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    
    public class FAQController : Controller
    {
        FAQLinq objFAQ = new FAQLinq();

        public ActionResult Index()
        {
            var faq = objFAQ.getFAQs();
            return View(faq);
        }

     public ActionResult Insert()
        {
            return View();
        }

     [HttpPost]
     public ActionResult Insert (FAQ faq)
     {
         if (ModelState.IsValid)
         {
             try
             {
                 objFAQ.commitInsert(faq);
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
