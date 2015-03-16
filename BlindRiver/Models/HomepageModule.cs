using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class HomepageModule
    {
        homemodulesDataContext objModule = new homemodulesDataContext();

        //get all modules from database
        public IEnumerable<homemodule> getModules()
        {
            var allModules = objModule.homemodules.Select(x => x);
            return allModules;
        }

        public homemodule getModuleById(int _id)
        {
            var oneModule = objModule.homemodules.SingleOrDefault(x => x.id == _id);
            return oneModule;
        }

        public bool commitUpdate(int _id, string _imagePath, string _linkUrl, string _description, string _linkName)
        {
            using(objModule)
            {
                var objUpModule = objModule.homemodules.Single(x => x.id == _id);
                //setting table columns to new values being passed
                objUpModule.image_path = _imagePath;
                objUpModule.link_url = _linkUrl;
                objUpModule.description = _description;
                objUpModule.link_name = _linkName;
                //commit update against database
                objModule.SubmitChanges();
                return true;
            }
        }

    }
}