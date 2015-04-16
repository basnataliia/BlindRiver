using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class bookAppPublic
    {
        bookAppsDataContext bookObj = new bookAppsDataContext();

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