using System;

namespace common_child
{
    class Program
    {
        // longest common subsequence - LCS
        static void Main(string[] args)
        {
            Console.WriteLine(commonChild("WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS", "FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC"));
        }

        /*

            WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS


            FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC

        */

        static int commonChild(string s1, string s2) 
        {
            var memo = new int[s1.Length + 1];

            for ( int i = 1; i <= s1.Length; i++)
            {
                int prev = 0;
                
                for (int j = 1; j <= s2.Length; j++)
                {
                    int temp = memo[j];
                    if (s1[i-1] == s2[j-1])
                        memo[j] = prev + 1;
                    else
                        memo[j] = Math.Max(memo[j], memo[j-1]);
                    prev = temp;
                }
                Console.WriteLine(string.Join(", ", memo));
            }
            return memo[s2.Length];
        }

    }
}
