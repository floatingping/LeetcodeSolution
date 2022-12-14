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

            Assert.Null(ReverseList(null));
        }

        [Fact]
        public void TestOne()
        {
            var node = new ListNode(5);
            var reverseNode = ReverseList(node);
            Assert.Equal(node, reverseNode);
        }







        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        [InlineData(1, 2)]
        public void Test(params int[] vals)
        {
            var list = ReverseList(ListNode.Create(vals));
            var reverselist = ListNode.Create(vals.Reverse().ToArray());

            Assert.True(ListNode.IsListNodeSame(list, reverselist));
        }



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
    }


}
