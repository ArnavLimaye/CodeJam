using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Codejam
{
    class StandInLine
    {
        int[] Reconstruct(int[] left)
        {
            int[] final = new int[left.Length];
            //Your code goes here
            for (int i = 0; i < final.Length; i++)
            {
                int lindex = left[i];
                var temp = final.ToList();
                var empty = temp.Select((value, index) => new { value, index }).Where(a => (a.value == 0)).Select(a => a.index);
                int[] empty1 = empty.ToArray();
                Place(lindex, final,i+1,empty1);
            }
                return final;
        }

         private void Place(int index, int[] final, int value, int[] empty1)
         {
            int place;
            if (final[index] == 0)
            {
                place = Find(index, final, value, empty1);
                final[place] = value;
            }
            else
            {
                place = FindPlace(index, final, value, empty1);
                final[place] = value;
            } 
         }

         private int Find(int index, int[] final, int value, int[] empty1)
         {
             int proposed = index;
             
             do
             {
                 int blanks = 0;
                 int total = 0;
                 int tall = 0;
                 for (int i = 0; i < proposed; i++)
                 {
                     if (final[i] == 0)
                         blanks++;
                 }
                 for (int i = 0; i < proposed; i++)
                 {
                     if (final[i] > value)
                         tall++;
                 }
                 total = tall + blanks;
                 if (total == index)
                 {
                     //allowed = 1;
                     break;
                 }
                 else if (total != index)
                 {
                     proposed = Nextblank(proposed,empty1);
                 }
             } while (true);
             return proposed;
         }

         private int Nextblank(int prop, int[] empty1)
         {
             int i;
             for (i = 0; empty1[i] != prop; i++) { }
             return empty1[i + 1];
         }


         private int FindPlace(int index, int[] final, int value,int[] empty1)
         {
            int proposed = index+1;
            int allowed;
            int totalblanks = 0;
            do
            {
                allowed = 0;
                if (empty1.Contains(proposed))
                {
                    //check for values to left for blank
                    totalblanks = 0;
                    foreach (int i in empty1)
                    {
                        if (i < proposed)
                            totalblanks++;
                    }
                    if (totalblanks == index)
                    {
                        allowed = 1;
                        break;
                    }
                    else if(totalblanks != index)
                    {
                        proposed += 1;
                    }
                }
                else
                    proposed += 1; 
            } while (true);

            if (allowed == 1)
                return proposed;
            else
                return 0;   
         }


        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            StandInLine standInLine = new StandInLine();
            do
            {
                int[] left = Array.ConvertAll<string, int>(input.Split(','), delegate(string s) { return Int32.Parse(s); });
                Console.WriteLine(string.Join(",", Array.ConvertAll<int, string>(standInLine.Reconstruct(left), delegate(int s) { return s.ToString(); })));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}
