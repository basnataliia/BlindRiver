using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net.Mail;

using BlindRiver.Models;

namespace BlindRiver.Controllers
{
    public class ContactsAdminController : Controller
    {
        contacts objContact = new contacts();
        linksmenu objMenu = new linksmenu();

        public ActionResult Index()
        {
            var messsages = objContact.getContacts();
            return View(messsages);
        }

        [HttpPost]
        public ActionResult Index(string name)
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

        //update
        public ActionResult Update(int id)
        {
            var message = objContact.getContactById(id);
            if (message == null)
            {
                return View("NotFound");
            }
            else
            {
                ViewBag.mainmenulink = objMenu.getLinks();
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

        //email
        public ActionResult Email(int id)
        {
            ViewBag.contact = objContact.getContactById(id);
            return View();
        }

        //gmail HOST
        //source: http://www.c-sharpcorner.com/UploadFile/sourabh_mishra1/sending-an-e-mail-using-Asp-Net-mvc/
        [HttpPost]
        public ViewResult Email(BlindRiver.Models.MailModel _objModelMail, int id)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("blindriverhospital@gmail.com", "br123456");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                //string result = name;
                var messages = objContact.getContactById(id);
                return View("Update", messages);
            }
            else
            {
                return View();
            }
        }

        //Smarterasp.net HOST
        //[HttpPost]
        //public ViewResult Email(BlindRiver.Models.MailModel _objModelMail, int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        MailMessage mail = new MailMessage();
        //        mail.To.Add(_objModelMail.To);
        //        mail.From = new MailAddress(_objModelMail.From);
        //        mail.Subject = _objModelMail.Subject;
        //        string Body = _objModelMail.Body;
        //        mail.Body = Body;
        //        mail.IsBodyHtml = true;
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "mail.startdev.me";
        //        smtp.Port = 587;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.Credentials = new System.Net.NetworkCredential("postmaster@startdev.me", "123");
        //        smtp.EnableSsl = false;
        //        smtp.Send(mail);

        //        var messsages = objContact.getContactById(id);
        //        return View("Update", messsages);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        //search
        public ActionResult Search()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Search(string name)
        {
            try
            {
                var result = objContact.searchContacts(name);
                return RedirectToAction("Index", result);
            }
            catch
            {
                return View();
            }
        }

        //[HttpPost]
        //public ActionResult Search()
        //{
        //    return View("Index");
        //}

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
