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

            string[] unitsMetalStr = metalStmt.FirstOrDefault().Split(' ')

            for (int i = 0; i < unitsMetalStr.Length; i++)
            {

            }
        }
    }
}
