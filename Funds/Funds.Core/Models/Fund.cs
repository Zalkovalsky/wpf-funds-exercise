﻿using System.Collections.ObjectModel;
using System.Linq;

namespace Funds.Core.Models
{
    public class Fund
    {
        public ObservableCollection<Stock> Stocks { get; } = new ObservableCollection<Stock>();

        public Fund()
        {
            Stocks.CollectionChanged += (sender, args) =>
            {
                foreach (var stock in Stocks)
                {
                    stock.StockWeight = CalculateStockWeight(stock);
                }
            };
        }


        public void AddStock(StockType stockType, decimal price, long quantity)
        {
            var stock = new Stock(stockType, price, quantity, GenerateNextStockName(stockType));

            Stocks.Add(stock);
        }

        public string GenerateNextStockName(StockType withType)
        {
            var nextId = Stocks.Count(x => x.StockType == withType) + 1;

            return $"{(withType == StockType.Bond ? "Bond" : "Equity")}{nextId}";
        }

        public decimal CalculateStockWeight(Stock stock)
        {
            var fundTotalMarketValue = Stocks.Sum(x => x.MarketValue);
            
            return fundTotalMarketValue != 0m ? stock.MarketValue / fundTotalMarketValue : 0m;
        }
    }
}
