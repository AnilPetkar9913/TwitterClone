﻿using System.Collections.Generic;

namespace TwitterClone.Entity.Models
{
    public class PersonTweetModel
    {
        public IEnumerable<Tweet> TweetsList { get; set; }
        public Tweet Tweet { get; set; }
        public Person Person { get; set; }

    }
}