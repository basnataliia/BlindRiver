using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class custompages
    {
        customPageDataContext objCustPage = new customPageDataContext();

        //get all pages for admin CMS listings
        public IEnumerable<custompage> getPages()
        {
            var allPages = objCustPage.custompages.Select(x => x);
            return allPages;
        }

        //get custom page by ID
        public custompage getPageById(int _id)
        {
            var singlePage = objCustPage.custompages.SingleOrDefault(x => x.Id == _id);
            return singlePage;
        }

        //insert a new custom page
        public bool insertPage(custompage page)
        {
            using (objCustPage)
            {
                objCustPage.custompages.InsertOnSubmit(page);
                objCustPage.SubmitChanges();
                return true;
            }

        }

        //delete page
        public bool deletePage(int _id)
        {
            using (objCustPage)
            {
                var delete = objCustPage.custompages.Single(x => x.Id == _id);
                objCustPage.custompages.DeleteOnSubmit(delete);
                objCustPage.SubmitChanges();
                return true;
            }
        }

        //update existing custom page
        public bool updatePage(int _id, string _title, string _body, string _img, string _published)
        {
            using (objCustPage)
            {
                var objUpPage = objCustPage.custompages.Single(x => x.Id == _id);
                objUpPage.title = _title;
                objUpPage.body = _body;
                objUpPage.img = _img;
                objUpPage.published = _published;
                objCustPage.SubmitChanges();
                return true;
            }
        }

    }
}