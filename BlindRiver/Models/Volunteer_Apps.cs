using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class Volunteer_Apps
    {
        Volunteer_ApplicationDataContext objVolApp = new Volunteer_ApplicationDataContext();

        //public IQueryable<Volunteer_Application> getVolApps()
        public IEnumerable<Volunteer_Application> getContacts()
        {
            var allVolApps = objVolApp.Volunteer_Applications.Select(x => x);
            return allVolApps;
        }
    }
}