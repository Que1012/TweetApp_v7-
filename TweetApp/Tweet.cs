using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetApp
{
    class Tweet
    {
        protected String content;
        protected User user;

        public Tweet(String content, User user)
        {
            this.content = content;
            this.user = user;
        }

        public void setContent(String value)
        {
            this.content = value;
        }

        public String getContent()
        {
            return this.content;
        }

        public void setUser(User user)
        {
            this.user = user;
        }

        public User getUser()
        {
            return this.user;
        }
    }
}
