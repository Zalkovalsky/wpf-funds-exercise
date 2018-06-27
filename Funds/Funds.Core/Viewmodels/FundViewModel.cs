using Funds.Core.Models;
using Funds.Core.Utilities;

namespace Funds.Core.Viewmodels
{
    public class FundViewModel : ObservableObject
    {
        private readonly Fund _model;

        public FundViewModel(Fund model)
        {
            _model = model;
        }


    }
}