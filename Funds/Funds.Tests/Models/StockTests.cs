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

        [Theory]
        [MemberData(nameof(IsRedForMarketValueTestData))]
        public void Stock_IsRed_ForNegativeMarketValue(decimal price, long qty, bool expectedResult)
        {
            // Arrange
            var stock = new Stock(StockType.Bond, price, qty);
            // Act 
            // Assert
            Assert.Equal(expectedResult, stock.IsRed);
        }

        public static TheoryData<decimal, long, bool> IsRedForMarketValueTestData =>
            new TheoryData<decimal, long, bool>
            {
                {1m, 1, false},
                {-1m, 1, true},
                {0m, 1, false}
            };


        [Theory]
        [MemberData(nameof(TransactionCostTestData))]
        public void Stock_Equity_TransactionCost_IsCalculatedWithCorrectRate(decimal price, long qty)
        {
            // Arrange
            var stock = new Stock(StockType.Equity, price, qty);
            // Act 
            // Assert
            Assert.Equal(StockConstants.EquityTransactionCostMultiplier*stock.MarketValue, stock.TransactionCost);
        }

        [Theory]
        [MemberData(nameof(TransactionCostTestData))]
        public void Stock_Bond_TransactionCost_IsCalculatedWithCorrectRate(decimal price, long qty)
        {
            // Arrange
            var stock = new Stock(StockType.Bond, price, qty);
            // Act 
            // Assert
            Assert.Equal(StockConstants.BondTransactionCostMultiplier*stock.MarketValue, stock.TransactionCost);
        }

        public static TheoryData<decimal, long> TransactionCostTestData =>
            new TheoryData<decimal, long>
            {
                {10m, 10},
                {1m, 1},
                {-1m, 1},
                {0m, 1}
            };

        [Theory]
        [MemberData(nameof(IsRedForExceedingTransactionCostTestData))]
        public void Stock_IsRed_ForTransactionCostOverTolerance(StockType stockType, decimal price, long quantity)
        {
            // Arrange
            var stock = new Stock(stockType, price, quantity);
            // Act 
            // Assert
            Assert.True(stock.IsRed);
        }

        public static TheoryData<StockType, decimal, long> IsRedForExceedingTransactionCostTestData =>
            new TheoryData<StockType,decimal, long>
            {
                {StockType.Bond, 2000, 100000},
                {StockType.Bond, 100000, 2000},
                {StockType.Equity, 200000, 2000},
                {StockType.Equity, 2000, 200000},
            };

    }
}
