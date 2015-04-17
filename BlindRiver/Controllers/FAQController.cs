using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    
    public class FAQController : Controller
    {   //creating an instance of LINQ object
        FAQLinq objFAQ = new FAQLinq();
         [Authorize(Users = "admin")]
        public ActionResult Index()
        {
            var faq = objFAQ.getFAQs();
            return View(faq);
        }

    //Insert FAQ
        [Authorize(Users = "admin")]
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
                 //after successfully inserting, it directs to Index page
             }
             catch
             {
                 return View();
             }
         }
         return View();
     }
    
     //Update FAQ
    [Authorize(Users = "admin")]
    public ActionResult Update (int id)
     {
         var faq = objFAQ.getFAQByID(id);
         if(faq == null)
         {
             return View();
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
               //After successfully updating, redirects to Index page
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        return View();
    }

    //Delete FAQ
    [Authorize(Users = "admin")]
    public ActionResult Delete (int id)
    {
        var faq = objFAQ.getFAQByID(id);
        if (faq == null)
        {
            return View();
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
            //after succesfully deleting, redirect to Index page
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
    //Public page
    public ActionResult Public()
    {
        var faq = objFAQ.getFAQs();
        return View(faq);
    }

    }
}
