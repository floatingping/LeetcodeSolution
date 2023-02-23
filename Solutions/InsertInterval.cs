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

        public class QA
        {
            public QA(int[][] origin, int[] insert, int[][] expect)
            {
                Origin = origin;
                Insert = insert;
                Expect = expect;
            }

            public int[][] Origin { get; }
            public int[] Insert { get; }
            public int[][] Expect { get; }
        }

        public static QA GetQA1()
        {
            return new QA(
            new int[][]
            {
                    new int[] { 1, 3 },
                    new int[] { 6, 9 }
            },

            new int[] { 2, 5 },

            new int[][]
            {
                    new int[] { 1, 5 },
                    new int[] { 6, 9 }
            });
        }


        public static QA GetQA2()
        {
            return new QA(
            new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3, 5 },
                new int[] { 6, 7 },
                new int[] { 8, 10 },
                new int[] { 12, 16 }
            },

            new int[] { 4, 8 },

            new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3, 10 },
                new int[] { 12, 16 }
            });
        }


        public static QA GetQA3()
        {
            return new QA(
            new int[][]
            {
            },

            new int[] { 5, 7 },

            new int[][]
            {
                new int[] { 5, 7 }
            });
        }
        public static QA GetQA4()
        {
            return new QA(
            new int[][]
            {
                new int[] { 1, 5 }
            },

            new int[] { 2, 3 },

            new int[][]
            {
                new int[] { 1, 5 }
            });
        }


        [Fact]
        public void Test()
        {
            var qaList = new List<QA>() { GetQA1(), GetQA2(), GetQA3(), GetQA4() };
            var aSolution = new Solution();

            foreach (var qa in qaList)
            {
                var actual = aSolution.Insert(qa.Origin, qa.Insert);
                var expect = qa.Expect;

                Assert.Equal(expect.Count(), actual.Count());

                for (int i = 0; i < actual.Count(); i++)
                {
                    Assert.Equal(2, actual[i].Count());
                    Assert.Equal(actual[i][0], expect[i][0]);
                    Assert.Equal(actual[i][1], expect[i][1]);
                }

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
