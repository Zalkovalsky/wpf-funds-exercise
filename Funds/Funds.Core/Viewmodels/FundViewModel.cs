using Funds.Core.Models;
using Funds.Core.Utilities;

namespace Funds.Core.Viewmodels
{
    public class FundViewModel : ObservableObject
    {
        public FundViewModel(Fund model)
        {
            Fund = model;
        }

        public Fund Fund { get; }
    }
}