using System.Windows.Input;
using Funds.Core.Models;
using Funds.Core.Utilities;

namespace Funds.Core.Viewmodels
{
    public class StockInputViewModel : ObservableObject
    {
        private readonly Fund _fund;

        public StockInputViewModel(Fund fund)
        {
            _fund = fund;
        }

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
            get
            {
                _addFundCommand = _addFundCommand ?? new RelayCommand(AddFund, () => Quantity > 0);

                return _addFundCommand;
            }
        }

        private void AddFund()
        {
            _fund.Stocks.Add(new Stock(StockType, Price, Quantity, _fund.GenerateNextStockName(StockType)));

            Clear();
        }

        private void Clear()
        {
            Price = 0;
            Quantity = 0;
        }
    }
}