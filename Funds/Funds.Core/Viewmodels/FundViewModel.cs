using System;
using Funds.Core.Annotations;
using Funds.Core.Models;
using Funds.Core.Utilities;

namespace Funds.Core.Viewmodels
{
    public class FundViewModel : ObservableObject
    {
        public FundViewModel([NotNull] Fund model)
        {
            Fund = model ?? throw new ArgumentNullException(nameof(model));
        }

        public Fund Fund { get; }
    }
}