using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.EditDealDialog
{
    public class EditDealDto
    {
        public int? ActiveSafetyOrdersCount { get; set; }
        public int? MaxSafetyOrders { get; set; }
        public decimal? TrailingDeviation { get; set; }
        public bool? TrailingEnabled { get; set; }
        public decimal? TakeProfit { get; set; }
        public string Name { get; set; }
        public decimal? StopLossPercentage { get; set; }
        public StopLossType? StopLossType { get; set; }
        public bool? StopLossTimeoutEnabled { get; set; }
        public int? StopLossTimeout { get; set; }
        public TakeProfitType? TakeProfitType { get; set; }
    }
}