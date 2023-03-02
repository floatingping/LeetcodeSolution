using LeetcodeSolution.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class MergeIntervals
    {


        [Theory]
        [InlineData("[[1,3],[2,6],[8,10],[15,18]]", "[[1,6],[8,10],[15,18]]")]
        [InlineData("[[1,4],[4,5]]", "[[1,5]]")]
        public void Test(string input, string expect)
        {
            var inputAry = LeetcodeUtils.ConvertToObject<int[][]>(input);
            var expectAry = LeetcodeUtils.ConvertToObject<int[][]>(expect);
            var aSolution = new Solution();

            var actual = aSolution.Merge(inputAry);

            Assert.Equal(expectAry.Count(), actual.Count());

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.Equal(2, actual[i].Count());
                Assert.Equal(actual[i][0], expectAry[i][0]);
                Assert.Equal(actual[i][1], expectAry[i][1]);
            }
        }

        public class Solution
        {
            public int[][] Merge(int[][] intervals)
            {
                if (intervals.Count() == 0) return intervals;

                var orderedData = intervals
                    .Select(interval => new Data(interval))
                    .OrderBy(d => d.StartVal)
                    .ToArray();

                var resultData = new List<Data>() { orderedData[0] };
                for (int i = 1; i < orderedData.Count(); i++)
                {
                    if (resultData[resultData.Count() - 1].CanCombine(orderedData[i]))
                    {
                        resultData[resultData.Count() - 1].Combine(orderedData[i]);
                    }
                    else
                    {
                        resultData.Add(orderedData[i]);
                    }
                }
                return resultData.Select(d => d.Export()).ToArray();
            }


            private class Data
            {
                public int StartVal { get; private set; }
                public int EndVal { get; private set; }
                public Data(int[] interval)
                {
                    StartVal = interval[0];
                    EndVal = interval[1];
                }

                public bool CanCombine(Data data)
                {
                    return !(data.EndVal < StartVal || EndVal < data.StartVal);
                }

                public void Combine(Data data)
                {
                    StartVal = Math.Min(StartVal, data.StartVal);
                    EndVal = Math.Max(EndVal, data.EndVal);
                }


                public int[] Export()
                {
                    return new int[] { StartVal, EndVal };
                }
            }
        }




    }
}
