using LeetcodeSolution.LeetcodeClass;
using LeetcodeSolution.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetcodeSolution
{
    public class MergeTwoSortedLists
    {
        [Theory]
        [InlineData("[1,2,4]", "[1,3,4]", "[1,1,2,3,4,4]")]
        [InlineData("[]", "[]", "[]")]
        [InlineData("[]", "[0]", "[0]")]
        public void Test(string list1Str, string list2Str, string expectStr)
        {
            var list1Data = LeetcodeUtils.ConvertToObject<int[]>(list1Str);
            var list2Data = LeetcodeUtils.ConvertToObject<int[]>(list2Str);
            var expectData = LeetcodeUtils.ConvertToObject<int[]>(expectStr);
            var aSolution = new Solution();

            var actual = aSolution.MergeTwoLists(ListNode.Create(list1Data), ListNode.Create(list2Data));

            Assert.True(expectData.SequenceEqual(actual?.ToList() ?? new List<int>()));
        }


        public class Solution
        {
            public ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {
                ListNode dummy = new ListNode();
                var node = dummy;
                while (list1 != null && list2 != null)
                {
                    if(list1.val < list2.val)
                    {
                        node.next = list1;
                        list1 = list1.next;
                    }
                    else
                    {
                        node.next = list2;
                        list2 = list2.next;
                    }
                    node = node.next;
                }
                node.next = list1 ?? list2;
                return dummy.next;
            }
        }



    }
}
