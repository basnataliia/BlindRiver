//book an appoinment public page 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class bookAppPublic
    {
        //created object of bookAppsDataContext class
        bookAppsDataContext bookObj = new bookAppsDataContext();
        
        //gets all requests(appointment)
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
        //insert form for public user
        public bool commitInsert(bookApp book)
        {
            using (bookObj)
            {
                bookObj.bookApps.InsertOnSubmit(book);
                bookObj.SubmitChanges();
                return true;
            }
        }

    }
}