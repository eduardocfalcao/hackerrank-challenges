using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace sherlock
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input17.txt");
            Console.WriteLine(isValid(input));
        }
        static string isValid(string s) 
        {
            string yes = "YES";
            string no = "NO";
            
            var grouped = s.ToCharArray()
                    .GroupBy(x => x, x => x);
            
            var frequencies = new Dictionary<int, int>();
            
            foreach(var value in grouped)
            {
                if (frequencies.Keys.Contains(value.Count()))
                    frequencies[value.Count()]++;
                else
                    frequencies[value.Count()] = 1;
            }
            
            if (frequencies.Count > 2)
                return no;
                
            if (frequencies.Count == 1)
                return yes;
            
            var arrayFreq = frequencies.ToArray();
            if ((arrayFreq[0].Key == 1 && arrayFreq[0].Value == 1) || (arrayFreq[1].Key == 1 && arrayFreq[1].Value == 1))
                return yes;
                
            var diff = arrayFreq[0].Key - arrayFreq[1].Key;

            if ((diff == 1 || diff == -1) && (arrayFreq[0].Value == 1 || arrayFreq[1].Value == 1))
                return yes;
            
            return no;
        }
    }
}
