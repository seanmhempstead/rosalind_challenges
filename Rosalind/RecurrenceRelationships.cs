using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind
{
    public class RecurrenceRelationships
    {
        public long Calculate(int generations, int pairs)
        {
            List<long> values = new List<long>
            {
                1,
                1
            };

            if(generations > 2)
            {
                for(int i = 2; i < generations; i++)
                {
                    values.Add(values[i - 1] + pairs * values[i - 2]);
                }
            }

            return values.Last();
        }
    }
}
