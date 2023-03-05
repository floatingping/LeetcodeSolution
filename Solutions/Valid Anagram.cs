using LeetcodeSolution.Utils;
using System;
using System.Linq;
using Xunit;

namespace LeetcodeSolution
{
    public class ValidAnagram
    {
        [Theory]
        [InlineData("anagram", "nagaram", true)]
        [InlineData("rat", "car", false)]
        public void Test(string input1, string input2, bool expect)
        {
            var aSolution = new Solution();

            var actual1 = aSolution.IsAnagram(input1, input2);
            var actual2 = aSolution.IsAnagram2(input1, input2);

            Assert.Equal(expect, actual1);
            Assert.Equal(expect, actual2);
        }


        public class Solution
        {
            public bool IsAnagram(string s, string t)
            {
                if (s.Length != t.Length) return false;

                var sMap = new int[26];
                for (int i = 0; i < s.Length; i++)
                {
                    sMap[s[i] - 'a']++;
                }

                for (int i = 0; i < s.Length; i++)
                {
                    if (sMap[t[i] - 'a'] == 0) return false;
                    sMap[t[i] - 'a']--;
                }

                for(int i = 0; i< sMap.Count(); i++)
                {
                    if (sMap[i] != 0) return false;
                }

                return true;
            }
            public bool IsAnagram2(string s, string t)
            {
                var sMap = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
                var tMap = t.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

                if (sMap.Count() != tMap.Count()) return false;

                foreach (var kv in sMap)
                {
                    if (!tMap.TryGetValue(kv.Key, out int v)) return false;
                    if (kv.Value != v) return false;
                }
                return true;

            }
        }



    }
}