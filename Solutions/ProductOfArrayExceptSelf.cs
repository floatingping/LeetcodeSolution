using LeetcodeSolution.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class ProductOfArrayExceptSelf
    {

        [Theory]
        [InlineData("[1,2,3,4]", "[24,12,8,6]")]
        [InlineData("[-1,1,0,-3,3]", "[0,0,9,0,0]")]
        public void Test(string inputStr, string expectStr)
        {
            var input = LeetcodeUtils.ConvertToObject<int[]>(inputStr);
            var expect = LeetcodeUtils.ConvertToObject<int[]>(expectStr);

            var aSolution = new Solution();
            //var actual = aSolution.ProductExceptSelf(input);
            var actual = aSolution.ProductExceptSelf2(input);
            Assert.True(expect.SequenceEqual(actual));
        }




        public class Solution
        {
            public int[] ProductExceptSelf(int[] nums)
            {
                int[] result = new int[nums.Length];


                result[0] = 1;
                for (int i = 1; i < nums.Length; i++)
                {
                    result[i] = nums[i - 1] * result[i - 1];
                }

                int r = 1;
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    result[i] = result[i] * r;
                    r *= nums[i];

                }
                return result;
            }


            public int[] ProductExceptSelf2(int[] nums)
            {
                var lefts = new int[nums.Length];
                var rights = new int[nums.Length];
                var result = new int[nums.Length];

                lefts[0] = 1;
                for (int i = 1; i < nums.Length; i++)
                {
                    lefts[i] = lefts[i - 1] * nums[i - 1];
                }

                rights[nums.Length-1] = 1;
                for (int i = nums.Length - 2; i >= 0; i--)
                {
                    rights[i] = rights[i + 1] * nums[i + 1];
                }


                for (int i = 0; i < nums.Length; i++)
                {
                    result[i] = lefts[i] * rights[i];
                }



                return result;
            }
        }
    }
}
