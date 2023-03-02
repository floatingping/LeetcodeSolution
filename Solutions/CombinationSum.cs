using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeSolution.Solutions
{
    internal class CombinationSum
    {



        public class Solution
        {
            private readonly List<int> _currAry = new List<int>();
            private readonly List<IList<int>> _result = new List<IList<int>>();

            public IList<IList<int>> CombinationSum(int[] candidates, int target)
            {
                var orderedCandidates = candidates.OrderBy(n => n).ToArray();
                Cal(orderedCandidates, target, 0);

                return _result;
            }
            private void Cal(int[] orderedNums, int target, int startIdx)
            {
                if (target == 0)
                {
                    _result.Add(_currAry.ToList());
                    return;
                }

                for (int i = startIdx; i < orderedNums.Count(); i++)
                {
                    if (orderedNums[i] > target) return;
                    
                    _currAry.Add(orderedNums[i]);

                    Cal(orderedNums, target - orderedNums[i], i);

                    _currAry.RemoveAt(_currAry.Count() - 1);
                }
            }

        }
    }
}
