using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace UnitTestsVerbeteringTest1RegEx
{
    [TestClass]
    public class Vraag4Tests
    {
        // Een adres-regel bestaande uit een 4-cijferige postcode en een gemeente waarbij postcode en gemeente geparset worden. 
        // Gemeente kan streepjes bevatten.
        // OPL : /(\d\d\d\d) (\w+)/

        Regex re;

        [TestInitialize]
        public void Initialize()
        {
            re = new Regex(@"^(\d\d\d\d) (\w+)$");
        }

        [TestMethod]
        public void TestZipcodeAndCityShouldMatchAndBeCaptured()
        {
            Match m = re.Match("2390 Malle");
            Assert.IsTrue(m.Success);
            Assert.AreEqual(3, m.Groups.Count);
            Assert.AreEqual("2390 Malle", m.Groups[0].Value);
            Assert.AreEqual("2390", m.Groups[1].Value);
            Assert.AreEqual("Malle", m.Groups[2].Value);
        }

        [TestMethod]
        public void TestZipcodeAndCityShouldMatchAndBeCaptured2()
        {
            Match m = re.Match("2000 Antwerpen");
            Assert.IsTrue(m.Success);
            Assert.AreEqual(3, m.Groups.Count);
            Assert.AreEqual("2000 Antwerpen", m.Groups[0].Value);
            Assert.AreEqual("2000", m.Groups[1].Value);
            Assert.AreEqual("Antwerpen", m.Groups[2].Value);
        }

        [TestMethod]
        public void TestJustCityShouldntMatch()
        {
            Match m = re.Match("Antwerpen");
            Assert.IsFalse(m.Success);
        }

        [TestMethod]
        public void TestZipcodeWithOnly3NumbersShouldntMatch()
        {
            Match m = re.Match("123 XYZ");
            Assert.IsFalse(m.Success);
        }
    }
}
