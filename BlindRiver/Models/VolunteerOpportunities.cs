using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class VolunteerOpportunities
    {
        VolunteerOpportunitiesDataContext objVolOp = new VolunteerOpportunitiesDataContext();

        public IQueryable<Volunteer_Opportunity> getVolOps()
        {
            var allVolOp = objVolOp.Volunteer_Opportunities.Select(x => x);
            return allVolOp;
        }

        public Volunteer_Opportunity getVolOpByID(int _id)
        {
            var allVolOP = objVolOp.Volunteer_Opportunities.SingleOrDefault(x => x.id == _id);
            return allVolOP;
        }

        public bool commitInsert(Volunteer_Opportunity VolOp)
        {
            using (objVolOp)
            {
                objVolOp.Volunteer_Opportunities.InsertOnSubmit(VolOp);
                objVolOp.SubmitChanges();
                return true;
            }
        }

        public bool commitUpdate(int _id, string _position, string _description, string _code)
        {
            using (objVolOp)
            {
                var objUpVol = objVolOp.Volunteer_Opportunities.Single(x => x.id == _id);
                objUpVol.position = _position;
                objUpVol.description = _description;
                objUpVol.code = _code;
                objVolOp.SubmitChanges();
                return true;
            }
        }

        public bool commitDelete(int _id)
        {
            using (objVolOp)
            {
                var objDelVol = objVolOp.Volunteer_Opportunities.Single(x => x.id == _id);
                objVolOp.Volunteer_Opportunities.DeleteOnSubmit(objDelVol);
                objVolOp.SubmitChanges();
                return true;
            }
        }
    }
}