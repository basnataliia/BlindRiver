using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class careers
    {
        careersClassDataContext objCareer = new careersClassDataContext();

        public IEnumerable<careeropp> getOpps() {
            var allCareers = objCareer.careeropps.Select(x => x);
            return allCareers;
        }

        public careeropp getCareerById(int _id) {
            var career = objCareer.careeropps.SingleOrDefault(x => x.Id == _id);
            return career;
        }

    }
}