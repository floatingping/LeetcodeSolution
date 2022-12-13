using System;
using Xunit;

namespace LeetcodeSolution
{
    public class BinarySearch
    {
        [Theory]
        [InlineData(4, 9, -1, 0, 3, 5, 9, 12)]
        [InlineData(-1, 2, -1, 0, 3, 5, 9, 12)]
        public void Test(int expect, int find, params int[] vals)
        {
            int actual = Search(vals, find);

            Assert.Equal(expect, actual);
        }

        public int Search(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length;
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] < target)
                {
                    l = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    r = mid;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
    }
}
