using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class careers
    {
        careersClassDataContext objCareer = new careersClassDataContext();

        public IEnumerable<careeropp> getOpps() {
            var allCareers = objCareer.careeropps.Select(x => x);
            return allCareers;
        }

        //get career posting by id, for public view
        public careeropp getCareerById(int _id) {
            var career = objCareer.careeropps.SingleOrDefault(x => x.Id == _id);
            return career;
        }


        //delete job opportunity/listing
        public bool deleteOpp(int _id)
        {
            using (objCareer)
            {
                var delete = objCareer.careeropps.Single(x => x.Id == _id);
                objCareer.careeropps.DeleteOnSubmit(delete);
                objCareer.SubmitChanges();
                return true;
            }
        }

        //create new job opportunity/listing
        public bool AddJobOpportunity(careeropp opp)
        {
            using (objCareer)
            {
                objCareer.careeropps.InsertOnSubmit(opp);
                objCareer.SubmitChanges();
                return true;
            }

        }

        //update job opportunity
        public bool updateOpp(int _id, string _title, string _department, string _description, string _jobtype, string _location, string _jobcode)
        {
            using (objCareer)
            {
                var objUpOpp = objCareer.careeropps.Single(x => x.Id == _id);
                objUpOpp.title = _title;
                objUpOpp.department = _department;
                objUpOpp.description = _description;
                objUpOpp.jobtype = _jobtype;
                objUpOpp.location = _location;
                objUpOpp.jobcode = _jobcode;
                objCareer.SubmitChanges();
                return true;
            }
        }

    }
}