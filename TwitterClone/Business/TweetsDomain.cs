using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterClone.Entity.DataAccess;
using TwitterClone.Entity.Models;

namespace TwitterClone.Business
{
    public class TweetsDomain
    {
        private TwitterCloneDbContext db = new TwitterCloneDbContext();
        public TweetsDomain()
        {

        }
        public void SetTweetId() { }
        public int GetTweetId()
        {
            return 0;
        }
        public void SetUser(Person person) { }

        public Person GetUser()
        {
            return new Person();
        }
        public void SetMessage(Tweet obj)
        {
            db.Tweet.Add(obj);
            db.SaveChanges();
        }
        public string GetMessage()
        {
            return string.Empty;
        }
        public void SetCreated(DateTime createdate)
        {

        }
        public DateTime GetCreated()
        {
            return DateTime.Now;
        }

    }
}