using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceMetalSeller
{
    public static class RomanNumeralConvention
    {
        public static Dictionary<string, int> RomanNumerals = new Dictionary<string, int>();

        static RomanNumeralConvention()
        {
            RomanNumerals.Add("I", 1);
            RomanNumerals.Add("V", 5);
            RomanNumerals.Add("X", 10);
            RomanNumerals.Add("L", 50);
            RomanNumerals.Add("C", 100);
            RomanNumerals.Add("D", 500);
            RomanNumerals.Add("M", 1000);
        }



        public static int ConvertRomanNumeralToBase10(string romanNumeral)
        {
            string[] romanNumerals = romanNumeral.Select(x => x.ToString()).ToArray();
            int totalSum = 0;
            if (IsValidRomanNumeral(romanNumerals))
            {
                for (int i = 0; i < romanNumerals.Length; i++)
                {
                    string firstChar = romanNumerals[i], secondeChar = "";
                    int firstNo = RomanNumerals[firstChar];
                    int secondNo = 0;
                    if (i + 1 <= romanNumerals.Length - 1)
                    {
                        secondNo = RomanNumerals[romanNumerals[i + 1]];
                        secondeChar = romanNumerals[i + 1];
                        //i++;
                        if (firstNo > secondNo)
                        {
                            secondNo = 0;
                            secondeChar = "";
                        }
                        else
                            i++;
                    }

                    if (secondeChar == "")
                    {
                        totalSum += firstNo;
                    }
                    else if (firstChar == "I" && secondeChar != "I")
                    {
                        if (secondeChar == "V" || secondeChar == "X")
                        {
                            totalSum += (secondNo - firstNo);
                        }
                        else
                        {
                            totalSum = 0;
                            break;
                        }

                    }
                    else if (firstChar == "X" && secondeChar != "X")
                    {
                        if (secondeChar == "L" || secondeChar == "C")
                        {
                            totalSum += (secondNo - firstNo);
                        }
                        else
                        {
                            totalSum = 0;
                            break;
                        }
                    }
                    else if (firstChar == "C" && secondeChar != "C")
                    {
                        if (secondeChar == "D" || secondeChar == "M")
                        {
                            totalSum += (secondNo - firstNo);
                        }
                        else
                        {
                            totalSum = 0;
                            break;
                        }
                    }
                    else if (firstChar == "V" && secondeChar != "V")
                    {
                        if(secondeChar == "I")
                        {
                            totalSum += firstNo + secondNo;
                        }
                        else
                        {
                            totalSum = 0;
                            break;
                        }
                    }
                    else if (firstChar == "L" && secondeChar != "L")
                    {
                        if (secondeChar == "I" || secondeChar == "V" || secondeChar == "X")
                        {
                            totalSum += firstNo + secondNo;
                        }
                        else
                        {
                            totalSum = 0;
                            break;
                        }
                    }
                    else if (firstChar == "D" && secondeChar != "D")
                    {
                        if (secondeChar == "I" || secondeChar == "V" || secondeChar == "X" || secondeChar == "L" || 
                            secondeChar == "C")
                        {
                            totalSum += firstNo + secondNo;
                        }
                        else
                        {
                            totalSum = 0;
                            break;
                        }
                    }
                    else if(firstNo< secondNo)
                    {
                        totalSum += (secondNo - firstNo);
                    }
                    else if (firstNo >= secondNo)
                    {
                        totalSum += firstNo + secondNo;                       
                    }

                }


            }

            return totalSum;
        }

        static bool IsValidRomanNumeral(string[] romanNumeral)
        {
            //D,L,V can never be repeated
            if (romanNumeral.Count(t => t == "D") > 1 ||
                romanNumeral.Count(t => t == "L") > 1 ||
                romanNumeral.Count(t => t == "V") > 1)
            {
                return false;
            }

            for (int i = 0; i < romanNumeral.Length; i++)
            {
                //I,X,C,M can never reapeated more than 3 times sequentially
                if (romanNumeral.Skip(i).Take(4).Count() == 4 && (romanNumeral.Skip(i).Take(4).All(t => t == "I") ||
                    romanNumeral.Skip(i).Take(4).All(t => t == "X") ||
                    romanNumeral.Skip(i).Take(4).All(t => t == "C") ||
                    romanNumeral.Skip(i).Take(4).All(t => t == "M")))
                {
                    return false;
                }
            }



            return true;
        }
    }
}
