using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringCalculator;
using Xunit;

namespace StringCalculator.Test
{
    public class InputValiadatorTest
    {
        private const string ALLOWED_CHARACTERS = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789!\"#$%&/()=?¡'¿";

        [Fact]
        public void Empty_Input_Should_Return_Zero()
        {
            StringCalculator calculator = new StringCalculator();

            int result = calculator.Add("");

            Assert.Equal(0, result);
        }

        //[Theory]
        //[InlineData("1,2,A")]
        //[InlineData("1,],[")]
        //[InlineData("1 ,2,A")]
        //public void Input_Should_Only_Accept_Numbers_As_Items(string input)
        //{
        //    var validator = new InputValidator();
        //    var result = validator.IsValidEntry(input);
        //    Assert.True(!result);
        //}

        //[Theory]
        //[ClassData(typeof(EntryDataStringProvider))]
        //public void Input_Should_Only_Accept_Numbers_As_Items_To_Sum(string entry)
        //{
        //    InputValidator validator = new InputValidator();

        //    bool result = true;

        //    Assert.True(result);

        //    Assert.True(result);
        //}
    }
}
