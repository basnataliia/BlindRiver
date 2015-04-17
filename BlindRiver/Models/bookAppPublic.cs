using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class bookAppPublic
    {
        bookAppsDataContext bookObj = new bookAppsDataContext();

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
        //insert 
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