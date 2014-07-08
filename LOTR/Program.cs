using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace CodeJam
{
    class LOTR
    {
        int GetMinimum(int[] replies)
        {
            //Your code goes here
            int value, count, groups, min = 0;
            int[] distinct = replies.Distinct().ToArray();
            foreach (int d in distinct)
            {
                value = d;
                int[] matchedItems = Array.FindAll(replies, x => x == d);
                value = d;
                count = matchedItems.Length;
                if (count == 1)
                    min = min + (value + 1);
                else
                {
                    if(count%(value+1) == 0)
                        groups = (int)(count / (value + 1));
                    else
                        groups = (int)(count / (value + 1)) + 1;
                    min = min + (groups * (value + 1));
                }
            }
            return min;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            LOTR lotr = new LOTR();
            String input = Console.ReadLine();
            do
            {
                int[] replies = Array.ConvertAll<string, int>(input.Split(','), delegate(string s) { return Int32.Parse(s); });
                Console.WriteLine(lotr.GetMinimum(replies));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion

    }
}