using System;
using System.Linq;
using Funds.Core.Annotations;
using Funds.Core.Models;
using Funds.Core.Utilities;

namespace Funds.Core.Viewmodels
{
    public class ReportViewModel : ObservableObject
    {
        private readonly Fund _fundModel;

        public ReportViewModel([NotNull] Fund fundModel)
        {
            _fundModel = fundModel ?? throw new ArgumentNullException(nameof(fundModel));
            
            _fundModel.Stocks.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged(null);
            };
        }

        public int EquitiesTotalNumber
        {
            get
            {
                return _fundModel.Stocks.Count(x => x.StockType == StockType.Equity);
            }
        }

        public decimal EquitiesTotalStockWeight
        {
            get
            {
                return FundTotalMarketValue != 0m
                    ? _fundModel.Stocks.Where(x => x.StockType == StockType.Equity).Sum(x => x.MarketValue) /
                      FundTotalMarketValue : 0m;
            }
        }

        public decimal EquitiesTotalMarketValue
        {
            get
            {
                return _fundModel
                    .Stocks
                    .Where(x => x.StockType == StockType.Equity)
                    .Sum(x => x.MarketValue);
            }
        }

        public int BondsTotalNumber
        {
            get
            {
                return _fundModel.Stocks.Count(x => x.StockType == StockType.Bond);
            }
        }

        public decimal BondsTotalStockWeight
        {
            get
            {
                return FundTotalMarketValue != 0m
                    ? _fundModel.Stocks.Where(x => x.StockType == StockType.Bond).Sum(x => x.MarketValue) /
                      FundTotalMarketValue : 0m;
            }
        }

        public decimal BondsTotalMarketValue
        {
            get
            {
                return _fundModel
                    .Stocks
                    .Where(x => x.StockType == StockType.Bond)
                    .Sum(x => x.MarketValue);
            }
        }

        public int FundTotalNumber => _fundModel.Stocks.Count;
        public decimal FundTotalStockWeight => _fundModel.Stocks.Any() ? 1m : 0m;

        public decimal FundTotalMarketValue => _fundModel.Stocks.Sum(x => x.MarketValue);

    }
}