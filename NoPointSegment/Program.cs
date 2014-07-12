using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class BinaryCoder
    {
        public String[] Decode(string test)
        {
            return new String[2];
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            BinaryCoder coder = new BinaryCoder();
            do
            {
                String[] validationOp = coder.Decode(input);
                Console.WriteLine("{0},{1}", validationOp[0], validationOp[1]);
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}