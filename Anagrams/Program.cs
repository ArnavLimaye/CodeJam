using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;


namespace Codejam
{
    class Anagrams
    {
        int GetMaximumSubset(string[] words)
        {
            //Your code goes here
            //int[] alreadyChecked = new int[50];
            string[] tempwords = new string[50];
            int subsetCount = 1;
            int counter = 1;
            //int[] unequal = new int[50]; 
            for (int i = 0; i < words.Length; i++ )
            {
                //alreadyChecked[i] = 0;
                //unequal[i] = -1;
                string temp = String.Empty;
                char[] c = words[i].ToCharArray();
                Array.Sort(c);
                foreach (char ch in c)
                    temp += ch.ToString();
                tempwords[i] = temp;
            }
            //checking for anagram
            //int pass = 0;
            string[] nonduplicate = new string[50];
            nonduplicate[0] = tempwords[0];
            for (int i = 1; i < words.Length; i++)                    //for finding distinct values
            {
                if (!nonduplicate.Contains(tempwords[i]))
                {
                    subsetCount += 1;
                    nonduplicate[counter] = tempwords[i];
                    counter += 1;
                }
               
            }
            /*var result = tempwords.Distinct();              //as we need distinct values
            subsetCount = 0;

            foreach (string val in result)                  
                subsetCount += 1;
            */
            //Console.WriteLine(subsetCount);
            return subsetCount;                     //it also gives null as disinct so we need to subtract 1 from total count
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            Anagrams anagramSolver = new Anagrams();
            do
            {
                string[] words = input.Split(',');
                Console.WriteLine(anagramSolver.GetMaximumSubset(words));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}

