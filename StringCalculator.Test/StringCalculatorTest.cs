using System;
using StringCalculator;
using Xunit;

namespace StringCalculator.Test
{
    public class StringCalculatorTest
    {
        
        [Fact]
        public void One_Number_Input_Should_Return_Numer()
        {
            StringCalculator calculator = new StringCalculator();

            int result = calculator.Add("5");

            Assert.Equal(5, result);
        }

        [Fact]
        public void Two_Numbers_Input_Separated_By_Commas_ShouldReturnTheSum()
        {
            StringCalculator calculator = new StringCalculator();

            int result = calculator.Add("5,8");

            Assert.Equal(13, result);
        }

        [Fact]
        public void Unknow_Amount_Of_Numbers_Should_Return_Their_Sum()
        {
            StringCalculator calculator = new StringCalculator();

            var result = calculator.Add("5,8,7,9,148,255,1");

            Assert.Equal(433, result);
        }

        [Fact]
        public void Input_With_New_Lines_Instead_Of_Commas_Should_Return_Their_Sum()
        {
            StringCalculator calculator = new StringCalculator();

            var result = calculator.Add("5\n8,7,9\n148,255,1");

            Assert.Equal(433, result);
        }

        [Fact]
        public void CustomDelimiter_ShouldAdmitted()
        {
            StringCalculator calculator = new StringCalculator();

            var result = calculator.Add("//[ñ]\n5ñ8,3");

            Assert.Equal(16, result);
        }

        [Fact]
        public void Negative_Numbers_Should_Thrown_Exeption_And_Numbers_That_Was_Passed()
        {
            StringCalculator calculator = new StringCalculator();

            Action result = () => calculator.Add("//[?]\n5?8,3\n-4?-10");

            var ex = Assert.Throws<Exception>(result);
            Assert.StartsWith("Negatives not Allowed", ex.Message);
            Assert.Contains("-4", ex.Message);
            Assert.Contains("-10", ex.Message);
        }

        [Fact]
        public void NumersBiggerThan1000_ShouldBeignored()
        {
            StringCalculator calculator = new StringCalculator();
            var result = calculator.Add("1000,999,1001");
            Assert.Equal(1999, result);
        }

        [Theory]
        [ClassData(typeof(EntryDataStringProvider))]
        public void DelimiterWithLengthDynamic_ShouldBeAdmitted(string delimiter)
        {
            StringCalculator calcularor = new StringCalculator();
            var result = calcularor.Add($"//[{delimiter}]\n1{delimiter}2{delimiter}3{delimiter}4");
            Assert.Equal(10, result);
        }

        [Fact]
        public void SuportMultipleDynamicDelimiters()
        {
            StringCalculator calculator = new StringCalculator();
            var result = calculator.Add("//[del1][del2][?][ñ]\n1?2del13del24ñ5");
            Assert.Equal(15, result);
        }
    }
}
