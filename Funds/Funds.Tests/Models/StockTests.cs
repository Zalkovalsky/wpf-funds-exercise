using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funds.Core.Models;
using Xunit;

namespace Funds.Tests.Models
{
    public class StockTests
    {
        [Fact]
        public void Stock_Quantity_HasToBeNonNegative()
        {
            // Arrange
            // Act 
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var _ = new Stock(StockType.Bond, 10, -1);
            });
        }

        [Fact]
        public void Stock_MarketValue_IsCalculatedFromPriceAndQuantity()
        {
            // Arrange
            var stock = new Stock(StockType.Bond, 10, 10);
            // Act 
            // Assert
            Assert.Equal(100, stock.MarketValue);
        }

        [Fact]
        public void Stock_Equity_TransactionCost_IsCalculatedWithCorrectRate()
        {
            // Arrange
            var stock = new Stock(StockType.Equity, 10, 10);
            // Act 
            // Assert
            Assert.Equal((decimal)(0.005*100), stock.TransactionCost);
        }


        [Fact]
        public void Stock_Bond_TransactionCost_IsCalculatedWithCorrectRate()
        {
            // Arrange
            var stock = new Stock(StockType.Bond, 10, 10);
            // Act 
            // Assert
            Assert.Equal((decimal)(100*0.02), stock.TransactionCost);
        }

        [Fact]
        public void Stock_IsRed_ForNegativeMarketValue()
        {
            // Arrange
            var stock = new Stock(StockType.Bond, -1, 10);
            // Act 
            // Assert
            Assert.True(stock.IsRed);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Stock_IsRed_ForTransactionCostOverTolerance(StockType stockType, decimal price, long quantity)
        {
            // Arrange
            var stock = new Stock(stockType, price, quantity);
            // Act 
            // Assert
            Assert.True(stock.IsRed);
        }

        public static TheoryData<StockType, decimal, long> Data =>
            new TheoryData<StockType,decimal, long>
            {
                {StockType.Bond, 2000, 100000},
                {StockType.Bond, 100000, 2000},
                {StockType.Equity, 200000, 2000},
                {StockType.Equity, 2000, 200000},
            };

    }
}
