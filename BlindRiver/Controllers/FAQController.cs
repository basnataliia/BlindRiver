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
    
    public ActionResult Update (int id)
     {
         var faq = objFAQ.getFAQByID(id);
         if(faq == null)
         {
             return View("NotFound");
         }
         else
         {
             return View(faq);
         }
     }
    [HttpPost]
    public ActionResult Update (int id, FAQ faq)
    {
        if (ModelState.IsValid)
        {
            try
            {
                objFAQ.commitUpdate(id, faq.questions, faq.answers);
               // return RedirectToAction("Details/" + id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        return View();
    }
    public ActionResult Delete (int id)
    {
        var faq = objFAQ.getFAQByID(id);
        if (faq == null)
        {
            return View("NotFound");
        }
        else
        {
            return View(faq);
        }
    }
    [HttpPost]
    public ActionResult Delete (int id, FAQ faq)
    {
        try
        {
            objFAQ.commitDelete(id);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    public ActionResult Public()
    {
        var faq = objFAQ.getFAQs();
        return View(faq);
    }

    }
}
