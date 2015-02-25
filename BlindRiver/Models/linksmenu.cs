using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class linksmenu
    {
        //creating an instance of the menu object
        menulinksDataContext objMenu = new menulinksDataContext();

                //retrieving all data from "menulinks" table
               public IEnumerable<mainmenulink> getLinks()
                {
                    var allLinks = objMenu.mainmenulinks.Select(x => x);
                    return allLinks.ToList();
                }

                //retrieving  data from "menulinks" table by id (SELECT * FROM menulink WHERE id = "_id")
               public mainmenulink getLinkByID(int _id)
                {
                    var allLink = objMenu.mainmenulinks.SingleOrDefault(x => x.id == _id);
                    return allLink;
                }
    }
}