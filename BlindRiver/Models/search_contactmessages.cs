using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class search_contactmessages
    {
    }
      //search functionality
    public class SearchModel
    {
        public string Text { get; set; }
        //public bool reviewed { get; set; }
    }
    public static class SearchModelFilterQueryEx
    {
        public static IQueryable<contact> FilterBy(this IQueryable<contact> query, SearchModel search)
        {
            if (search == null)
                return query;
            if (!String.IsNullOrWhiteSpace(search.Text))
                query = query.Where(b => b.name.Contains(search.Text));
            //if (String.reviewed)
            //    query = query.Where(b => b.reviewed > 0);
            return query;
        }
    }
}