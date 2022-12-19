using LeetcodeSolution.LeetcodeClass;
using LeetcodeSolution.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class RemoveNthNodeFromEndofList
    {



        private readonly List<QA<List<int>, List<int>>> _sols = new List<QA<List<int>, List<int>>>()
        {
            new QA<List<int>, List<int>>(){ Input = new List<int>() { 2, 1,2,3,4,5 }, Output = new List<int>() { 1,2,3,5 } },
            new QA<List<int>, List<int>>(){ Input = new List<int>() { 1, 1 }, Output = new List<int>() { } },
            new QA<List<int>, List<int>>(){ Input = new List<int>() { 1, 1, 2 }, Output = new List<int>() { 1 } }
        };


        [Fact]
        public void Test()
        {
            foreach (var qa in _sols)
            {
                var actual = RemoveNthFromEnd(ListNode.Create(qa.Input.Skip(1)), qa.Input[0]);
                var expected = ListNode.Create(qa.Output);

                Assert.True(ListNode.IsListNodeSame(actual, expected));
            }
        }



        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var dummy = new ListNode(0, head);
            var fastHead = dummy;
            var slowHead = dummy; //小心直接用head.....因為如果只有一個，概念會不一樣
            while (n > 0)
            {
                fastHead = fastHead.next;
                n--;
            }


            while (fastHead.next != null)
            {
                fastHead = fastHead.next;
                slowHead = slowHead.next;
            }
            slowHead.next = slowHead.next.next;


            return dummy.next;
        }
    }
}
