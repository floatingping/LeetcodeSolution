using LeetcodeSolution.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetcodeSolution
{
    public class LongestPalindrome
    {
        [Theory]
        [InlineData("abccccdd", 7)]
        [InlineData("a", 1)]
        [InlineData("ccc", 3)]
        public void Test(string input, int expect)
        {
            var aSolution = new Solution();

            var actual1 = aSolution.LongestPalindrome(input);
            var actual2 = aSolution.LongestPalindrome2(input);
            var actual3 = aSolution.LongestPalindrome3(input);

            Assert.Equal(expect, actual1);
            Assert.Equal(expect, actual2);
            Assert.Equal(expect, actual3);
        }

        public class Solution
        {
            public int LongestPalindrome(string s)
            {
                HashSet<char> set = new HashSet<char>();
                int count = 0;
                foreach (char c in s)
                {
                    if (set.Contains(c))
                    {
                        set.Remove(c);
                        count += 2;
                    }
                    else
                    {
                        set.Add(c);
                    }
                }
                if (set.Count > 0)
                {
                    count++; // add 1 for the center character of an odd-length palindrome
                }
                return count;
            }




            public int LongestPalindrome2(string s)
            {
                var charMap = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

                int result = charMap.Sum(kv => kv.Value / 2) * 2;
                result += charMap.Any(kv => kv.Value % 2 == 1)
                    ? 1
                    : 0;
                return result;
            }

            public int LongestPalindrome3(string s)
            {
                var charMap = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

                int result = charMap.Sum(kv => kv.Value / 2 * 2);
                result += result != s.Length ? 1 : 0;
                return result;
            }
        }



    }
}