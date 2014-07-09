using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Codejam
{
    class FriendScore
    {
        public int HighestScore(string[] friends)
        {
            int[] totalfriends = new int[friends.Length];
            
            //add normal friends to each other
            AddNormal(friends, totalfriends);
            Add2Friends(friends, totalfriends);
            return totalfriends.Max();
        }

        private void Add2Friends(string[] friends, int[] totalfriends)
        {
            for (int i = 0; i < friends.Length - 1; i++)
            {
                string s1 = friends[i];
                for (int j = i + 1; j < friends.Length; j++)
                {
                    string s2 = friends[j];
                    bool equal = Compare(s1, s2,i,j,friends);
                    if (equal)
                    {
                        totalfriends[i] += 1;
                        totalfriends[j] += 1;
                    }
                }
            }
        }

        private bool Compare(string s1, string s2,int first,int second,string[] friends)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == 'Y' && s1[i] == s2[i])
                    if (friends[first][second] == 'N')
                        return true;
            }
            return false;
        }

        private void AddNormal(string[] friends, int[] totalfriends)
        {
            for (int i = 0; i < friends.Length; i++)
                totalfriends[i] = friends[i].ToCharArray().Count(x => x == 'Y');
            
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            FriendScore friendScore = new FriendScore();
            do
            {
                string[] values = input.Split(',');
                int validationOp = friendScore.HighestScore(values);
                Console.WriteLine(validationOp);
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}