using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class InputManager
    {
        private List<string> delimiters;

        private readonly string input;
        private readonly string delimitersSection;

        public InputManager(string input)
        {
            this.input = input;
            this.delimitersSection = getDelimitersSection();
            SetDelimiters(delimitersSection);
        }

        private List<string> BuildCustomDelimiters()
        {
            List<string> delimiters = new List<string>();

            string pattern = "\\[(.*?)\\]";
            MatchCollection matchedDelimiters = Regex.Matches(delimitersSection, pattern);

            foreach (Match matchedDelimiter in matchedDelimiters)
            {
                string definitionDelimiter = matchedDelimiter.ToString();

                string delimiter = definitionDelimiter.Substring(
                    definitionDelimiter.IndexOf("[") + 1,
                    definitionDelimiter.IndexOf("]") - 1
                );

                delimiters.Add(delimiter);
            }

            return delimiters;
        }

        private List<string> BuildDefaultDelimeters()
        {
            List<string> delimiters = new List<string>();
            delimiters.Add(",");
            delimiters.Add("\n");
            return delimiters;
        }

        public List<string> GetDelimiters()
        {
            return delimiters;
        }

        private string getDelimitersSection()
        {
            return input.Substring(2, input.IndexOf("\n") - 2);
        }

        private void SetDelimiters(string delimitersSection) 
        {
            List<string> delimiters = BuildDefaultDelimeters();
            delimiters.AddRange(BuildCustomDelimiters());
            this.delimiters = delimiters;
        }

    }
}
