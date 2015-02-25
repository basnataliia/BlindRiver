//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace BlindRiver.Models
//{
//    public class brMenu
//    {
//        //creating an instance of the menu object
//        menuDataContext objMenu = new menuDataContext();

//        //retrieving all data from "menulinks" table
//        public IEnumerable<menulink> getLinks()
//        {
//            var allLinks = objMenu.menulinks.Select(x => x);
//            return allLinks.ToList();
//        }

//        //retrieving  data from "menulinks" table by id (SELECT * FROM menulink WHERE id = "_id")
//        public menulink getLinkByID(int _id)
//        {
//            var allLink = objMenu.menulinks.SingleOrDefault(x => x.Id == _id);
//            return allLink;
//        }

//    }
//}