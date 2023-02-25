using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace LeetcodeSolution.Utils
{
    public static class StrHelper
    {
        public static string KeepNumbers(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("Input cannot be null, empty or whitespace.", nameof(input));
            }

            string pattern = @"\d+";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            string result = "";
            foreach (Match match in matches)
            {
                result += match.Value;
            }

            return result;
        }
    }

    public class StrHelperTest
    {
        [Theory]
        [InlineData("a1b2c3d4", "1234")]
        [InlineData("12 34", "1234")]
        [InlineData("1 2a3 a4b5c ", "12345")]
        public void KeepNumbers_InputIsValid_ReturnsExpectedResult(string input, string expectedOutput)
        {
            // Act
            string actualOutput = StrHelper.KeepNumbers(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void KeepNumbers_InputIsNullOrWhitespace_ThrowsArgumentNullException(string input)
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => StrHelper.KeepNumbers(input));
        }
    }
}
