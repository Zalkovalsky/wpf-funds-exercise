using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Funds.Core.Models;

namespace Funds.Core.Viewmodels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            FundInputViewModel = new FundInputViewModel();
            FundsViewModel = new FundsViewModel();
            ReportViewModel = new ReportViewModel();
        }

        public FundInputViewModel FundInputViewModel { get; set; }
        public FundsViewModel FundsViewModel { get; set; }
        public ReportViewModel ReportViewModel { get; set; }

    }

    public class ReportViewModel : ViewModelBase
    {
        
    }

    public class FundInputViewModel : ViewModelBase
    {
        private StockType _stockType = StockType.Bond;
        public StockType StockType
        {
            get => _stockType;
            set
            {
                if (value == _stockType)
                    return;

                _stockType = value;
                OnPropertyChanged();
            }
        }

        private long _quantity;
        public long Quantity
        {
            get => _quantity;
            set
            {
                if (value == _quantity)
                    return;

                _quantity = value;
                OnPropertyChanged();
            }
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                if (value == _price)
                    return;

                _price = value;
                OnPropertyChanged();
            }
        }

        private ICommand _addFundCommand;
        public ICommand AddFundCommand
        {
            get => _addFundCommand;
            set
            {
                if (value == _addFundCommand)
                    return;

                _addFundCommand = value;
                OnPropertyChanged();
            }
        }
    }

    public class FundsViewModel : ViewModelBase
    {
        private int _equitiesTotalNumber;

        public int EquitiesTotalNumber
        {
            get => _equitiesTotalNumber;
            set
            {
                if (value == _equitiesTotalNumber)
                    return;

                _equitiesTotalNumber = value;
                OnPropertyChanged();
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

        private decimal _equitiesTotalMarketValue;

        public decimal EquitiesTotalMarketValue
        {
            get => _equitiesTotalMarketValue;
            set
            {
                if (value == _equitiesTotalMarketValue)
                    return;

                _equitiesTotalMarketValue = value;
                OnPropertyChanged();
            }
        }

        private int _bondsTotalNumber;

        public int BondsTotalNumber
        {
            get => _bondsTotalNumber;
            set
            {
                if (value == _bondsTotalNumber)
                    return;

                _bondsTotalNumber = value;
                OnPropertyChanged();
            }
        }
        public decimal BondsTotalStockWeight { get; set; }
        public decimal BondsTotalMarketValue { get; set; }

        public int FundTotalNumber { get; set; }
        public decimal FundTotalStockWeight{ get; set; }
        public decimal FundTotalMarketValue { get; set; }

    }
}
