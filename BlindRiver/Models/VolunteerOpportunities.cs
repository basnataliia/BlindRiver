using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class VolunteerOpportunities
    {
        VolunteerOpportunitiesDataContext objVolOp = new VolunteerOpportunitiesDataContext();

        public IQueryable<VolunteerOpportunities> getVolOps()
        {
            var allVolOp = objVolOp.Volunteer_Opportunities.Select(x => x);
            return allVolOp;
        }

        public VolunteerOpportunities getVolOpByID(int _id)
        {
            var allVolOP = objVolOp.Volunteer_Opportunities.SingleOrDefault(x => x.id == _id);
            return allVolOP;
        }
    }
}