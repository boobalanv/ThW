using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceMetalSeller
{
    public class IntergalacticNotation
    {
        Dictionary<string, string> UnitCredits = new Dictionary<string, string>();

        Dictionary<string, float> MetalCredits = new Dictionary<string, float>();

        public void GetUnitsCredits(string unitString)
        {
            string[] units = unitString.Split(new string[] { "is" }, StringSplitOptions.None);

            if(!UnitCredits.Keys.Contains(units[0]))
            {
                UnitCredits.Add(units[0], units[1]);
            }
        }

        public void GetMetalCredits(string metalString)
        {
            string[] metalStmt = metalString.Split(new string[] { "is" }, StringSplitOptions.None);

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
