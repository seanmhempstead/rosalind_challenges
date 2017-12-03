using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind
{
    public static class MathUtils
    {
        public static int Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return Factorial(n - 1) * n;
            }
        }

        /// <summary>
        /// Implementation of Heaps algorithm non-recursively
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static List<List<int>> UniquePermutations(List<int> sequence)
        {
            int n = sequence.Count;
            List<List<int>> permutations = new List<List<int>>();
            List<int> c = new List<int>(n);

            for (int j = 0; j < n; j++)
            {
                c.Add(0);
            }

            permutations.Add(new List<int>(sequence));

            int i = 0;

            while (i < n)
            {
                if (c[i] < i)
                {
                    if (i % 2 == 0)
                    {
                        int temp = sequence[0];
                        sequence[0] = sequence[i];
                        sequence[i] = temp;
                    }
                    else
                    {
                        int temp = sequence[c[i]];
                        sequence[c[i]] = sequence[i];
                        sequence[i] = temp;
                    }
                    permutations.Add(new List<int>(sequence));
                    c[i] += 1;
                    i = 0;
                }
                else
                {
                    c[i] = 0;
                    i += 1;
                }
            }

            return permutations;
        }
    }
}
