using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace UnitTestsVerbeteringTest1RegEx
{
    [TestClass]
    public class Vraag1Tests
    {
        // De woorden die beginnen met `b`, `m` of `h` en eindigen op `al`
        // OPL : /^[bmh].*al$/

        Regex re;
        Regex reIgnoreCase;

        [TestInitialize]
        public void Initialize()
        {
            re = new Regex(@"^[bmh].*al$");
            reIgnoreCase = new Regex(@"^[bmh].*al$", RegexOptions.IgnoreCase);
        }

        [TestMethod]
        public void TestBalShouldMatch()
        {
            Match m = re.Match("bal");
            Assert.AreEqual("bal", m.Value);
            Assert.IsTrue(m.Success);
        }

        [TestMethod]
        public void TestMalShouldMatch()
        {
            Match m = re.Match("mal");
            Assert.AreEqual("mal", m.Value);
            Assert.IsTrue(m.Success);
        }

        [TestMethod]
        public void TestMalleShouldntMatch()
        {
            Match m = re.Match("malle");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }

        [TestMethod]
        public void TestPalShouldntMatch()
        {
            Match m = re.Match("pal");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }

        [TestMethod]
        public void TestHalShouldMatch()
        {
            Match m = re.Match("hal");
            Assert.AreEqual("hal", m.Value);
            Assert.IsTrue(m.Success);
        }

        [TestMethod]
        public void TestHalalShouldMatch()
        {
            Match m = re.Match("halal");
            Assert.AreEqual("halal", m.Value);
            Assert.IsTrue(m.Success);
        }

        [TestMethod]
        public void TestBanaalShouldMatch()
        {
            Match m = re.Match("banaal");
            Assert.AreEqual("banaal", m.Value);
            Assert.IsTrue(m.Success);
        }

        [TestMethod]
        public void TestCaseSensitiveBanaalShouldntMatchWithDefaultSettings()
        {
            Match m = re.Match("Banaal");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }

        [TestMethod]
        public void TestCaseSensitiveBanaalShouldMatchWithIgnoreCaseSetting()
        {
            Match m = reIgnoreCase.Match("Banaal");
            Assert.AreEqual("Banaal", m.Value);
            Assert.IsTrue(m.Success);
        }
    }
}
