using LeetcodeSolution.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetcodeSolution
{
    public class MoveZeroes
    {
        private readonly List<QA<List<int>, List<int>>> _sols = new List<QA<List<int>, List<int>>>()
        {
            new QA<List<int>, List<int>>(){ Input = new List<int>() { 0,1,0,3,12 }, Output = new List<int>() { 1, 3, 12, 0, 0 } },
            new QA<List<int>, List<int>>(){ Input = new List<int>() { 0 }, Output = new List<int>() { 0 } }
        };


        [Fact]
        public void Test()
        {
            var aSolution = new Solution();
            foreach (var qa in _sols)
            {
                var q = qa.Input.ToArray();
                aSolution.MoveZeroes(q);

                Assert.True(qa.Output.SequenceEqual(q));
            }
        }

        public class Solution
        {
            public void MoveZeroes(int[] nums)
            {
                for (int i = 0; i < nums.Count(); i++)
                {
                    if (nums[i] != 0) continue;

                    int r = i + 1;
                    while (r < nums.Count())
                    {
                        if (nums[r] != 0) break;
                        r++;
                    }
                    if (r == nums.Count()) break;

                    nums[i] = nums[r];
                    nums[r] = 0;
                }
            }
        }
    }
}
