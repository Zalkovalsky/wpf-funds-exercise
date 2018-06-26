using System;
using System.Collections.Generic;
using System.Text;

namespace Funds.Core.Viewmodels
{
    public class MainViewModel : ViewModelBase
    {

    }

    public class ReportViewModel : ViewModelBase
    {
        
    }

    public class FundInputViewModel : ViewModelBase
    {
        
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
