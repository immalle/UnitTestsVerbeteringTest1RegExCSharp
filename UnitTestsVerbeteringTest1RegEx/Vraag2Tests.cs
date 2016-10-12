using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace UnitTestsVerbeteringTest1RegEx
{
    [TestClass]
    public class Vraag2Tests
    {
        // Alle strings die er uit zien als een IP-adres, d.w.z. 4 getallen gescheiden door puntjes (vereenvoudigd).
        // OPL : /^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$/

        Regex re;

        [TestInitialize]
        public void Initialize()
        {
            re = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
        }

        [TestMethod]
        public void TestLocalIpMatches()
        {
            Match m = re.Match("192.168.1.1");
            Assert.AreEqual("192.168.1.1", m.Value);
            Assert.IsTrue(m.Success);
        }

        [TestMethod]
        public void TestBroadcastAddressMatches()
        {
            Match m = re.Match("255.255.255.0");
            Assert.AreEqual("255.255.255.0", m.Value);
            Assert.IsTrue(m.Success);
        }

        [TestMethod]
        public void TestIpWith2CharactersMatches()
        {
            Match m = re.Match("12.12.12.12");
            Assert.AreEqual("12.12.12.12", m.Value);
            Assert.IsTrue(m.Success);
        }

        [TestMethod]
        public void TestIpAllZeroesMatches()
        {
            Match m = re.Match("0.0.0.0");
            Assert.AreEqual("0.0.0.0", m.Value);
            Assert.IsTrue(m.Success);
        }

        [TestMethod]
        public void TestNotARealIPGetsWith3CharactersMatchesAnyway()
        {
            Match m = re.Match("256.0.0.0");
            Assert.AreEqual("256.0.0.0", m.Value);
            Assert.IsTrue(m.Success);
        }

        [TestMethod]
        public void TestNotARealIPWithMoreThan3CharactersShouldntMatch()
        {
            Match m = re.Match("1000.0.0.0");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }

        [TestMethod]
        public void TestNotARealIPWithLettersShouldntMatch()
        {
            Match m = re.Match("ab.123.123.123");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }

        [TestMethod]
        public void TestNotACompleteIPShouldntMatch()
        {
            Match m = re.Match("12.12.344");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }

        [TestMethod]
        public void TestNotACompleteIPShouldntMatch2()
        {
            Match m = re.Match("0.0");
            Assert.AreEqual("", m.Value);
            Assert.IsFalse(m.Success);
        }
    }
}
