using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class contacts
    {
        contactDataContext objContact = new contactDataContext();

        public IEnumerable<contact> getContacts()
        {
            var allContacts = objContact.contacts.Select(x => x);
            return allContacts;
        }

        public contact getContactById(int _id)
        {
            var contactMessage = objContact.contacts.SingleOrDefault(x => x.id == _id);
            return contactMessage;
        }

        public bool commitInsert(contact NewContactMessage)
        {
            objContact.contacts.InsertOnSubmit(NewContactMessage);
            objContact.SubmitChanges();
            return true;
        }

        public bool commitDelete(int _id)
        {
            using (objContact)
            {
                var objDelMessage = objContact.contacts.SingleOrDefault(x => x.id == _id);
                objContact.contacts.DeleteOnSubmit(objDelMessage);
                objContact.SubmitChanges();
                return true;
            }
        }
    }
}