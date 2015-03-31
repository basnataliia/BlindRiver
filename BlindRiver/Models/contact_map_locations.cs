using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class contact_map_locations
    {
        contact_locationsDataContext objLocation = new contact_locationsDataContext();

        public IEnumerable<contact_location> getLocations()
        {
            var allLocations = objLocation.contact_locations.Select(x => x);
            return allLocations;
        }

        public contact_location getLocationById(int _id)
        {
            var location = objLocation.contact_locations.SingleOrDefault(x => x.id == _id);
            return location;
        }

        public bool commitInsert(contact_location NewLocation)
        {
            objLocation.contact_locations.InsertOnSubmit(NewLocation);
            objLocation.SubmitChanges();
            return true;
        }

        public bool commitDelete(int _id)
        {
            using (objLocation)
            {
                var objDelLocation = objLocation.contact_locations.SingleOrDefault(x => x.id == _id);
                objLocation.contact_locations.DeleteOnSubmit(objDelLocation);
                objLocation.SubmitChanges();
                return true;
            }
        }

        //update
        public bool commitUpdate(int _id, string _title, string _address, string _phone, string _fax, double? _latitude, double? _longitude)
        {
            using (objLocation)
            {
                var objUpLocation = objLocation.contact_locations.Single(x => x.id == _id);
                //setting table column to new value being passed
                objUpLocation.title = _title;
                objUpLocation.address = _address;
                objUpLocation.phone = _phone;
                objUpLocation.fax = _fax;
                objUpLocation.latitude = _latitude;
                objUpLocation.longitude = _longitude;
                //commit update against database
                objLocation.SubmitChanges();
                return true;
            }
        }

    }
}