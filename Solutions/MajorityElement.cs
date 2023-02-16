using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class GetMajorityElement
    {
        [Theory]
        [InlineData(3, 3, 2, 3)]
        [InlineData(2, 2, 2, 1, 1, 1, 2, 2)]
        public void Test(int expect, params int[] vals)
        {
            int actual = MajorityElement(vals);

            Assert.Equal(expect, actual);
        }

        public int MajorityElement(int[] nums)
        {
            return nums.GroupBy(n => n)
                .FirstOrDefault(g => g.Count() > nums.Count() / 2)
                .Key;
        }


    }
}
