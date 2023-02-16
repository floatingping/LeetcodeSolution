using System;
using System.Linq;
using Xunit;

namespace LeetcodeSolution
{
    public class BestTimetoBuyandSellStock

    {
        [Theory]
        [InlineData(5, 7, 1, 5, 3, 6, 4)]
        [InlineData(0, 7, 6, 4, 3, 1)]
        [InlineData(4, 3, 2, 6, 5, 0, 3)]
        public void Test(int expect, params int[] vals)
        {
            int actual = MaxProfit(vals);

            Assert.Equal(expect, actual);
        }

        public int MaxProfit(int[] prices)
        {
            if (prices.Count() == 1) return 0;
            var aMaxProfitRealizer = new MaxProfitRealizer(prices[0]);

            for(int i = 1; i< prices.Count(); i++)
            {
                aMaxProfitRealizer.Read(prices[i]);
            }
            return aMaxProfitRealizer.MaxProfit;
        }

        private class MaxProfitRealizer
        {
            private int _lowestPrice;
            private int _higestPrice;
            public int MaxProfit { get; private set; }
            public MaxProfitRealizer(int initPrice)
            {
                _lowestPrice = initPrice;
                _higestPrice = initPrice;
                MaxProfit = 0;
            }


            public void Read(int price)
            {
                if (price > _higestPrice)
                {
                    _higestPrice = price;
                    int profix = price - _lowestPrice;
                    MaxProfit = profix > MaxProfit
                        ? profix
                        : MaxProfit;
                }

                if (price < _lowestPrice)
                {
                    _lowestPrice = price;
                    _higestPrice = price;
                }
            }

        }
    }
}
