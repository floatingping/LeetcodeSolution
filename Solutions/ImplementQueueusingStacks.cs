using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetcodeSolution.Solutions
{
    public class ImplementQueueusingStacks
    {
        [Fact]
        public void Test()
        {
            MyQueue obj = new MyQueue();
            obj.Push(1);
            obj.Push(2);
            Assert.Equal(1, obj.Peek());
            Assert.Equal(1, obj.Pop());
            Assert.False(obj.Empty());
        }

        public class MyQueue
        {


            private readonly Stack<int> _stack = new Stack<int>();
            private readonly Stack<int> _tmpStack = new Stack<int>();
            public MyQueue()
            {

            }

            public void Push(int x)
            {
                _stack.Push(x);
            }

            public int Pop()
            {
                while (_stack.Any())
                {
                    _tmpStack.Push(_stack.Pop());
                }

                int result = _tmpStack.Pop();

                while (_tmpStack.Any())
                {
                    _stack.Push(_tmpStack.Pop());
                }

                return result;
            }

            public int Peek()
            {
                while (_stack.Any())
                {
                    _tmpStack.Push(_stack.Pop());
                }

                int result = _tmpStack.Peek();

                while (_tmpStack.Any())
                {
                    _stack.Push(_tmpStack.Pop());
                }

                return result;
            }

            public bool Empty()
            {
                return !_stack.Any();
            }
        }

        /**
         * Your MyQueue object will be instantiated and called as such:
         * MyQueue obj = new MyQueue();
         * obj.Push(x);
         * int param_2 = obj.Pop();
         * int param_3 = obj.Peek();
         * bool param_4 = obj.Empty();
         */
    }
}
