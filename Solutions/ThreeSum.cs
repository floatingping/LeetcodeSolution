using LeetcodeSolution.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class ThreeSum
    {


        [Theory()]
        [InlineData("[-1,0,1,2,-1,-4]", "[[-1,-1,2],[-1,0,1]]")]
        [InlineData("[0,1,1]", "[]")]
        [InlineData("[0,0,0]", "[[0,0,0]]")]
        [InlineData("[0,0,0,0]", "[[0,0,0]]")]
        [InlineData("[1,1,-2]", "[[-2,1,1]]")]
        [InlineData("[-1,0,1,0]", "[[-1,0,1]]")]
        [InlineData("[3,0,-2,-1,1,2]", "[[-2,-1,3],[-2,0,2],[-1,0,1]]")]
        [InlineData("[-4,-2,1,-5,-4,-4,4,-2,0,4,0,-2,3,1,-5,0]", "[[-5,1,4],[-4,0,4],[-4,1,3],[-2,-2,4]]")]
        public void Test(string input, string output)
        {
            var inputData = LeetcodeUtils.ConvertToObject<int[]>(input);
            var outputData = LeetcodeUtils.ConvertToObject<int[][]>(output);

            var aSolution = new Solution();
            var act = aSolution.ThreeSum(inputData);

            Assert.Equal(outputData.Count(), act.Count());
            for (int i = 0; i < act.Count(); i++)
            {
                Assert.True(act[i].SequenceEqual(outputData[i]));
            }

        }





        public class Solution
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                var orderedNums = nums.OrderBy(n => n).ToList();

                var result = new List<IList<int>>() { };


                for (int i = 0; i < orderedNums.Count(); i++)
                {
                    if (orderedNums[i] > 0) return result;

                    if (i > 0 && orderedNums[i] == orderedNums[i - 1]) continue;

                    int l = i + 1;
                    int r = orderedNums.Count() -1;

                    while (l < r)
                    {
                        while (l < r && orderedNums[l] == orderedNums[l + 1]) l++;
                        while (l < r && orderedNums[r - 1] == orderedNums[r]) r--;


                        if(orderedNums[i] + orderedNums[l] + orderedNums[r] > 0)
                        {
                            r--;
                        }
                        else if (orderedNums[i] + orderedNums[l] + orderedNums[r] < 0)
                        {
                            l++;
                        }
                        else
                        {
                            result.Add(new List<int>() { orderedNums[i] , orderedNums[l] , orderedNums[r] });

                            while (l < r && orderedNums[l] == orderedNums[l + 1]) l++;
                            while (l < r && orderedNums[r - 1] == orderedNums[r]) r--;

                            l++;
                            r--;
                        }
                    }
                }

                return result;









                //int l = 0;
                //int mid = l + 1;
                //int r = orderedNums.Count() - 1;

                //while (mid < r)
                //{
                //    int sum = orderedNums[l] + orderedNums[mid] + orderedNums[r];
                //    if (sum > 0)
                //    {
                //        r--;
                //    }
                //    else if (sum < 0)
                //    {
                //        mid++;
                //        if (mid == r)
                //        {
                //            l++;
                //            mid = l + 1;
                //        }
                //    }
                //    else
                //    {
                //        while (mid < r && orderedNums[mid] == orderedNums[mid+1])
                //        {
                //            mid++;
                //        }
                //        while (l < mid && orderedNums[l] == orderedNums[l + 1])
                //        {
                //            l++;
                //        }
                //        while (mid < r && orderedNums[r - 1] == orderedNums[r])
                //        {
                //            r--;
                //        }
                //        result.Add(new List<int>() { orderedNums[l], orderedNums[mid], orderedNums[r] });
                //        mid++;
                //    }
                //}
            }
        }
    }
}
