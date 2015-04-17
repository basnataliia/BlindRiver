//admin page for  book an appointment
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
        //created object of bookappLinq class
        bookappLinq bookObj = new bookappLinq();

        //admin user is authorised
        [Authorize(Users="admin")]
        //all the appoinments are display to the admin user
        public ActionResult Index()
        {
            var indexObj = bookObj.getRequests();

            return View(indexObj);
        }

        //details
        [Authorize(Users = "admin")]
        //admin can select any appointment to see the details of that patient
        public ActionResult Details(int id)
        {
            var bookDetail = bookObj.getRequestByID(id);
            if (bookDetail == null)
            {
                return View("Not Found");
            }
            else
            {
                return View(bookDetail);
            }
        }

      
        //delete
        [Authorize(Users = "admin")]
        //admin has authorisation to delete the appointment if it is not valid one
        public ActionResult Delete(int id)
        {
            var bookDel = bookObj.getRequestByID(id);
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
        [Authorize(Users = "admin")]
        //admin can update the appointment in case of any changes
        public ActionResult Update(int id)
        {
            var bookUpd = bookObj.getRequestByID(id);
            if (bookUpd == null)
            {
                return View("Not Found");
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
                    return View();
                }

            }
            return View();
        }

        //this page is displayed when page is not found
        public ActionResult NotFound()
        {
            return View();
        }
    }
}
