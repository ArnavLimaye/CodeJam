using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class Dating
    {
        String Dates(String circle, int k)
        {
            string dates = string.Empty;
            //Your code goes here
            int maleCounter = 0, femaleCounter = 0, counter = 0;
            char[] gone = new char[circle.Length];
            int startingElement = (k-1) % circle.Length;
            char initialchar = circle[startingElement];
            char[] original = circle.ToCharArray();
            char[] male = new char[circle.Length];
            char[] female = new char[circle.Length];
            foreach (char ch in original)
            {
                if (char.IsLower(ch))
                {
                    female[femaleCounter++] = ch;
                }
                else
                {
                    male[maleCounter++] = ch;
                }
            }
            Array.Sort(male);
            Array.Sort(female);

            int exitcond;
            if (femaleCounter >= maleCounter)
                exitcond = maleCounter * 2;
            else
                exitcond = femaleCounter * 2;
            if (exitcond == 0)
                return "";
            do
            {
                //if starting from male
                if (char.IsUpper(initialchar))
                {
                    if (!DoesHave(gone, initialchar))            //if available
                    {
                        gone[counter++] = initialchar;
                        for (int i = 0; i < female.Length; i++)
                        {
                            if (!DoesHave(gone, female[i]))
                            {
                                gone[counter++] = female[i];
                                break;
                            }
                        }
                    }
                }

                //if starting from female
                if (char.IsLower(initialchar))
                {
                    if (!DoesHave(gone, initialchar))            //if available
                    {
                        gone[counter++] = initialchar;
                        for (int i = 0; i < male.Length; i++)
                        {
                            if (!DoesHave(gone, male[i]))
                            {
                                gone[counter++] = male[i];
                                break;
                            }
                        }
                    }
                }
                if (counter == exitcond)
                    break;
                else if (counter != exitcond)
                {
                    startingElement = FindNewStart(startingElement, original, gone, k);
                    initialchar = original[startingElement];
                }
            } while (true);

            
            
            /*foreach (char ch in c)
                temp += ch.ToString();
            */
           
               // Console.WriteLine(male);
           
                //Console.WriteLine(female);
            for (int i = 0; i < counter; i += 2)
            {
                dates += gone[i];
                dates += gone[i + 1];
                dates += " ";
            }
                return dates.Trim(' ');
        }

        public int FindNewStart(int startingElement, char[] original, char[] gone, int k)
        {
            int start = startingElement;
            int counter = 0;
            do
            {
                if (DoesHave(gone, original[start]))
                    start = (start+1) % original.Length;
                else
                {
                    counter++;
                    break;
                }
            } while (true);


            for (int i = (start + 1) % original.Length; true; i = (i+1) % original.Length)
            {
                if (k == 1)
                {
                    return start;
                }
                if (!DoesHave(gone, original[i]))
                    counter++;
                if (counter == k)
                {
                    start = i;
                    break;
                }
            }
                return start;
        }

  


        public bool DoesHave(char[] deleted, char reqd)
        {
            foreach (char ch in deleted)
            {
                if (reqd == ch)
                    return true;
            }
            return false;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            Dating dating = new Dating();

            do
            {
                string[] values = input.Split(',');
                Console.WriteLine(dating.Dates(values[0], Int32.Parse(values[1])));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}