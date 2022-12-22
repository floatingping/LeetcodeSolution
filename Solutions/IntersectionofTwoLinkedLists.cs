using LeetcodeSolution.LeetcodeClass;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class IntersectionofTwoLinkedLists
    {

        [Fact]
        public void Test()
        {
            var nodes = new ListNode[]
            {
                new ListNode(4), //0
                new ListNode(1), //1
                new ListNode(8), //2
                new ListNode(4), //3
                new ListNode(5), //4
                new ListNode(5), //5
                new ListNode(6), //6
                new ListNode(1) //7
            };

            nodes[0].next = nodes[1];
            nodes[1].next = nodes[2];
            nodes[2].next = nodes[3];
            nodes[3].next = nodes[4];

            nodes[5].next = nodes[6];
            nodes[6].next = nodes[7];
            nodes[7].next = nodes[2];
            


            var headA = nodes[0];
            var headB = nodes[5];
            Assert.Equal(nodes[2], GetIntersectionNode(headA, headB));
            
        }



        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            int nodeALength = GetNodeLength(headA);
            int nodeBLength = GetNodeLength(headB);

            ListNode longNode;
            ListNode shortNode;
            int diff;
            if (nodeALength >= nodeBLength)
            {
                longNode = headA;
                shortNode = headB;
                diff = nodeALength - nodeBLength;
            }
            else
            {
                longNode = headB;
                shortNode = headA;
                diff = nodeBLength - nodeALength;
            }


            while (diff > 0)
            {
                longNode = longNode.next;
                diff--;
            }


            while (longNode != null)
            {
                if (longNode == shortNode) return longNode;
                longNode = longNode.next;
                shortNode = shortNode.next;
            }

            return null;

        }


        private int GetNodeLength(ListNode aListNode)
        {
            var node = aListNode;
            int result = 0;
            while (node != null)
            {
                result++;
                node = node.next;
            }
            return result;
        }
    }
}
