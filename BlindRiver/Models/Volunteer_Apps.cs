using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class Volunteer_Apps
    {
        //creating an instance of LINQ object
        Volunteer_ApplicationDataContext objVolApps = new Volunteer_ApplicationDataContext();


        public IEnumerable<Volunteer_Application> getVolApps()
        {
            //creating a variable with its value being the isntance of LINQ object
            var allVolApps = objVolApps.Volunteer_Applications.Select(x => x);
            return allVolApps;
        }

        //retreiving Volunteer applications by ID
        public Volunteer_Application getAppById(int _id)
        {
            var allVolApps = objVolApps.Volunteer_Applications.SingleOrDefault(x => x.id == _id);
            return allVolApps;
        }

        //Committing insert into database
        public bool commitInsert(Volunteer_Application VolApp)
        {
            //to ensure all data will be disposed of when finished
            using (objVolApps)
            {
                objVolApps.Volunteer_Applications.InsertOnSubmit(VolApp);
                objVolApps.SubmitChanges();
                return true;
            }
        }
        //Manage Volunteer Applications Update
        public bool commitUpdate(int _id, string _First_Name, string _Last_Name, string _Email, string _Phone, string _Address1, 
        string _Address2, string _City, string _Province, string _Postal_Code, string _Position_Code, string _Resume)
        {
            //to ensure all data will be disposed of when finished
            using (objVolApps)
            {
                var objUpVolApps = objVolApps.Volunteer_Applications.Single(x => x.id == _id);
                objUpVolApps.First_Name = _First_Name;
                objUpVolApps.Last_Name = _Last_Name;
                objUpVolApps.Email = _Email;
                objUpVolApps.Phone = _Phone;
                objUpVolApps.Address1 = _Address1;
                objUpVolApps.Address2 = _Address2;
                objUpVolApps.City = _City;
                objUpVolApps.Province = _Province;
                objUpVolApps.Postal_Code = _Postal_Code;
                objUpVolApps.Position_Code = _Position_Code;
                objUpVolApps.Resume = _Resume;
                //commit update against database
                objVolApps.SubmitChanges();
                return true;
            }
        }

        //commiting delete 
        public bool commitDelete(int _id)
        {
            //to ensure all data will be disposed of when finished
            using (objVolApps)
            {
                var objDelVolApps = objVolApps.Volunteer_Applications.Single(x => x.id == _id);
                objVolApps.Volunteer_Applications.DeleteOnSubmit(objDelVolApps);
                //commit delete against database
                objVolApps.SubmitChanges();
                return true;
            }
        }
    }
}