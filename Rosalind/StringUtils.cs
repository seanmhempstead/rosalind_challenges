using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind
{
    public static class StringUtils
    {
        /// <summary>
        /// Implementation of the Knuth-Morris-Pratt Algorithm.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="toBeSearched"></param>
        /// <returns></returns>
        public static List<int> IndicesOfPatternInString(string pattern, string toBeSearched)
        {
            List<int> indices = new List<int>();
            List<int> lookupTable = KMPFailureTable(pattern);

            int n = toBeSearched.Length;
            int m = pattern.Length;
            int q = 0;

            for(int i = 0; i < n; i++)
            {
                while(q > 0 && pattern[q] != toBeSearched[i])
                {
                    q = lookupTable[q];
                }
                if(pattern[q] == toBeSearched[i])
                {
                    q++;
                }
                if(q == m)
                {
                    indices.Add((i + 1) - q);
                    q = lookupTable[q-1];
                }
            }

            return indices;
        }

        private static List<int> KMPFailureTable(string motif)
        {
            List<int> lookupTable = new List<int>();
            for(int i = 0; i < motif.Length; i++)
            {
                lookupTable.Add(0);
            }

            int m = motif.Length;
            lookupTable[0] = 0;
            int k = 0;

            for(int q = 1; q < m; q++)
            {
                while(k > 0 && motif[k] != motif[q])
                {
                    k = lookupTable[k];
                }
                if(motif[k] == motif[q])
                {
                    k++;
                }
                lookupTable[q] = k;
            }

            return lookupTable;
        }
    }
}
