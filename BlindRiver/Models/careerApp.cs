using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class careerApp
    {
        careerappsDataContext objApps = new careerappsDataContext();

        public IEnumerable<careerapp> getApps()
        {
            var allApps = objApps.careerapps.Select(x => x);
            return allApps;
        }

        public careerapp getAppById(int _id)
        {
            var app = objApps.careerapps.SingleOrDefault(x => x.Id == _id);
            return app;
        }

        public bool insertApp(careerapp App) {
            using (objApps) {
                objApps.careerapps.InsertOnSubmit(App);
                    objApps.SubmitChanges();
                return true;
            }
        }

    }
}