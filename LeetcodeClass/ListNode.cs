using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeSolution.LeetcodeClass
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public List<int> ToList()
        {
            var result = new List<int>();
            var node = this;
            while (node != null)
            {
                result.Add(node.val);
                node = node.next;
            }
            return result;
        }




        public static ListNode Create(IEnumerable<int> vals)
        {
            if (vals == null) return null;

            var dummyListNode = new ListNode();

            vals.Aggregate(dummyListNode, (a, c) =>
            {
                a.next = new ListNode(c);
                return a.next;
            });
            return dummyListNode.next;
        }

        public static bool IsListNodeSame(ListNode node1, ListNode node2)
        {
            if (node1 == null) return node1 == node2;
            if (node2 == null) return false;

            var list1 = node1.ToList();
            var list2 = node2.ToList();
            return list1.SequenceEqual(list2);
        }
    }
}
