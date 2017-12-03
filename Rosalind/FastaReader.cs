using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind
{
    public class FastaReader : IDisposable
    {
        private TextReader reader;
        private string lastLine;
        public FastaReader(TextReader reader)
        {
            this.reader = reader;
        }

        public Fasta Read()
        {
            Fasta returnFasta = new Fasta();
            bool read = true;
            string completeString = "";

            while (read)
            {
                string line = lastLine ?? reader.ReadLine();
                if (IsHeader(line))
                {
                    returnFasta.Header = line.Substring(1);
                }
                else if (String.IsNullOrEmpty(line))
                {
                    read = false;
                }
                else
                {
                    completeString += line;
                }

                if(IsHeader(PeekLine()))
                {
                    read = false;
                }

            }
            returnFasta.Dna = completeString;

            return returnFasta;
        }

        public List<Fasta> ReadToEnd()
        {
            List<Fasta> returnList = new List<Fasta>();
            while (reader.Peek() > -1)
            {
                returnList.Add(Read());
            }
            return returnList;
        }

        private bool IsHeader(string line)
        {
            if(!String.IsNullOrEmpty(line) && line.Length > 0)
            {
                return line[0] == '>';
            }
            else
            {
                return false;
            }
        }

        private string PeekLine()
        {
            lastLine = reader.ReadLine();
            return lastLine;
        }

        public void Dispose()
        {
            reader.Dispose();
        }
    }
}
