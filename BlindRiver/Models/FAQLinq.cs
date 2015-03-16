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
            var allFAQ = objFAQ.FAQs.Select(x => x);
            return allFAQ;
        }

        public FAQ getFAQByID(int _id)
        {
            var allFAQ = objFAQ.FAQs.SingleOrDefault(x => x.id == _id);
            return allFAQ;
        }

        public bool commitInsert(FAQ faq)
        {
            using (objFAQ)
            {
                objFAQ.FAQs.InsertOnSubmit(faq);
                objFAQ.SubmitChanges();
                return true;
            }
        }

        public bool commitUpdate (int _id, string _questions, string _answers)
        {
            using (objFAQ)
            {
                var objUpFAQ = objFAQ.FAQs.Single(x => x.id == _id);
                objUpFAQ.questions = _questions;
                objUpFAQ.answers = _answers;
                objFAQ.SubmitChanges();
                return true;
            }
        }

        public bool commitDelete(int _id)
        {
            using (objFAQ)
            {
                var objDelFAQ = objFAQ.FAQs.Single(x => x.id == _id);
                objFAQ.FAQs.DeleteOnSubmit(objDelFAQ);
                objFAQ.SubmitChanges();
                return true;
            }
        }
    }
}