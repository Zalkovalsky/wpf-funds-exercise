using Funds.Core.Models;
using Funds.Core.Viewmodels;
using Xunit;

namespace Funds.Tests.ViewModels
{
    public class ReportViewModelTests
    {
        [Fact]
        public void ReportViewModel_FundTotalStockWeight_IsZeroForEmptyFund()
        {
            // Arrange
            var model = new Fund();
            var viewModel = new ReportViewModel(model);
            // Act 
            // Assert
            Assert.Equal(0m, viewModel.FundTotalStockWeight);
        }

        [Fact]
        public void ReportViewModel_FundTotalStockWeight_IsOneForNonEmptyFund()
        {
            // Arrange
            var model = new Fund();
            model.Stocks.Add(new Stock(StockType.Bond, 100m, 100, "ab"));
            var viewModel = new ReportViewModel(model);
            // Act 
            // Assert
            Assert.Equal(1m, viewModel.FundTotalStockWeight);
        }

        [Theory]
        [MemberData(nameof(AddStockTestData))]
        public void ReportViewModel_AddedStock_UpdatesBothTypeAndFundSummaryCorrectly(StockType type)
        {
            // Arrange
            var model = new Fund();
            var reportVm = new ReportViewModel(model);
            // Act 
            model.Stocks.Add(new Stock(type, 1m, 1, model.GenerateNextStockName(type)));
            // Assert
            Assert.Equal(1m, reportVm.FundTotalMarketValue);
            Assert.Equal(1, reportVm.FundTotalNumber);
            Assert.Equal(1m, reportVm.FundTotalStockWeight);

            Assert.Equal(1m, type == StockType.Equity ? reportVm.EquitiesTotalMarketValue : reportVm.BondsTotalMarketValue);
            Assert.Equal(1, type == StockType.Equity ? reportVm.EquitiesTotalNumber : reportVm.BondsTotalNumber);
            Assert.Equal(1m, type == StockType.Equity ? reportVm.EquitiesTotalStockWeight : reportVm.BondsTotalStockWeight);
        }

        public static TheoryData<StockType> AddStockTestData => new TheoryData<StockType>
        {
            StockType.Bond,
            StockType.Equity
        };

    }
}
