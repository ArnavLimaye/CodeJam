using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;

namespace CodeJam
{
    class Pool
    {
        int RackMoves(int[] triangle)
        {
            //Your code goes here
            int[] type1 = { 0, 3, 5, 7, 9, 10, 12 };
            int[] type2 = { 1, 2, 6, 8, 11, 13, 14 };
            int solids = 0;
            int stripes = 0;
            int move = 0;
            if (triangle[4] != 8)
                move++;
            if (triangle[10] < 8)
            {
                foreach (int t in type1)
                    if (triangle[t] >= 8)
                        solids++;
                foreach (int t in type2)
                    if (triangle[t] < 8)
                        stripes++;                 
            }
            else if (triangle[10] > 8)
            {
                foreach (int t in type1)
                    if (triangle[t] <= 8)
                        stripes++;
                foreach (int t in type2)
                    if (triangle[t] > 8)
                        solids++;
            }
            if (solids >= stripes)
                move += solids;
            else
                move += stripes;
            return move;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            Pool pool = new Pool();
            String input = Console.ReadLine();
            do
            {
                int[] triangle = Array.ConvertAll<string, int>(input.Split(','), delegate(string s) { return Int32.Parse(s); });
                Console.WriteLine(pool.RackMoves(triangle));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion

    }
}