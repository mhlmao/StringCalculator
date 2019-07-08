using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    public class InputValidator
    {
        public bool IsValidEntry(string entry)
        {
            if (string.IsNullOrEmpty(entry)) return false;

            if(entry)

            if (InputBeginsWhitDoubleSlashes(entry))
            {

            }
            return true;
        }

        private bool InputBeginsWhitDoubleSlashes(string entry)
        {
            return entry.StartsWith("//") ? true : false;
        }
    }
}
