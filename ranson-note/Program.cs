using System;
using System.Collections.Generic;
using System.Linq;

namespace ranson_note
{
    class Program
    {
        static void Main(string[] args)
        {
            checkMagazine3("two times three is not four".Split(' '), "two times two is four".Split(' '));
        }

        /* first try */
        static void checkMagazine(string[] magazine, string[] note)
        {
            var noteMap = note.Distinct().ToDictionary(x => x, x => note.Count(y => y == x));
            var magazineMap = magazine.Distinct().ToDictionary(x => x, x => magazine.Count(y => y == x));

            string yes = "Yes";
            string no = "No";
            bool result = true;
            foreach(var n in noteMap)
            {
                if (!magazineMap.ContainsKey(n.Key) || magazineMap[n.Key] < n.Value)
                {
                    result = false;
                    break;
                }                    
            }

            Console.WriteLine(result ? yes : no);
        }


        /*
            This approach may work in go lang using slices
        */
        static void checkMagazine2(string[] magazine, string[] note)
        {
            var list = magazine.ToHashSet();
            string yes = "Yes";
            string no = "No";
            bool result = true;
            foreach(var n in note)
            {
                var index = Array.IndexOf(magazine,n);
                if (index == -1)
                {
                    result = false;
                    break;
                }
                var temp = magazine[index];
                magazine[index] = magazine[magazine.Length - 1];
                magazine[magazine.Length - 1] = temp;
                Array.Resize(ref magazine, magazine.Length - 1);
            }

            Console.WriteLine(result ? yes : no);
        }

        /*
            Faster solution
        */
        static void checkMagazine3(string[] magazine, string[] note)
        {
            var w = new Dictionary<string, int>();
            for (int i = 0; i < magazine.Length; i++)
            {   
                w[magazine[i]] = w.ContainsKey(magazine[i]) ? w[magazine[i]]+1 : 1;
            }

            string yes = "Yes";
            string no = "No";
            bool result = true;
            foreach(var n in note)
            {
                if (w.ContainsKey(n) && w[n] > 0)
                {
                    w[n]--;
                }
                else
                {
                    result = false; 
                    break;
                }          
            }

            Console.WriteLine(result ? yes : no);
        }
    }
}
