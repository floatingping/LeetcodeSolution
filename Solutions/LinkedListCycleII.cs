using LeetcodeSolution.LeetcodeClass;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class LinkedListCycleII
    {

        [Fact]
        public void Test1()
        {

            var nodes = new ListNode[]
            {
                new ListNode(3), //0
                new ListNode(2), //1
                new ListNode(0), //2
                new ListNode(4)
            };

            nodes[0].next = nodes[1];
            nodes[1].next = nodes[2];
            nodes[2].next = nodes[3];
            nodes[3].next = nodes[1];

            Assert.Equal(nodes[1], DetectCycle(nodes[0]));
        }
        [Fact]
        public void Test2()
        {

            var nodes = new ListNode[]
            {
                new ListNode(1)
            };

            Assert.Null(DetectCycle(nodes[0]));
        }

        public ListNode DetectCycle(ListNode head)
        {
            var dummy = new ListNode(0);
            dummy.next = head;

            var fastNode = dummy;
            var slowNode = dummy;

            while (fastNode.next != null && fastNode.next.next != null)
            {
                fastNode = fastNode.next.next;
                slowNode = slowNode.next;

                if (fastNode == slowNode)
                {
                    fastNode = dummy;
                    while (fastNode.next != null)
                    {
                        fastNode = fastNode.next;
                        slowNode = slowNode.next;
                        if (fastNode == slowNode)
                        {
                            return fastNode;
                        }
                    }
                }


            }
            return null;


        }
    }
}
