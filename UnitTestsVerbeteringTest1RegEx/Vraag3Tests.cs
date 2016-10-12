using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace UnitTestsVerbeteringTest1RegEx
{
    [TestClass]
    public class Vraag3Tests
    {
        // Alle nummerplaten die bestaan uit 3 letters, een streepje en 3 cijfers.
        // OPL : /^\w\w\w-\d\d\d$/

        Regex re;

        [TestInitialize]
        public void Initialize()
        {
            re = new Regex(@"^\w\w\w-\d\d\d$");
        }

        [TestMethod]
        public void TestLicensePlateWith3LettersAnd3NumbersShouldMatch()
        {
            Match m = re.Match("ABC-123");
            Assert.AreEqual("ABC-123", m.Value);
            Assert.IsTrue(m.Success);
        }

        [TestMethod]
        public void TestLicensePlateWith3LettersAnd3NumbersButStartingWith1ShouldntMatch()
        {
            Match m = re.Match("1-ABC-123");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }

        [TestMethod]
        public void TestLicensePlateWith3LettersAnd3NumbersButStartingWith9ShouldntMatch()
        {
            Match m = re.Match("9-ABC-123");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }

        [TestMethod]
        public void TestLicensePlateWith3LettersAnd3NumbersButStartingWith10ShouldntMatch()
        {
            Match m = re.Match("10-ABC-123");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }

        [TestMethod]
        public void TestLicensePlateWith3LettersAnd3NumbersButStartingWithAShouldntMatch()
        {
            Match m = re.Match("A-ABC-123");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }

        [TestMethod]
        public void TestLicensePlateWithOnly2LettersShouldntMatch()
        {
            Match m = re.Match("AB-123");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }

        [TestMethod]
        public void TestLicensePlateWithOnly2NumbersShouldntMatch()
        {
            Match m = re.Match("ABC-D12");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }

        [TestMethod]
        public void TestLicensePlateWithoutDashShouldntMatch()
        {
            Match m = re.Match("ABC123");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }
    }
}
