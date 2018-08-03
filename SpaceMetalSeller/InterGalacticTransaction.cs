using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SpaceMetalSeller
{
    class InterGalacticTransaction
    {
        static List<string> _questionsStr = new List<string>();
        static List<string> _unitsStr = new List<string>();
        static List<string> _metalsStr = new List<string>();
        static void Main(string[] args)
        {

            try
            {
                string input = GetInput();
                DecodeInput(input);

                GenerateAnswer();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static void DecodeInput(string input)
        {
            int posA = input.IndexOf("how");
            string unitsAndMetals = "";
            if (posA == -1)
            {
                unitsAndMetals = "";
            }
            unitsAndMetals = input.Substring(0, posA);

            _questionsStr = input.Trim().Substring(posA).Trim().Split('?').ToList();

            string[] splitUnitsAndMetals = unitsAndMetals.Trim().Split('\n');

            for (int i = 0; i < splitUnitsAndMetals.Length; i++)
            {
                string[] txt = splitUnitsAndMetals[i].Trim().Split(' ');
                if (!IntergalacticNotation.UnitCredits.Keys.Contains(txt[0]))
                {
                    IntergalacticNotation.GetUnitsCredits(splitUnitsAndMetals[i].Trim());
                }
                else
                {
                    IntergalacticNotation.GetMetalCredits(splitUnitsAndMetals[i].Trim());
                }
            }
        }

        static void GenerateAnswer()
        {
            for (int i = 0; i < _questionsStr.Count; i++)
            {
                string ques = _questionsStr[i].Trim();
                if (string.IsNullOrEmpty(ques))
                    continue;
                string[] questionArr = ques.Split(new string[] { " is " }, StringSplitOptions.None);

                if (questionArr.Count() < 2 || !(questionArr[0].Split(' ').Any(t => IntergalacticNotation.UnitCredits.Keys.Contains(t.Trim()))
                                            || !questionArr[0].Split(' ').Any(t => IntergalacticNotation.MetalCredits.Keys.Contains(t.Trim()))))
                {
                    Console.WriteLine("I have no idea what you are talking about");
                    continue;
                }

                string question = questionArr[1];

                string[] quessplt = question.Split(' ');
                string romanNo = "";
                float metalValue = 0.0F;
                for (int j = 0; j < quessplt.Length; j++)
                {
                    if (IntergalacticNotation.UnitCredits.Keys.Contains(quessplt[j].Trim()))
                    {
                        romanNo = romanNo + IntergalacticNotation.UnitCredits[quessplt[j].Trim()];
                    }
                    else if (IntergalacticNotation.MetalCredits.Keys.Contains(quessplt[j].Trim()))
                    {
                        metalValue = IntergalacticNotation.MetalCredits[quessplt[j].Trim()];
                    }
                }

                int base10Number = RomanNumeralConvention.ConvertRomanNumeralToBase10(romanNo);

                float totaMetalCredit = metalValue == 0.0F ? base10Number : metalValue * base10Number;


                Console.WriteLine($"{question} is {totaMetalCredit}");


            }
        }

        static string GetInput()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, "Input", "input.txt");

            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else
            {
                throw new Exception("File does not exists");
            }
        }
    }
}
