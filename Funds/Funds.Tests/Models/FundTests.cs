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
                fund.Stocks.Add(new Stock(StockType.Bond, 1m, 1, fund.GenerateNextStockName(StockType.Bond)));
            }

            // Act 
            var testedStock = new Stock(StockType.Bond, price, quantity, fund.GenerateNextStockName(StockType.Bond));
            fund.Stocks.Add(testedStock);
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
                fund.AddStock(StockType.Bond, 1m, 1);
            }

            for (var i = 0; i < equities; i++)
            {
                fund.AddStock(StockType.Equity, 1m, 1);
            }
            // Act 
            var actualName = fund.GenerateNextStockName(typeToAdd);
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
        

    }
}
