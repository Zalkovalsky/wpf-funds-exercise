using System;
using System.Collections.Generic;
using System.Text;

namespace Funds.Core.Models
{
    public class Stock
    {
        public Stock(StockType stockType, decimal price, long quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity has to be a non-negative number");
            }

            Price = price;
            Quantity = quantity;
            StockType = stockType;
        }

        public decimal Price { get; }
        public long Quantity { get; }
        public StockType StockType { get; }

        public decimal MarketValue => Price * Quantity;
        public decimal Tolerance => StockType == StockType.Bond ? 
            StockConstants.BondTolerance : StockConstants.EquityTolerance;
        public decimal TransactionCost
        {
            get
            {
                var multiplier = StockType == StockType.Bond
                    ? StockConstants.BondTransactionCostMultiplier
                    : StockConstants.EquityTransactionCostMultiplier;

                return MarketValue * multiplier;
            }
        }
        public bool IsRed
        {
            get
            {
                if (MarketValue < 0)
                    return true;

                return TransactionCost > Tolerance;
            }
        }
    }
}
