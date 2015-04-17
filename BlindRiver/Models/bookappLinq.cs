using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class bookappLinq
    {
        //created object of boolAppsDataContext class
        bookAppsDataContext bookObj = new bookAppsDataContext();

        //gets all requests 
        public IQueryable<bookApp> getRequests()
        {
            var allrequests = bookObj.bookApps.Select(x => x);
            return allrequests;
        }

        public bookApp getRequestByID(int _id)
        {

            var allrequests = bookObj.bookApps.SingleOrDefault(x => x.id == _id);
            return allrequests;
        }

        //takes input from user and add the information to database
        public bool commitInsert(bookApp book)
        {
            using (bookObj)
            {
                bookObj.bookApps.InsertOnSubmit(book);
                bookObj.SubmitChanges();
                return true;
            }
        }

        //delete the particular appointment  based on the selected id
        public bool commitDelete(int _id)
        {
            using (bookObj)
            {
                var bookDel = bookObj.bookApps.Single(x => x.id == _id);
                bookObj.bookApps.DeleteOnSubmit(bookDel);
                bookObj.SubmitChanges();
                return true;
            }
        }

        //selected appoint is updated and changes are saved to database
        public bool commitUpdate(int _id, string _name, string _phone, string _email, DateTime _doa, string _purpose)
        {
            using (bookObj)
            {
                var bookUpdate = bookObj.bookApps.Single(x => x.id == _id);

                bookUpdate.name = _name;
                bookUpdate.phone = _phone;
                bookUpdate.email = _email;
                bookUpdate.doa = _doa;
                bookUpdate.purpose = _purpose;
                bookObj.SubmitChanges();
                return true;
            }

        }
    }
}