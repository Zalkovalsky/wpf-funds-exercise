namespace Funds.Core.Models
{
    public static class StockConstants
    {
        public static readonly decimal BondTolerance = 100000m;
        public static readonly decimal EquityTolerance = 200000m;
        public static readonly decimal BondTransactionCostMultiplier = 0.02m;
        public static readonly decimal EquityTransactionCostMultiplier = 0.005m;
    }
}