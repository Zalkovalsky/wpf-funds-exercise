using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Funds.Core.Models
{
    public class Fund
    {
        public ObservableCollection<Stock> Stocks { get; } = new ObservableCollection<Stock>();

        public decimal FundTotalMarketValue
        {
            get { return Stocks.Sum(x => x.MarketValue); }
        }

        public long FundTotalNumber => Stocks.Count;
        public double FundTotalStockWeight => 1;

        public void AddStock(Stock stock)
        {
            Stocks.Add(stock);
        }

        public string GenerateStockName(StockType stockType)
        {
            var nextId = Stocks.Count(x => x.StockType == stockType) + 1;

            return $"{(stockType == StockType.Bond ? "Bond" : "Equity")}{nextId}";
        }

        public decimal CalculateStockWeight(Stock stock)
        {
            return stock.MarketValue / FundTotalMarketValue;
        }
    }
}
