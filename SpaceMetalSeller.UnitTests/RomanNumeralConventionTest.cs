using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceMetalSeller.UnitTests
{
    [TestClass]
    public class RomanNumeralConventionTest
    {

        [TestMethod]
        public void TestShouldReturnBase10()
        {
            string romanNumber = "XL";

            int base10Number = RomanNumeralConvention.ConvertRomanNumeralToBase10(romanNumber);

            Assert.AreEqual(4, base10Number);
        }
    }
}
