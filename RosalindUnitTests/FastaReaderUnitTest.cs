using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rosalind;
using System.IO;
using System.Collections.Generic;

namespace RosalindUnitTests
{
    [TestClass]
    public class FastaReaderUnitTest
    {
        [TestMethod]
        public void InitialiseOnEmptyString()
        {
            FastaReader fastaReader = new FastaReader(new StringReader(""));
        }

        [TestMethod]
        public void ReadReturnsFastaFormat()
        {
            FastaReader fastaReader = new FastaReader(new StringReader(""));
            Fasta fasta = fastaReader.Read();
        }

        [TestMethod]
        public void PopulateABCHeaderFastaFormat()
        {
            FastaReader fastaReader = new FastaReader(new StringReader(">ABC"));
            Fasta fasta = fastaReader.Read();

            Assert.AreEqual("ABC", fasta.Header);
        }

        [TestMethod]
        public void PopulateDEFHeaderFastaFormat()
        {
            FastaReader fastaReader = new FastaReader(new StringReader(">DEF"));
            Fasta fasta = fastaReader.Read();

            Assert.AreEqual("DEF", fasta.Header);
        }

        [TestMethod]
        public void PopulateATCGDnaFastaFormat()
        {
            FastaReader fastaReader = new FastaReader(new StringReader(">DNA\nATCG"));
            Fasta fasta = fastaReader.Read();

            Assert.AreEqual("ATCG", fasta.Dna);
        }

        [TestMethod]
        public void PopulateMoreDnaFastaFormat()
        {
            FastaReader fastaReader = new FastaReader(new StringReader(">DNA\nATCGGGCTAAT"));
            Fasta fasta = fastaReader.Read();

            Assert.AreEqual("ATCGGGCTAAT", fasta.Dna);
        }

        [TestMethod]
        public void PopulateTwoLineDnaFastaFormat()
        {
            FastaReader fastaReader = new FastaReader(new StringReader(">DNA\nATCGGGCTAAT\nATCGGGCTAAT"));
            Fasta fasta = fastaReader.Read();

            Assert.AreEqual("ATCGGGCTAATATCGGGCTAAT", fasta.Dna);
        }


        [TestMethod]
        public void PopulateMultiLineDnaFastaFormat()
        {
            FastaReader fastaReader = new FastaReader(new StringReader(">DNA\nATCGGGCTAAT\nATCGGGCTAAT\nATCGGGCTAAT\nATCGGGCTAAT"));
            Fasta fasta = fastaReader.Read();

            Assert.AreEqual("ATCGGGCTAATATCGGGCTAATATCGGGCTAATATCGGGCTAAT", fasta.Dna);
        }

        [TestMethod]
        public void HandleMultipleFastaFormat()
        {
            FastaReader fastaReader = new FastaReader(new StringReader(">DNA\nATCGGGCTAAT\nATCGGGCTAAT\n>Number2\nATCGGGCTAAT\nATCGGGCTAAT"));
            Fasta fasta = fastaReader.Read();

            Assert.AreEqual("DNA", fasta.Header);
            Assert.AreEqual("ATCGGGCTAATATCGGGCTAAT", fasta.Dna);

            fasta = fastaReader.Read();
            Assert.AreEqual("Number2", fasta.Header);
            Assert.AreEqual("ATCGGGCTAATATCGGGCTAAT", fasta.Dna);
        }

        [TestMethod]
        public void HandleMultipleFastaFormatWithEmptyLines()
        {
            FastaReader fastaReader = new FastaReader(new StringReader(">DNA\nATCGGGCTAAT\nATCGGGCTAAT\n\n>Number2\nATCGGGCTAAT\nATCGGGCTAAT"));
            Fasta fasta = fastaReader.Read();

            Assert.AreEqual("DNA", fasta.Header);
            Assert.AreEqual("ATCGGGCTAATATCGGGCTAAT", fasta.Dna);

            fasta = fastaReader.Read();
            Assert.AreEqual("Number2", fasta.Header);
            Assert.AreEqual("ATCGGGCTAATATCGGGCTAAT", fasta.Dna);
        }

        [TestMethod]
        public void ReadToEndReturnsList()
        {
            FastaReader fastaReader = new FastaReader(new StringReader(">DNA\nATCGGGCTAAT\nATCGGGCTAAT\n\n>Number2\nATCGGGCTAAT\nATCGGGCTAAT"));
            List<Fasta> fastaList = fastaReader.ReadToEnd();
            Assert.IsTrue(fastaList != null);
        }

        [TestMethod]
        public void ReadToEndReturnsSingleElement()
        {
            FastaReader fastaReader = new FastaReader(new StringReader(">DNA\nATCGGGCTAAT\nATCGGGCTAAT"));
            List<Fasta> fastaList = fastaReader.ReadToEnd();
            Assert.IsTrue(fastaList.Count == 1);
        }

        [TestMethod]
        public void ReadToEndReturnsTwoElements()
        {
            FastaReader fastaReader = new FastaReader(new StringReader(">DNA\nATCGGGCTAAT\nATCGGGCTAAT\n\n>Number2\nATCGGGCTAAT\nATCGGGCTAAT"));
            List<Fasta> fastaList = fastaReader.ReadToEnd();
            Assert.IsTrue(fastaList.Count == 2);
        }
    }
}
