using System.Linq;
using Funds.Core.Models;
using Funds.Core.Utilities;

namespace Funds.Core.Viewmodels
{
    public class ReportViewModel : ObservableObject
    {
        private readonly Fund _fundModel;

        public ReportViewModel(Fund fundModel)
        {
            _fundModel = fundModel;
            
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

        private decimal _equitiesTotalStockWeight;
        public decimal EquitiesTotalStockWeight
        {
            get => _equitiesTotalStockWeight;
            set
            {
                if (value == _equitiesTotalStockWeight)
                    return;

                _equitiesTotalStockWeight = value;
                OnPropertyChanged();
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

        private decimal _bondsTotalStockWeight;
        public decimal BondsTotalStockWeight
        {
            get => _bondsTotalStockWeight;
            set
            {
                if (value == _bondsTotalStockWeight)
                    return;

                _bondsTotalStockWeight = value;
                OnPropertyChanged();
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
        public decimal FundTotalStockWeight => 1m;

        public decimal FundTotalMarketValue => _fundModel.Stocks.Sum(x => x.MarketValue);

    }
}