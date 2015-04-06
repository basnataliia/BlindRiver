using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class Volunteer_Apps
    {
        Volunteer_ApplicationDataContext objVolApps = new Volunteer_ApplicationDataContext();


        public IEnumerable<Volunteer_Application> getVolApps()
        {
            var allVolApps = objVolApps.Volunteer_Applications.Select(x => x);
            return allVolApps;
        }

        public Volunteer_Apps getAppById(int _id)
        {
            var allVolapps = objVolApps.Volunteer_Applications.SingleOrDefault(x => x.id == _id);
            return allVolapps;
        }
    }
}