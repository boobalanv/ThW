using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceMetalSeller
{
    public class RomanNumeralConvention
    {
        public Dictionary<string, int> RomanNumerals = new Dictionary<string, int>();

        public RomanNumeralConvention()
        {
            RomanNumerals.Add("I", 1);
            RomanNumerals.Add("V", 5);
            RomanNumerals.Add("X", 10);
            RomanNumerals.Add("L", 50);
            RomanNumerals.Add("C", 100);
            RomanNumerals.Add("D", 500);
            RomanNumerals.Add("M", 1000);
        }
        


        int ConvertRomanNumeralToBase10(string romanNumeral)
        {
            string[] romanNumerals = romanNumeral.Split();


        }

        bool IsValidRomanNumeral(string[] romanNumeral)
        {
            for (int i = 0; i < romanNumeral.Length; i++)
            {
                string[] NumeralsToAvoidMoreThanThree = { "I", "X", "C" };

                
                if(romanNumeral[i] == romanNumeral[i+1] == romanNumeral[i+2] == )
            }
        }
    }
}
