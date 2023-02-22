using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class ValidParentheses
    {


        [Theory]
        [InlineData(true, "()")]
        [InlineData(true, "()[]{}")]
        [InlineData(false, "(]")]
        [InlineData(false, "(")]
        public void Test(bool expect, string s)
        {
            var aSolution = new Solution();

            bool actual = aSolution.IsValid(s);

            Assert.Equal(expect, actual);
        }

        public class Solution
        {
            public bool IsValid(string s)
            {
                var checkMap = new Dictionary<char, char>()
                {
                    { ')', '(' },
                    { ']', '[' },
                    { '}', '{' }
                };
                var t = new Stack<char>();

                for (int i = 0; i < s.Length; i++)
                {
                    if (!checkMap.ContainsKey(s[i]))
                    {
                        t.Push(s[i]);
                    }
                    else
                    {
                        if (!t.Any() || t.Peek() != checkMap[s[i]]) return false;
                        t.Pop();
                    }
                }
                return !t.Any();

            }



        }
    }
}
