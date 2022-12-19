using LeetcodeSolution.LeetcodeClass;
using LeetcodeSolution.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class SwapNodesInPairs
    {




        private readonly List<QA<List<int>, List<int>>> _sols = new List<QA<List<int>, List<int>>>()
        {
            new QA<List<int>, List<int>>(){ Input = new List<int>() { 1, 2, 3, 4 }, Output = new List<int>() { 2, 1, 4, 3 } },
            new QA<List<int>, List<int>>(){ Input = new List<int>() { }, Output = new List<int>() { } },
            new QA<List<int>, List<int>>(){ Input = new List<int>() { 1 }, Output = new List<int>() { 1 } }
        };


        [Fact]
        public void Test()
        {
            foreach(var qa in _sols)
            {
                var actual = SwapPairs(ListNode.Create(qa.Input));
                var expected = ListNode.Create(qa.Output);

                Assert.True(ListNode.IsListNodeSame(actual, expected));
            }
        }


        public ListNode SwapPairs(ListNode head)
        {
            var dummyNode = new ListNode(0, head);
            var node = dummyNode;

            while (node.next != null)
            {
                if (node.next.next == null) break;

                var n1 = node.next;
                var n2 = node.next.next;
                var n3 = node.next.next.next;

                node.next = n2;
                n2.next = n1;
                n1.next = n3;
                node = n1;
            }
            return dummyNode.next;

        }



    }
}
