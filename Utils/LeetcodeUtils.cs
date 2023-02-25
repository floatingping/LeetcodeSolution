using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Utils
{
    public static class LeetcodeUtils
    {


        public static List<int> ConvertStringToOneDimensionArray(string input)
        {
            var cleanInput = input.Replace(" ", "");

            string str = cleanInput.StartsWith("[") ? cleanInput[1..] : cleanInput;
            str = str.EndsWith("]") ? str[..^1] : str;
            var result = str.Split(",")
                .Select(s => int.Parse(s))
                .ToList();
            return result;
        }


        public static int[][] ConvertStringToTwoDimensionArray(string input)
        {
            var els = RealizerArrayString(input).Replace(" ", "");

            var result = new List<List<int>>() { };
            if (string.IsNullOrWhiteSpace(els)) return new int[][] { };
            foreach (var el in els.Split("],["))
            {
                result.Add(ConvertStringToOneDimensionArray(el));
            }
            return result.Select(r => r.ToArray()).ToArray();
        }

        private static string RealizerArrayString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input string cannot be null or whitespace.");
            }
            input = input.Trim();
            if (input[0] != '[' || input[^1] != ']')
            {
                throw new ArgumentException("Invalid input string format.");
            }
            return input[1..^1].Trim();
        }
    }



    public class ConvertStringToTwoDimensionArrayTests
    {

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("]")]
        [InlineData("[ [1, 2], [3, a] ]")]
        [InlineData("[ [1, 2], [, 4] ]")]
        [InlineData("[ [1, 2], [3, 4],]")]
        public void ConvertStringToArray_InvalidInputFormat_ThrowsArgumentException(string input)
        {
            // Act & Assert
            Assert.ThrowsAny<Exception>(() => LeetcodeUtils.ConvertStringToTwoDimensionArray(input));
        }

        [Fact]
        public void TestConvertStringToTwoDimensionArray1()
        {
            var input = "[ [1, 2], [3, 4] ]";
            var expect = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };

            var actual = LeetcodeUtils.ConvertStringToTwoDimensionArray(input);

            Assert.Equal(expect.Count(), actual.Count());
            for (int i = 0; i < actual.Count(); i++)
            {
                actual[i].SequenceEqual(expect[i]);
            }
        }


        [Fact]
        public void TestConvertStringToTwoDimensionArray2()
        {
            var input = "[ [1, 2, 3], [4, 5], [6,  7, 8,   9] ]";
            var expect = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 6, 7, 8, 9 } };

            var actual = LeetcodeUtils.ConvertStringToTwoDimensionArray(input);

            Assert.Equal(expect.Count(), actual.Count());
            for (int i = 0; i < actual.Count(); i++)
            {
                actual[i].SequenceEqual(expect[i]);
            }
        }


    }
}
