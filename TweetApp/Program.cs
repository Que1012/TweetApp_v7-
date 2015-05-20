using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Receiving files

            System.IO.StreamReader userFile = new System.IO.StreamReader("C:\\Users\\s207034328\\Downloads\\TweetApp6\\TweetApp\\TweetApp\\Files\\user.txt");
            System.IO.StreamReader tweetFile = new System.IO.StreamReader("C:\\Users\\s207034328\\Downloads\\TweetApp6\\TweetApp\\TweetApp\\Files\\tweet.txt");

            //Extracting and Creating users

            Queue<String> userNameList = new Queue<String>();
            System.Collections.ArrayList users = new System.Collections.ArrayList();

            //Creating followers

            System.IO.StreamReader userFile2 = new System.IO.StreamReader("C:\\Users\\s207034328\\Downloads\\TweetApp6\\TweetApp\\TweetApp\\Files\\user.txt");
            String userLine2;
            int lineCount2 = 0;
            while ((userLine2 = userFile2.ReadLine()) != null)
            {
                String followeeString = userLine2.Substring(userLine2.IndexOf("follows") + 8);
                String follower = (userLine2.Substring(0, userLine2.Length - userLine2.Substring(userLine2.IndexOf("follows")).Length)).Trim();
                User followerUser = new User(follower);
                if (checkDuplicates(followerUser,users) == false)
                    users.Add(followerUser);

                if (followeeString.Contains(","))
                {
                    String[] followees = followeeString.Split(',');
                    for (int i = 0; i < followees.Length; i++)
                    {
                        User newUser = new User(followees[i].Trim());
                        newUser.addFollower(followerUser);
                        if (checkDuplicates(newUser, users) == false)
                            sortList(users, newUser);
                    }
                }
                else
                {
                    User newUser = new User(followeeString.Trim());
                    newUser.addFollower(followerUser);
                    if (checkDuplicates(newUser, users) == false)
                        sortList(users, newUser);
                }
                lineCount2++;
            }

            //Displaying Users

           // for (int i = 0; i < users.Count; i++)
             //   Console.WriteLine(((User)users[i]).name);

            //Acquiring tweets and linking them to users

            String tweetLine;
            Queue<String> tweetQueue = new Queue<string>();
            Queue<User> userList3 = new Queue<User>();
            char[] tweetDelimiters = { '>' };

            while ((tweetLine = tweetFile.ReadLine()) != null)
            {
                String name = (tweetLine.Substring(0, tweetLine.IndexOf('>'))).Trim();
                String tweetValue = tweetLine.Substring(tweetLine.IndexOf('>') + 1);
                Tweet tweet = new Tweet(tweetValue, new User(name));

                for (int i = 0; i < users.Count;i++ )
                {
                    User user = (User)users[i];
                    String userName = (user.name).Trim();
                    if (userName.Equals(name))
                        user.addTweet(tweetValue);
                }
            }
            
            //Displaying tweets

            for (int i = 0; i < users.Count; i++ )
            {
                User user = (User)users[i];
                user.displayTweet();
            }

            userFile.Close();
            userFile2.Close();
            tweetFile.Close();
            Console.ReadLine();
        }

        private static void sortList(System.Collections.ArrayList sortingList, User newUser)
        {

            if (sortingList.Count == 0)
                sortingList[0] = newUser;
            else
            {

                for (int i = 0; i < sortingList.Count; i++)
                {
                    User first = (User)sortingList[i];
                    for (int j = i + 1; j < sortingList.Count; j++)
                    {
                        if (first.name.CompareTo(((User)sortingList[j]).name) < 0)
                        {
                            first = (User)sortingList[j];
                            User dummy = (User)sortingList[j];
                            sortingList[j] = sortingList[i];
                            sortingList[i] = dummy;

                        }
                    }
                }
            }
        }

        private static bool checkDuplicates(User newUser, System.Collections.ArrayList list)
        {
            if (list.Count == 0)
                return false;
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    User curUser = (User)list[i];
                    if (newUser.equals(curUser))
                        return true;
                    else
                        return false;
                }
                return false;
            }
        }
    
    }
}
