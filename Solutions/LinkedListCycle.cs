using LeetcodeSolution.LeetcodeClass;
using LeetcodeSolution.Utils;
using System;
using System.Linq;
using Xunit;

namespace LeetcodeSolution
{
    public class LinkedListCycle
    {
        [Fact]
        public void Test1()
        {
            var node0 = new ListNode(3);
            var node1 = new ListNode(2);
            var node2 = new ListNode(0);
            var node3 = new ListNode(4);
            node0.next = node1;
            node1.next = node2;
            node2.next = node3;
            node3.next = node1;
            var aSolution = new Solution();

            Assert.True(aSolution.HasCycle(node0));
        }

        [Fact]
        public void Test2()
        {
            var node0 = new ListNode(1);
            var node1 = new ListNode(2);
            node0.next = node1;
            node1.next = node0;
            var aSolution = new Solution();

            Assert.True(aSolution.HasCycle(node0));
        }

        [Fact]
        public void Test3()
        {
            var node0 = new ListNode(1);
            var aSolution = new Solution();

            Assert.False(aSolution.HasCycle(node0));
        }


        public class Solution
        {
            public bool HasCycle(ListNode head)
            {
                if (head == null) return false;

                var fast = new ListNode(0);
                var slow = new ListNode(0);

                fast.next = head;
                slow.next = head;

                while (fast != null && fast.next != null)
                {
                    if (fast == slow) return true;
                    fast = fast.next.next;
                    slow = slow.next;
                }

                return false;
            }
        }



    }
}
