using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class allDoctorsClass
    {
       doctorsDataContext objDoc = new doctorsDataContext();

        //get all modules from database
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
    }
}