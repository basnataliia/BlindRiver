using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class ContactsController : Controller
    {
        contacts objContact = new contacts();


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(contact cont)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    objContact.commitInsert(cont);
                    return RedirectToAction("Thanks");
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("Thanks");
        }

        public ActionResult Thanks()
        {
             if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            } 
        }

        [HttpPost]
        public ActionResult Thanks(contact valid)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", valid);
            }
            else
            {
                return View("Index");
            }
        }

    }
}
