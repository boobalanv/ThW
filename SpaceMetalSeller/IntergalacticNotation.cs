using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceMetalSeller
{
    public static class IntergalacticNotation
    {
       public static Dictionary<string, string> UnitCredits = new Dictionary<string, string>();

        public static Dictionary<string, float> MetalCredits = new Dictionary<string, float>();

        public static void GetUnitsCredits(string unitString)
        {
            string[] units = unitString.Split(' ');

            if(!UnitCredits.Keys.Contains(units[0].Trim()))
            {
                UnitCredits.Add(units[0].Trim(), units[2].Trim());
            }
        }

        public static void GetMetalCredits(string metalString)
        {
            string[] metalStmt = metalString.Split(new string[] { " is " }, StringSplitOptions.None);

            string[] unitsMetalStr = metalStmt.FirstOrDefault().Split(' ');

            int totalMetalValue = Convert.ToInt32(metalStmt.LastOrDefault().Split(' ')[0]);

            string romanNumeral = "";
            string metalName = "";

            for (int i = 0; i < unitsMetalStr.Length; i++)
            {
                if(UnitCredits.Keys.Contains(unitsMetalStr[i]))
                {
                    romanNumeral = romanNumeral + UnitCredits[unitsMetalStr[i]];
                }
                else
                {
                    metalName = unitsMetalStr[i];
                }
            }

            int base10Number = RomanNumeralConvention.ConvertRomanNumeralToBase10(romanNumeral);

            float metalCredit = (float)totalMetalValue / base10Number;

            if(!MetalCredits.Keys.Contains(metalName))
            {
                MetalCredits.Add(metalName, metalCredit);
            }

        }
    }
}
