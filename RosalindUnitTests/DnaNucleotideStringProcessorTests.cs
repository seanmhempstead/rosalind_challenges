using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rosalind;

namespace RosalindUnitTests
{
    [TestClass]
    public class DnaNucleotideStringProcessorTests
    {
        #region CountNucleotides
        [TestMethod]
        public void EmptyStringReturns_0_0_0_0()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("0 0 0 0", processor.CountNucleotides(""));
        }

        [TestMethod]
        public void A_Returns_1_0_0_0()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("1 0 0 0", processor.CountNucleotides("A"));
        }

        [TestMethod]
        public void C_Returns_0_1_0_0()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("0 1 0 0", processor.CountNucleotides("C"));
        }

        [TestMethod]
        public void G_Returns_0_0_1_0()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("0 0 1 0", processor.CountNucleotides("G"));
        }

        [TestMethod]
        public void T_Returns_0_0_0_1()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("0 0 0 1", processor.CountNucleotides("T"));
        }

        [TestMethod]
        public void Returns_20_12_17_21()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("20 12 17 21", processor.CountNucleotides("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"));
        }
        #endregion

        #region DnaToRna
        [TestMethod]
        public void EmtpyStringReturnsEmptyString()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("", processor.TranscribeDnaToRna(""));
        }

        [TestMethod]
        public void ATranscribesA()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("A", processor.TranscribeDnaToRna("A"));
        }

        [TestMethod]
        public void CTranscribesC()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("C", processor.TranscribeDnaToRna("C"));
        }

        [TestMethod]
        public void GTranscribesG()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("G", processor.TranscribeDnaToRna("G"));
        }

        [TestMethod]
        public void TTranscribesU()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("U", processor.TranscribeDnaToRna("T"));
        }

        [TestMethod]
        public void TranscribeMultipleNucleotidesWithoutT()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("GGAACC", processor.TranscribeDnaToRna("GGAACC"));
        }

        [TestMethod]
        public void TranscribeMultipleNucleotidesWithT()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("GGAACCUUAACC", processor.TranscribeDnaToRna("GGAACCTTAACC"));
        }

        [TestMethod]
        public void TranscribeMultipleNucleotidesWithTSecond()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("GAUGGAACUUGACUACGUAAAUU", processor.TranscribeDnaToRna("GATGGAACTTGACTACGTAAATT"));
        }
        #endregion

        #region ReverseComplement
        [TestMethod]
        public void EmptyStringReturnsEmptyString()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("", processor.ReverseComplement(""));
        }

        [TestMethod]
        public void AReturnsT()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("T", processor.ReverseComplement("A"));
        }

        [TestMethod]
        public void TReturnsA()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("A", processor.ReverseComplement("T"));
        }

        [TestMethod]
        public void CReturnsG()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("G", processor.ReverseComplement("C"));
        }

        [TestMethod]
        public void GReturnsC()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("C", processor.ReverseComplement("G"));
        }

        [TestMethod]
        public void AAAReturnsTTT()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("TTT", processor.ReverseComplement("AAA"));
        }

        [TestMethod]
        public void GTCAReturnsTGAC()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual("TGAC", processor.ReverseComplement("GTCA"));
        }
        #endregion

        #region GcContent

        [TestMethod]
        public void Gc_Content_Empty_String_Returns_0()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual(0.0, processor.GcPercentage(""), 0.000001);
        }

        [TestMethod]
        public void Gc_Content_One_Char_Returns_0()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual(0.0, processor.GcPercentage("A"), 0.000001);
        }

        [TestMethod]
        public void Gc_Content_One_Char_Returns_100()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual(100.0, processor.GcPercentage("G"), 0.000001);
        }

        [TestMethod]
        public void Gc_Content_One_Char_C_Returns_100()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual(100.0, processor.GcPercentage("C"), 0.000001);
        }

        [TestMethod]
        public void Gc_Content_Two_Char_Returns_100()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual(100.0, processor.GcPercentage("GC"), 0.000001);
        }

        [TestMethod]
        public void Gc_Content_Two_Char_Returns_0()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual(0.0, processor.GcPercentage("AT"), 0.000001);
        }

        [TestMethod]
        public void Gc_Content_Two_Char_Returns_50()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual(50.0, processor.GcPercentage("GT"), 0.000001);
        }

        #endregion

        #region HammingDistance

        [TestMethod]
        public void Hamming_Empty_Strings_Throw_Exceptions()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            try
            {
                processor.HammingDistance("", "");
                Assert.Fail();
            }
            catch(AssertFailedException e)
            {
                throw e;
            }
            catch(ArgumentException)
            {

            }
        }

        [TestMethod]
        public void Hamming_Same_Single_Letters()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual(0, processor.HammingDistance("A", "A"));
        }

        [TestMethod]
        public void Hamming_Different_Single_Letters()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual(1, processor.HammingDistance("G", "A"));
        }

        [TestMethod]
        public void Hamming_Same_Double_Letters()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual(0, processor.HammingDistance("AA", "AA"));
        }

        [TestMethod]
        public void Hamming_Different_Double_Letters()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual(2, processor.HammingDistance("GG", "AA"));
        }

        [TestMethod]
        public void Hamming_Different_Multiple_Letters()
        {
            DnaNucleotideStringProcessor processor = new DnaNucleotideStringProcessor();
            Assert.AreEqual(7, processor.HammingDistance("GAGCCTACTAACGGGAT", "CATCGTAATGACGGCCT"));
        }
        #endregion
    }
}
