using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rosalind
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileLocation = args[0];
            string toBeSearched, pattern;
            using (FileStream stream = new FileStream(fileLocation, FileMode.Open))
            {
                var reader = new StreamReader(stream);
                toBeSearched = reader.ReadLine();
                pattern = reader.ReadLine();
            }

            var indices = StringUtils.IndicesOfPatternInString(pattern, toBeSearched);
            string output = "";
            foreach(int index in indices)
            {
                int temp = index + 1;
                output += temp.ToString() + " ";
            }
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
