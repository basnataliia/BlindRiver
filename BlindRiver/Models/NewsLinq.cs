using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindRiver.Models
{
    public class NewsLinq
    {
        NewsPostsDataContext newsObj = new NewsPostsDataContext();
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

        //delete
        public bool commitDelete(int _id)
        {
            using (newsObj)
            {
                var bookDel = newsObj.news_posts.Single(x => x.id == _id);
                newsObj.news_posts.DeleteOnSubmit(bookDel);
                newsObj.SubmitChanges();
                return true;
            }
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

        //update
        public bool commitUpdate(int _id, DateTime _date, string _heading, string _details)
        {
            using (newsObj)
            {
                var newsUpdate = newsObj.news_posts.Single(x => x.id == _id);

                newsUpdate.date = _date;
                newsUpdate.heading = _heading;
                newsUpdate.details = _details;
                newsObj.SubmitChanges();
                return true;
            }
        }
    }
}