using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funds.Core.Models;
using Xunit;

namespace Funds.Tests.Models
{
    public class FundTests
    {
        [Theory]
        [MemberData(nameof(CalculateStockDataTestData))]
        public void Fund_CalculateStockWeight_CalculatesMarketValuePercentageOfStockInFund((int stocksInFund, decimal exptectedWeight) testData)
        {
            // Arrange
            const decimal price = 1;
            const long quantity = 1;

            var fund = new Fund();
            
            for (var i = 0; i < testData.stocksInFund; i++)
            {
                fund.AddStock(new Stock(StockType.Bond, price, quantity));
            }

            // Act 
            var testedStock = new Stock(StockType.Bond, price, quantity);
            fund.AddStock(testedStock);
            var stockWeight = fund.CalculateStockWeight(testedStock);
            // Assert
            Assert.Equal(testData.exptectedWeight, stockWeight);
        }

        public static TheoryData<(int stocksInFund, decimal exptectedWeight)> CalculateStockDataTestData =>
            new TheoryData<(int, decimal)>
            {
                (4, 0.2m),
                (0, 1m),
                (1, 0.5m)
            };

        [Theory]
        [MemberData(nameof(GenerateStockNameTestData))]
        public void Fund_GenerateStockName_CreatesNameBasedOnTheFundContents(int bonds, int equities, StockType typeToAdd, string expectedName)
        {
            // Arrange
            var fund = new Fund();
            for (var i = 0; i < bonds; i++)
            {
                fund.AddStock(new Stock(StockType.Bond, 1, 1));
            }

            for (var i = 0; i < equities; i++)
            {
                fund.AddStock(new Stock(StockType.Equity, 1, 1));
            }
            // Act 
            var actualName = fund.GenerateStockName(typeToAdd);
            // Assert
            Assert.Equal(expectedName, actualName);
        }

        public static TheoryData<int, int, StockType, string> GenerateStockNameTestData =>
            new TheoryData<int, int, StockType, string>
            {
                {0, 0, StockType.Bond, "Bond1"},
                {1, 0, StockType.Bond, "Bond2"},
                {1, 1, StockType.Bond, "Bond2"},
                {63, 0, StockType.Bond, "Bond64"},
                {0, 0, StockType.Equity, "Equity1"},
                {0, 1, StockType.Equity, "Equity2"},
                {1, 1, StockType.Equity, "Equity2"},
                {0, 63, StockType.Equity, "Equity64"},
            };

        [Fact]
        public void Fund_Summary_IsCalculatedCorrectly()
        {
            // Arrange
            var fund = new Fund();
            // Act 
            fund.AddStock(new Stock(StockType.Bond, 10, 10));
            fund.AddStock(new Stock(StockType.Bond, 10, 10));
            fund.AddStock(new Stock(StockType.Bond, 10, 10));
            fund.AddStock(new Stock(StockType.Bond, 10, 10));
            fund.AddStock(new Stock(StockType.Bond, 10, 10));
            // Assert
            Assert.Equal(500m, fund.FundTotalMarketValue);
            Assert.Equal(5, fund.FundTotalNumber);
            Assert.Equal(1, fund.FundTotalStockWeight);
        }
        

    }
}
