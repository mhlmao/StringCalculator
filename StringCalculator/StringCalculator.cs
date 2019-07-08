using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalculator
    {

        private readonly InputStringCategorizer categorizer;
        private readonly InputValidator validator;

        public StringCalculator(InputManager input,
                                InputValidator validator)
        {
            this.categorizer = categorizer;
            this.validator = validator;
        }

        

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            else
            {
                List<string> delimiters = BuildDefaultDelimeters();

                delimiters.AddRange(categorizer.Delimiters);

                //custom delimiters
                if (numbers.StartsWith("//"))
                {
                    var sectionOfDelimitersDefinition =
                        numbers.Substring(2, numbers.IndexOf("\n") - 2);

                    var settedDelimiters = SetDelimiters(sectionOfDelimitersDefinition);
                    delimiters.AddRange(settedDelimiters);
                }

                //To Sum
                int result = 0;
                int intNumber = 0;
                List<int> negatives = new List<int>();

                //Split string by delimiters
                string[] splitNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (string number in splitNumbers)
                {
                    if (int.TryParse(number, out intNumber) == true)
                    {
                        if (intNumber < 0)
                        {
                            negatives.Add(intNumber);
                        }
                        result += intNumber > 1000 ? 0 : intNumber;
                    }
                }
                if (negatives.Count > 0)
                {
                    throw new Exception("Negatives not Allowed {0}" + string.Join(", ", negatives));
                }

                return result;
            }
        }

        private List<string> SetDelimiters(string delimitersSection)
        {
            List<string> delimiters = new List<string>();

            string pattern = "\\[(.*?)\\]";
            var delimitersFiltered = Regex.Matches(delimitersSection, pattern, RegexOptions.IgnorePatternWhitespace);

            foreach (var delimiter in delimitersFiltered)
            {
                string stringDelimiter = delimiter.ToString();
                string substring = stringDelimiter.Substring(
                       stringDelimiter.IndexOf("[") + 1,
                       stringDelimiter.IndexOf("]") - 1
                   );

                delimiters.Add(substring);
            }

            return delimiters;
        }
    }
}
