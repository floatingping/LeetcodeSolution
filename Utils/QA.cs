using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolution.Utils
{
    public class QA<T, U>
        where T : class
        where U : class
    {
        public T Input { get; set; }
        public U Output { get; set; }
    }
}
