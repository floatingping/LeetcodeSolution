using LeetcodeSolution.Utils;
using System;
using System.Linq;
using Xunit;

namespace LeetcodeSolution
{
    public class ValidPalindrome
    {
        [Theory]
        [InlineData("A man, a plan, a canal: Panama", true)]
        [InlineData("race a car", false)]
        public void Test(string input, bool expect)
        {
            var aSolution = new Solution();

            var actual = aSolution.IsPalindrome(input);

            Assert.Equal(expect, actual);
        }


        public class Solution
        {
            public bool IsPalindrome(string s)
            {

                int l = 0;
                int r = s.Length - 1;
                string str = s.ToLower();
                while (l < r)
                {
                    if (!Char.IsLetterOrDigit(str[l]))
                    {
                        l++;
                        continue;
                    }
                    if (!Char.IsLetterOrDigit(str[r]))
                    {
                        r--;
                        continue;
                    }
                    if (str[l] != str[r]) return false;
                    l++;
                    r--;
                }
                return true;

            }
            public bool IsPalindrome2(string s)
            {
                var str = new string(s.Where(s => char.IsLetterOrDigit(s)).ToArray()).ToLower();

                return str == new string(str.Reverse().ToArray());
            }
        }



    }
}
