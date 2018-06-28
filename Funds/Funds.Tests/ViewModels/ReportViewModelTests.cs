using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
