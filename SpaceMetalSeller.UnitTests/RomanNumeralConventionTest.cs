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

            Assert.AreEqual(40, base10Number);
        }

        [TestMethod]
        public void TestShouldReturn0ForInvalidNumeral()
        {
            string romanNumber = "VLD";

            int base10Number = RomanNumeralConvention.ConvertRomanNumeralToBase10(romanNumber);

            Assert.AreEqual(0, base10Number);
        }

        [TestMethod]
        public void TestShouldReturn0WhenRepeated4Times()
        {
            string romanNumber = "XXXX";

            int base10Number = RomanNumeralConvention.ConvertRomanNumeralToBase10(romanNumber);

            Assert.AreEqual(0, base10Number);
        }
    }
}
