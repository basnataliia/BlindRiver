using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class VolunteerOpportunities
    {
        //creating an instance of LINQ object
        VolunteerOpportunitiesDataContext objVolOp = new VolunteerOpportunitiesDataContext();

        public IQueryable<Volunteer_Opportunity> getVolOps()
        {
            //creating variable with its value being instance of LINQ object
            var allVolOp = objVolOp.Volunteer_Opportunities.Select(x => x);
            return allVolOp;
        }

        //retreiving volunteer opportunity by ID
        public Volunteer_Opportunity getVolOpByID(int _id)
        {
            var allVolOP = objVolOp.Volunteer_Opportunities.SingleOrDefault(x => x.id == _id);
            return allVolOP;
        }

        //Insert volunteer opportunity
        public bool commitInsert(Volunteer_Opportunity VolOp)
        {
            //to ensure all data will be disposed of when finished
            using (objVolOp)
            {
                objVolOp.Volunteer_Opportunities.InsertOnSubmit(VolOp);
                //commit insert against database
                objVolOp.SubmitChanges();
                return true;
            }
        }

        //Update volunteer opportunity
        public bool commitUpdate(int _id, string _position, string _description, string _code)
        {
            //to ensure all data will be disposed of when finished
            using (objVolOp)
            {
                var objUpVol = objVolOp.Volunteer_Opportunities.Single(x => x.id == _id);
                objUpVol.position = _position;
                objUpVol.description = _description;
                objUpVol.code = _code;
                //commit update against database
                objVolOp.SubmitChanges();
                return true;
            }
        }

        //delete volunteer opportunity
        public bool commitDelete(int _id)
        {
            //to ensure all data will be disposed of when finished
            using (objVolOp)
            {
                var objDelVol = objVolOp.Volunteer_Opportunities.Single(x => x.id == _id);
                objVolOp.Volunteer_Opportunities.DeleteOnSubmit(objDelVol);
                //commit delete against databaes
                objVolOp.SubmitChanges();
                return true;
            }
        }

    }
}