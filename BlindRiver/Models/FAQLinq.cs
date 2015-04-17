using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class FAQLinq
    {   //creating an instance of the LINQ object
        FAQDataContext objFAQ = new FAQDataContext();

        public IQueryable<FAQ> getFAQs()
        {
            //creaing anonymous variable with value being instance of LINQ object
            var allFAQ = objFAQ.FAQs.Select(x => x);
            return allFAQ;
            //return IQueryable<FAQ> for data bound controlt o bind to return allFAQ
        }

        //retrieving FAQ by ID
        public FAQ getFAQByID(int _id)
        {
            var allFAQ = objFAQ.FAQs.SingleOrDefault(x => x.id == _id);
            return allFAQ;
        }

        //creating instance of FAQ table (model) as a parameter
        public bool commitInsert(FAQ faq)
        {
            //to make sure that all the data will be disposed when finished using objFAQ
            using (objFAQ)
            {
                //using model to set table columns to new values being passed and providing it to the insert command
                objFAQ.FAQs.InsertOnSubmit(faq);
                objFAQ.SubmitChanges();
                return true;
            }
        }

        //Update FAQ
        public bool commitUpdate (int _id, string _questions, string _answers)
        {
            using (objFAQ)
            {
                var objUpFAQ = objFAQ.FAQs.Single(x => x.id == _id);
                objUpFAQ.questions = _questions;
                objUpFAQ.answers = _answers;
                //commiting update against database
                objFAQ.SubmitChanges();
                return true;
            }
        }

        //Delete FAQ
        public bool commitDelete(int _id)
        {
            using (objFAQ)
            {
                var objDelFAQ = objFAQ.FAQs.Single(x => x.id == _id);
                //delete command
                objFAQ.FAQs.DeleteOnSubmit(objDelFAQ);
                //Commiting delete against database
                objFAQ.SubmitChanges();
                return true;
            }
        }
    }
}