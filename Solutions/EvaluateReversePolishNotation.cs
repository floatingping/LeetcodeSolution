using LeetcodeSolution.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class EvaluateReversePolishNotation
    {
        [Theory]
        [InlineData("[\"2\",\"1\",\"+\",\"3\",\"*\"]", 9)]
        [InlineData("[\"4\",\"13\",\"5\",\"/\",\"+\"]", 6)]
        [InlineData("[\"10\",\"6\",\"9\",\"3\",\"+\",\"-11\",\"*\",\"/\",\"*\",\"17\",\"+\",\"5\",\"+\"]", 22)]
        public void Test(string input, int expect)
        {
            var aSolution = new Solution();
            var tokens = LeetcodeUtils.ConvertToObject<string[]>(input);

            int act = aSolution.EvalRPN(tokens);

            Assert.Equal(expect, act);
        }

        public class Solution
        {
            private readonly Dictionary<string, Func<int, int, int>> OperatorFuncDict = new Dictionary<string, Func<int, int, int>>()
            {
                { "+", (int n1, int n2) => n1 + n2 },
                { "-", (int n1, int n2) => n1 - n2 },
                { "*", (int n1, int n2) => n1 * n2 },
                { "/", (int n1, int n2) => n1 / n2 }
            };
            public int EvalRPN(string[] tokens)
            {
                var numStack = new Stack<int>();

                for (int i = 0; i < tokens.Count(); i++)
                {
                    if (OperatorFuncDict.TryGetValue(tokens[i], out var f))
                    {
                        int n2 = numStack.Pop();
                        int n1 = numStack.Pop();

                        numStack.Push(f(n1, n2));
                    }
                    else
                    {
                        numStack.Push(int.Parse(tokens[i]));
                    }
                }
                return numStack.Pop();
            }
            public int EvalRPN2(string[] tokens)
            {
                var operatorSet = new HashSet<string>() { "+", "-", "*", "/" };
                var numStack = new Stack<int>();

                for (int i = 0; i < tokens.Count(); i++)
                {
                    if (operatorSet.Contains(tokens[i]))
                    {
                        int n2 = numStack.Pop();
                        int n1 = numStack.Pop();
                        int val = Cal(n1, tokens[i], n2);
                        numStack.Push(val);
                    }
                    else
                    {
                        numStack.Push(int.Parse(tokens[i]));
                    }
                }
                return numStack.Pop();
            }


            private int Cal(int numStr1, string operatorStr, int numStr2)
            {
                switch (operatorStr)
                {
                    case "+": return numStr1 + numStr2;
                    case "-": return numStr1 - numStr2;
                    case "*": return numStr1 * numStr2;
                    case "/": return numStr1 / numStr2;
                    default: throw new ArgumentException();
                }
            }
        }
    }
}
