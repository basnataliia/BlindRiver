using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class ServiceLinq
    {
        servicesDataContext serviceObj = new servicesDataContext();

        //IQueryable<linq-tableName>
        public IQueryable<service> getService()
        {
            //varible=object.table_name.select
            var allService = serviceObj.services.Select(x => x);
            return allService;
        }

        public service getServiceByID(int _id)
        {
            var allService = serviceObj.services.SingleOrDefault(x => x.id == _id);
            return allService;
        }

        //insert 
        public bool commitInsert(service services)
        {
            using (serviceObj)
            {
                serviceObj.services.InsertOnSubmit(services);
                serviceObj.SubmitChanges();
                return true;
            }
        }

        //delete
        public bool commitDelete(int _id)
        {
            using (serviceObj)
            {
                var bookDel = serviceObj.services.Single(x => x.id == _id);
                serviceObj.services.DeleteOnSubmit(bookDel);
                serviceObj.SubmitChanges();
                return true;
            }
        }

        //update
        public bool commitUpdate(int _id, string _servicename, string _details, string _photo)
        {
            using (serviceObj)
            {
                var sericveUpdate = serviceObj.services.Single(x => x.id == _id);

                sericveUpdate.service_name = _servicename;
                sericveUpdate.details = _details;
                sericveUpdate.photo = _photo;
                serviceObj.SubmitChanges();
                return true;
            }
        }
    }
}