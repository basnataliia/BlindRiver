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
        //creatig object for contacts
        contacts objContact = new contacts();
        //creating object for menu links
        linksmenu objMenu = new linksmenu();

        [Authorize(Users = "admin")]
        public ActionResult Index()
        {
            var messsages = objContact.getContacts();
            return View(messsages);
        }

        [HttpPost]
        public ActionResult Index(string query)
        {
            var search_result = objContact.searchContacts(query);
            //var messsages = objContact.getContacts();
            return View(search_result);
        }

        //delete message
        [Authorize(Users = "admin")]
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
        [Authorize(Users = "admin")]
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
        [Authorize(Users = "admin")]
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

        //Smarterasp.net HOST//

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

    
        [Authorize(Users = "admin")]
        public ActionResult Search(string name)
        {
            var search_result = objContact.searchContacts(name);
            return PartialView(search_result);
        }
    }
}
