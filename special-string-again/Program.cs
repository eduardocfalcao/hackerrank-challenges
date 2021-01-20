using System;
using System.Linq;

namespace special_string_again
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(substrCount(8,"mnonopoo"));
        }

        public static long substrCount (int n, string s) 
        {
            long result = n;
            var stringArray = s.ToArray();
            for(int i =0; i < stringArray.Length; i++)
            {
                int repeat =0;
                while(i+1 < s.Length && stringArray[i] == stringArray[i +1])
                {
                    repeat++;
                    i++;
                }
                
                result += (repeat * (repeat +1)) / 2;

                var p = 1;

                while(i -p >= 0 && i+p < s.Length &&
                      stringArray[i+p] == stringArray[i-1] &&
                      stringArray[i-p] == stringArray[i-1])
                {
                    result++; 
                    p++;
                }
            }          

            return result;

        }
    }
}
