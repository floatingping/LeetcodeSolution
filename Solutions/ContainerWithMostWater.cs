using LeetcodeSolution.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class ContainerWithMostWater
    {

        [Theory]
        [InlineData("[1,8,6,2,5,4,8,3,7]", 49)]
        [InlineData("[1,1]", 1)]
        public void Test(string input, int expect)
        {
            var inputAry = LeetcodeUtils.ConvertToObject<int[]>(input);
            var aSolution = new Solution();

            int act = aSolution.MaxArea(inputAry);

            Assert.Equal(expect, act);
        }


        public class Solution
        {

            public int MaxArea(int[] height)
            {
                int l = 0;
                int r = height.Count() - 1;
                int result = 0;

                while (l < r)
                {
                    result = Math.Max(result, GetArea(height, l, r));
                    if (height[l] < height[r])
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
                return result;
            }
            public int MaxArea2(int[] height)
            {
                if (height.Count() == 2) return GetArea(height, 0, 1);

                int result = 0;




                for (int l = 0; l < height.Count() - 2; l++)
                {
                    int r = height.Count() - 1;
                    while (l < r)
                    {
                        int area = GetArea(height, l, r);
                        result = Math.Max(area, result);
                        r--;
                    }
                }
                return result;
            }

            private int GetArea(int[] height, int l, int r)
            {
                return Math.Min(height[l], height[r]) * (r - l);
            }
        }
    }
}
