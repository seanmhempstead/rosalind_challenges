using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind
{
    public class DnaNucleotideStringProcessor
    {
        public string CountNucleotides(string nucleotideString)
        {
            if (String.IsNullOrEmpty(nucleotideString))
            {
                return "0 0 0 0";
            }

            int totalA = 0;
            int totalC = 0;
            int totalT = 0;
            int totalG = 0;

            for (int i = 0; i < nucleotideString.Length; i++)
            {
                if (nucleotideString[i] == 'A')
                {
                    totalA++;
                }
                else if (nucleotideString[i] == 'C')
                {
                    totalC++;
                }
                else if (nucleotideString[i] == 'T')
                {
                    totalT++;
                }
                else if (nucleotideString[i] == 'G')
                {
                    totalG++;
                }
            }

            return String.Format("{0} {1} {2} {3}", totalA, totalC, totalG, totalT);
        }

        public string TranscribeDnaToRna(string dna)
        {
            string rna = dna.Replace('T', 'U');
            return rna;
        }

        public string ReverseComplement(string dna)
        {
            string complement = "";
            for (int i = dna.Length-1; i >= 0; i--)
            {
                complement += ComplementaryNucleotide(dna[i]);
            }
            return complement;
        }

        public double GcPercentage(string dna)
        {
            if(String.IsNullOrEmpty(dna))
            {
                return 0;
            }
            else
            {
                double totalChars = dna.Length;
                double totalGorC = 0;
                for(int i = 0; i < dna.Length; i++)
                {
                    if(dna[i] == 'G' || dna[i] == 'C')
                    {
                        totalGorC++;
                    }
                }

                return (totalGorC / totalChars) * 100;
            }
        }

        public int HammingDistance(string firstString, string secondString)
        {
            if(String.IsNullOrEmpty(firstString) || String.IsNullOrEmpty(secondString) || firstString.Length != secondString.Length)
            {
                throw new ArgumentException();
            }

            int differentChars = 0;
            for(int i = 0; i < firstString.Length; i++)
            {
                if(firstString[i] != secondString[i])
                {
                    differentChars++;
                }
            }

            return differentChars;
        }

        private char ComplementaryNucleotide(char nucleotide)
        {
            char complement = ' ';
            if(nucleotide == 'A')
            {
                complement = 'T';
            }
            if (nucleotide == 'T')
            {
                complement = 'A';
            }
            if (nucleotide == 'C')
            {
                complement = 'G';
            }
            if (nucleotide == 'G')
            {
                complement = 'C';
            }

            return complement;
        }
    }
}
