using LeetcodeSolution.LeetcodeClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class ReverseLinkedList
    {

        [Fact]
        public void TestNull()
        {
            var aSolution = new Solution();

            Assert.Null(aSolution.ReverseList(null));
        }

        [Fact]
        public void TestOne()
        {
            var aSolution = new Solution();
            var node = new ListNode(5);

            var reverseNode = aSolution.ReverseList(node);

            Assert.Equal(node, reverseNode);
        }







        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        [InlineData(1, 2)]
        public void Test(params int[] vals)
        {
            var aSolution = new Solution();

            var list = aSolution.ReverseList(ListNode.Create(vals));
            var reverselist = ListNode.Create(vals.Reverse().ToArray());

            Assert.True(ListNode.IsListNodeSame(list, reverselist));
        }



        public class Solution
        {
            public ListNode ReverseList(ListNode head)
            {
                ListNode pre = null;
                ListNode cur = head;
                while (cur != null)
                {
                    ListNode next = cur.next;
                    cur.next = pre;
                    pre = cur;
                    cur = next;
                }
                return pre;
            }

            public ListNode MyReverseList(ListNode head)
            {
                if (head == null || head.next == null) return head;

                ListNode prev = null;
                ListNode cur = head;
                ListNode next = head.next;
                while (next != null)
                {
                    var nextHead = next.next;
                    next.next = cur;
                    cur.next = prev;

                    prev = cur;
                    cur = next;
                    next = nextHead;
                }


                return cur;
            }
        }


    }


}
