using System;
using System.Linq;
using Xunit;

namespace LeetcodeSolution
{
    public class ContainsDuplicate
    {
        [Theory]
        [InlineData(true, 1, 2, 3, 1)]
        [InlineData(false, 1, 2, 3, 4)]
        [InlineData(true, 1, 1, 1, 3, 3, 4, 3, 2, 4, 2)]
        public void Test(bool expect, params int[] vals)
        {
            var aSolution = new Solution();
            bool actual = aSolution.ContainsDuplicate(vals);

            Assert.Equal(expect, actual);
        }

        public class Solution
        {
            public bool ContainsDuplicate(int[] nums)
            {
                return nums.GroupBy(n => n).Any(g => g.Count() > 1);
            }
        }
    }
}
