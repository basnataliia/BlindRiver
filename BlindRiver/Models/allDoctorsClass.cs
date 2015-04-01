using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class allDoctorsClass
    {
       doctorsDataContext objDoc = new doctorsDataContext();

        //get all docs from database
        public IEnumerable<doctor> getDocs()
        {
            var allDocs = objDoc.doctors.Select(x => x);
            return allDocs;
        }

        public doctor getDocById(int _id)
        {
            var singleDoc = objDoc.doctors.SingleOrDefault(x => x.Id == _id);
            return singleDoc;
        }

        public bool insertDoctor(doctor doc) { 
            using (objDoc)
            {
                objDoc.doctors.InsertOnSubmit(doc);
                objDoc.SubmitChanges();
                return true;
            }

        }

        public bool deleteDoctor(int _id)
        {
            using (objDoc)
            {
                var delete = objDoc.doctors.Single(x => x.Id == _id);
                objDoc.doctors.DeleteOnSubmit(delete);
                objDoc.SubmitChanges();
                return true;
            }
        }

        public bool updateDoctor(int _id, string _fname, string _lname, string _email, string _phone, string _department, string _title, string _image) {
            using (objDoc) {
                var objUpDoc = objDoc.doctors.Single(x => x.Id == _id);
                objUpDoc.firstName = _fname;
                objUpDoc.lastName = _lname;
                objUpDoc.email = _email;
                objUpDoc.phone = _phone;
                objUpDoc.department = _department;
                objUpDoc.title = _title;
                objUpDoc.image = _image;
                objDoc.SubmitChanges();
                return true;
            }
        }

      
    }
}