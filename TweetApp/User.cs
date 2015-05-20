using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetApp
{
    class User
    {
        public String name;
        public Queue<User> followers;
        public Queue<String> followerNames;
        public Queue<String> tweets;

        public User(String name)
        {
            followers = new Queue<User>();
            tweets = new Queue<String>();
            followerNames = new Queue<String>();
            this.name = name;
        }

        public void addFollower(User follower)
        {
            if (!followerNames.Contains(follower.name))
            {
                followers.Enqueue(follower);
                followerNames.Enqueue(follower.name);
            }
        }

        public bool equals(User user)
        {
            string newName = user.name.Trim();
            string oldName = this.name.Trim();
            return newName.Equals(oldName);
        }

        public void addTweet(String tweet)
        {
            try
            {
                tweets.Enqueue(tweet);
            }
            catch (Exception e)
            {
                //Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void displayTweet()
        {
            Queue<string> tweets2 = new Queue<string>();
            try
            {
                Console.WriteLine(this.name);
                while (tweets.Count != 0)
                {
                    string tweet = tweets.Dequeue();
                    Console.WriteLine("\t@" + this.name + ": " + tweet);
                    tweets2.Enqueue(tweet);
                }

                while (tweets2.Count != 0)
                    tweets.Enqueue(tweets2.Dequeue()); 

            }
            catch(Exception e)
            { 
                //Console.WriteLine("Exception: " + e.Message); 
            }
        }

    }
}
