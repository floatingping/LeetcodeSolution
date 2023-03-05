using LeetcodeSolution.LeetcodeClass;
using LeetcodeSolution.Utils;
using System;
using System.Linq;
using Xunit;

namespace LeetcodeSolution
{
    public class MiddleoftheLinkedList
    {
        [Fact]
        public void Test1()
        {
            var node0 = new ListNode(1);
            var node1 = new ListNode(2);
            var node2 = new ListNode(3);
            var node3 = new ListNode(4);
            var node4 = new ListNode(5);
            node0.next = node1;
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            var aSolution = new Solution();

            Assert.Equal(node2, aSolution.MiddleNode(node0));
        }

        [Fact]
        public void Test2()
        {
            var node0 = new ListNode(1);
            var node1 = new ListNode(2);
            var node2 = new ListNode(3);
            var node3 = new ListNode(4);
            var node4 = new ListNode(5);
            var node5 = new ListNode(6);
            node0.next = node1;
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            var aSolution = new Solution();

            Assert.Equal(node3, aSolution.MiddleNode(node0));
        }

        public class Solution
        {

            public ListNode MiddleNode(ListNode head)
            {
                ListNode slow = head;
                ListNode fast = head;

                while (fast != null && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }

                return slow;
            }
            public ListNode MiddleNode2(ListNode head)
            {

                int length = 0;
                var node = head;
                while (node != null)
                {
                    length++;
                    node = node.next;
                }

                int counts = length / 2 + 1;
                node = head;
                while (counts > 1)
                {
                    counts--;
                    node = node.next;
                }

                return node;
            }
        }



    }
}
