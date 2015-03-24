using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class contact_locations
    {
        contact_locationsDataContext objLocation = new contact_locationsDataContext();

        public IEnumerable<contact_location> getLocations()
        {
            var allLocations = objLocation.contact_locations.Select(x => x);
            return allLocations;
        }
    }
}