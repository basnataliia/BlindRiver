using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class NewsLinq
    {
        NewsLinqDataContext newsObj = new NewsLinqDataContext();
        //IQueryable<linq-tableName>
        public IQueryable<news_post> getNews()
        {
            //varible=object.table_name.select
            var allNews = newsObj.news_posts.Select(x => x);
            return allNews;
        }

        public news_post getNewsByID(int _id)
        {
            var allNews = newsObj.news_posts.SingleOrDefault(x => x.id == _id);
            return allNews;
        }

        //insert 
        public bool commitInsert(news_post post)
        {
            using (newsObj)
            {
                newsObj.news_posts.InsertOnSubmit(post);
                newsObj.SubmitChanges();
                return true;
            }
        }
    }
}