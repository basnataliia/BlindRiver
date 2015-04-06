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

        //update
        public bool commitUpdate(int _id, string _name, string _email, string _phone, string _subject, string _message, bool _reviewed )
        {
            using (objContact)
            {
                var objUpMessage = objContact.contacts.Single(x => x.id == _id);
                //setting table column to new value being passed
                objUpMessage.name = _name;
                objUpMessage.email = _email;
                objUpMessage.phone = _phone;
                objUpMessage.subject = _subject;
                objUpMessage.message = _message;
                objUpMessage.reviewed = _reviewed;
                //commit update against database
                objContact.SubmitChanges();
                return true;
            }
        }

        //search
        public IQueryable<contact> searchContacts(string _query)
        {
            var allContacts = (from x in objContact.contacts where x.name.Contains(_query) || x.email.Contains(_query) || x.phone.Contains(_query) || x.subject.Contains(_query) || x.message.Contains(_query) select x);
            return allContacts;

        }

    }
}