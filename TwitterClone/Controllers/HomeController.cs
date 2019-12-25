using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TwitterClone.Entity.Models;
using TwitterClone.Business;
using TwitterClone.Entity.DataAccess;

namespace TwitterClone.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private TwitterCloneDbContext db = new TwitterCloneDbContext();
        [HttpGet]
        public ActionResult Index(Person person)
        {
            var user = User.Identity.Name;
            //TweetsDomain td = new TweetsDomain();
            var viewModel = new PersonTweetModel
            {
                TweetsList = db.Tweet.ToList(),
                Tweet = new Tweet(),
                Person = new Person(),
                Followers = db.Followings.Count(x => x.user_id==user),
                Following = db.Followings.Count(x => x.following_id == user)

            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult UpdateTweet(PersonTweetModel domainObject)
        {
            var user = User.Identity.Name;
            domainObject.Tweet.UserId = user;
            domainObject.Tweet.Created = DateTime.Now;
            var viewModel = new PersonTweetModel
            {
                TweetsList = domainObject.TweetsList,
                Tweet = domainObject.Tweet,
                Person = domainObject.Person

            };

            TweetsDomain td = new TweetsDomain();
            td.SetMessage(domainObject.Tweet);
            viewModel.TweetsList = db.Tweet.ToList();
            return RedirectToAction("Index","Home");
        }


        public ActionResult NewTweet(PersonTweetModel domainObject)
        {
            var user = User.Identity.Name;
            domainObject.Tweet.UserId = user;
            domainObject.Tweet.Created = DateTime.Now;
            var viewModel = new PersonTweetModel
            {
                TweetsList = domainObject.TweetsList,
                Tweet = domainObject.Tweet,
                Person = domainObject.Person

            };

            TweetsDomain td = new TweetsDomain();
            td.SetMessage(domainObject.Tweet);
            return View(viewModel);
        }

        public ActionResult Following()
        {
            var viewModel = new PersonTweetModel
            {
                TweetsList = db.Tweet.ToList(),
                Tweet = new Tweet(),
                Person = new Person()
            };
            return View(viewModel);
        }

        public ActionResult Followers()
        {
            var viewModel = new PersonTweetModel
            {
                TweetsList = db.Tweet.ToList(),
                Tweet = new Tweet(),
                Person = new Person()
            };
            return View(viewModel);
        }

        public ActionResult Tweets()
        {
            var viewModel = new PersonTweetModel
            {
                TweetsList = db.Tweet.ToList(),
                Tweet = new Tweet(),
                Person = new Person()
            };
            return View(viewModel);
        }

        public ActionResult EditTweet(int id)
        {
            
            var tweet = db.Tweet.Find(id);
            return View(tweet);
        }

        [HttpPost]
        public ActionResult EditTweet(Tweet tweet)
        {
            TweetsDomain td = new TweetsDomain();
            td.UpdateMessage(tweet);
            return RedirectToAction("Index");

        }

        
        public ActionResult DeleteTweet(int id)
        {
            db.Tweet.Remove(db.Tweet.Single(a => a.TweetId == id));
            db.SaveChanges();
           return RedirectToAction("Index");
        }

     
        public ActionResult Search(string userName)
        {
            List<Person> user= new List<Person>();
            user = db.Person.Where(x => x.Fullname.ToLower().Contains(userName.ToLower())).ToList();

            return View(user);
        }

        public ActionResult Follow(string id)
        {
            var user = User.Identity.Name;
            Following following = new Following
            {
                following_id = user,
                user_id = id
                

            };
            db.Followings.Add(following);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}