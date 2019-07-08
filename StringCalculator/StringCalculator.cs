using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalculator
    {

        private InputManager input;
        private readonly InputValidator validator;

        public StringCalculator()
        {   
            this.validator = new InputValidator();
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            else
            {
                this.input = new InputManager(numbers);
                List<string> delimiters = input.GetDelimiters();

                int result = 0;
                int intNumber;
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
    }
}
