using Funds.Core.Models;
using Funds.Core.Utilities;

namespace Funds.Core.Viewmodels
{
    public class MainViewModel : ObservableObject
    {
        private readonly Fund _fundModel = new Fund();

        public MainViewModel()
        {
            FundViewModel = new FundViewModel(_fundModel);
            ReportViewModel = new ReportViewModel(_fundModel);
            StockInputViewModel = new StockInputViewModel(_fundModel);
        }

        public StockInputViewModel StockInputViewModel { get; }
        public FundViewModel FundViewModel { get; }
        public ReportViewModel ReportViewModel { get; }
    }
}
