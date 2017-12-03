using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rosalind;

namespace RosalindUnitTests
{
    [TestClass]
    public class RecurrenceRelationshipTests
    {
        [TestMethod]
        public void OneGenOnePair()
        {
            RecurrenceRelationships recurrence = new RecurrenceRelationships();
            Assert.AreEqual(1, recurrence.Calculate(1, 1));
        }

        [TestMethod]
        public void TwoGensOnePair()
        {
            RecurrenceRelationships recurrence = new RecurrenceRelationships();
            Assert.AreEqual(1, recurrence.Calculate(1, 1));
        }

        [TestMethod]
        public void Fibonacci()
        {
            RecurrenceRelationships recurrence = new RecurrenceRelationships();
            Assert.AreEqual(5, recurrence.Calculate(5, 1));
        }

        [TestMethod]
        public void RabbitsExample()
        {
            RecurrenceRelationships recurrence = new RecurrenceRelationships();
            Assert.AreEqual(19, recurrence.Calculate(5, 3));
        }

        [TestMethod]
        public void RosalindDataSet()
        {
            RecurrenceRelationships recurrence = new RecurrenceRelationships();
            Assert.AreEqual(170361678269, recurrence.Calculate(29, 4));
        }
    }
}
