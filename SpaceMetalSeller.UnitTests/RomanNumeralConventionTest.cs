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
            Assert.AreEqual(1944, RomanNumeralConvention.ConvertRomanNumeralToBase10("MCMXLIV"));
            Assert.AreEqual(1903, RomanNumeralConvention.ConvertRomanNumeralToBase10("MCMIII"));
            Assert.AreEqual(2006, RomanNumeralConvention.ConvertRomanNumeralToBase10("MMVI"));
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
            string romanNumber = "VIIII";

            int base10Number = RomanNumeralConvention.ConvertRomanNumeralToBase10(romanNumber);

            Assert.AreEqual(0, base10Number);
        }

        [TestMethod]
        public void TestShouldReturn0WhenRepeated2Times()
        {
            string romanNumber = "DMD";

            int base10Number = RomanNumeralConvention.ConvertRomanNumeralToBase10(romanNumber);

            Assert.AreEqual(0, base10Number);
        }

        [TestMethod]
        public void TestShouldReturn0WhenFirstCharIandSecondOtherThanVX()
        {
            string romanNumber = "IM";

            int base10Number = RomanNumeralConvention.ConvertRomanNumeralToBase10(romanNumber);

            Assert.AreEqual(0, base10Number);
            Assert.AreEqual(0, RomanNumeralConvention.ConvertRomanNumeralToBase10("IC"));
            Assert.AreEqual(0, RomanNumeralConvention.ConvertRomanNumeralToBase10("IL"));
            Assert.AreEqual(0, RomanNumeralConvention.ConvertRomanNumeralToBase10("ID"));
            Assert.AreEqual(4, RomanNumeralConvention.ConvertRomanNumeralToBase10("IV"));
            Assert.AreEqual(9, RomanNumeralConvention.ConvertRomanNumeralToBase10("IX"));
        }

        [TestMethod]
        public void TestShouldReturn0WhenFirstCharXandSecondOtherThanLC()
        {
            Assert.AreEqual(0, RomanNumeralConvention.ConvertRomanNumeralToBase10("XD"));
            Assert.AreEqual(0, RomanNumeralConvention.ConvertRomanNumeralToBase10("XM"));
        }
    }
}
