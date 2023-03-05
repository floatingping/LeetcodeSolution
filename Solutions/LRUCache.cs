using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetcodeSolution.Solutions
{

    public class LRUCacheTest
    {
        [Fact]
        public void Test()
        {
            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(1, 1); // cache is {1=1}
            lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            lRUCache.Get(1);    // return 1
            lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            lRUCache.Get(2);    // returns -1 (not found)
            lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            lRUCache.Get(1);    // return -1 (not found)
            lRUCache.Get(3);    // return 3
            lRUCache.Get(4);    // return 4
        }
    }



    public class LRUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, Node> _map = new Dictionary<int, Node>();
        private readonly Node _head;
        private readonly Node _tail;
        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _head = new Node(0, 0);
            _tail = new Node(0, 0);

            //head, tail屬於dummy，要記得建立其構造
            _head.Next = _tail;
            _tail.Prev = _head;
        }

        public int Get(int key)
        {
            if (!_map.TryGetValue(key, out var node)) return -1;

            RemoveNode(node);
            AddToHead(node);
            return node.Val;

        }

        public void Put(int key, int value)
        {
            if (_map.TryGetValue(key, out var node))
            {
                node.Val = value;
                RemoveNode(node);
                AddToHead(node);
                return;
            }
            if (_map.Count() == _capacity)
            {
                //小心順序，也可以先宣告
                var toRemove = _tail.Prev;
                RemoveNode(toRemove);
                _map.Remove(toRemove.Key);
            }
            node = new Node(key, value);
            AddToHead(node);
            _map.Add(key, node);
        }




        private void AddToHead(Node node)
        {
            _head.Next.Prev = node;
            node.Next = _head.Next;

            _head.Next = node;
            node.Prev = _head;
        }

        private void RemoveNode(Node node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }




        private class Node
        {
            public Node(int key, int val)
            {
                Key = key;
                Val = val;
            }
            public int Key { get; set; }
            public int Val { get; set; }
            public Node Prev { get; set; }
            public Node Next { get; set; }
        }

    }

}
