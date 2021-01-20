using System;
using System.Linq;

namespace making_anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(makeAnagram("cde", "abc"));
        }

        /*
            Should return the number of characters is needed to remove from both strings to the strings
            be anagrams of each other.
        */
        static int makeAnagram(string a, string b) 
        {
            var mapA = a.Distinct().ToDictionary(x => x, y => a.Count(x => x ==y));
            var mapB = b.Distinct().ToDictionary(x => x, y => b.Count(x => x ==y));
            int result = 0;

            foreach(var x in mapA)
            {
                if (mapB.ContainsKey(x.Key))
                {
                    var bValue = mapB[x.Key];
                    var lower = Math.Min(x.Value, bValue);
                    var bigger = Math.Max(x.Value, bValue);
                    result += lower == bigger ? 0 : bigger - lower;
                    mapB.Remove(x.Key);
                }
                else 
                {
                    result += x.Value;
                }
            } 

            foreach(var x in mapB)
                result += x.Value;

            return result;
        }

    }
}
