using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class ContactsAdminController : Controller
    {
        contacts objContact = new contacts(); 

        public ActionResult Index()
        {
            var messsages = objContact.getContacts();
            return View(messsages);
        }

        //delete message
        public ActionResult Delete(int id)
        {
            var messsage = objContact.getContactById(id);
            if (messsage == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(messsage);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, contact contmessage)
        {
            try
            {
                objContact.commitDelete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //uodate
        public ActionResult Update(int id)
        {
            var message = objContact.getContactById(id);
            if (message == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(message);
            }
        }
        [HttpPost]
        public ActionResult Update(int id, contact contmessage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objContact.commitUpdate(id, contmessage.name, contmessage.email, contmessage.phone, contmessage.subject, contmessage.message, contmessage.reviewed);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult Search(string name)
        {           
            return PartialView();
        }

        [HttpPost]
        public ActionResult Search()
        {
            //
            return View("Index");
        }

        //public ViewResult Search(SearchModel searchQuery)
        //{
        //    string result = searchQuery.Text;
        //    var messages = objContact.getContacts()
        //                  .Where(b => b.name == result);
        //                  //.FilterBy(result)
        //    return View(messages);
        //}
    }
}
