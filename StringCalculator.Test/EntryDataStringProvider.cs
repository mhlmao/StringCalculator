using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator.Test
{
    public class EntryDataStringProvider : IEnumerable<object[]>
    {
        private const string ALLOWED_CHARACTERS = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789!\"#$%&/()=?¡'¿";
        private static string RandmonEntry()
        {
            int MaxLength = 5;
            Random random = new Random();

            return new string(Enumerable.Repeat(ALLOWED_CHARACTERS, MaxLength)
                .Select(s => s[random.Next(9)]).ToArray());
        }

        public IEnumerator<Object[]> GetEnumerator()
        {
            yield return new object[] { RandmonEntry() };
            yield return new object[] { RandmonEntry() };
            yield return new object[] { RandmonEntry() };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
