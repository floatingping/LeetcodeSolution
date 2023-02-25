using LeetcodeSolution.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class InsertInterval
    {

        [Theory]
        [InlineData("[[1,3],[6,9]]", "[2,5]", "[[1,5],[6,9]]")]
        [InlineData("[[1,2],[3,5],[6,7],[8,10],[12,16]]", "[4,8]", "[[1,2],[3,10],[12,16]]")]
        [InlineData("[]", "[5,7]", "[[5,7]]")]
        [InlineData("[[1,5]]", "[2,3]", "[[1,5]]")]
        public void Test(string oStr, string iStr, string expect)
        {
            var aryO = LeetcodeUtils.ConvertStringToTwoDimensionArray(oStr).Where(a => a.Count() > 0).ToArray();
            var aryI = LeetcodeUtils.ConvertStringToOneDimensionArray(iStr);
            var aryE = LeetcodeUtils.ConvertStringToTwoDimensionArray(expect);
            var aSolution = new Solution();


            var actual = aSolution.Insert(aryO, aryI.ToArray());
            //var expect = qa.Expect;

            Assert.Equal(aryE.Count(), actual.Count());

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.Equal(2, actual[i].Count());
                Assert.Equal(actual[i][0], aryE[i][0]);
                Assert.Equal(actual[i][1], aryE[i][1]);
            }
        }


        public class Solution
        {
            public int[][] Insert(int[][] intervals, int[] newInterval)
            {
                var list = new List<int[]>() { };
                int head = newInterval[0];
                int tail = newInterval[1];
                int i = 0;
                while (i < intervals.Count())
                {
                    if (intervals[i][1] < head)
                    {
                        list.Add(intervals[i]);
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }

                while (i < intervals.Count())
                {
                    if (tail < intervals[i][0]) break;
                    head = Math.Min(head, intervals[i][0]);
                    tail = Math.Max(tail, intervals[i][1]);
                    i++;
                }
                list.Add(new int[] { head, tail });


                while (i < intervals.Count())
                {
                    list.Add(intervals[i]);
                    i++;
                }

                return list.ToArray();
            }
        }
    }
}
