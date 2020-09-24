using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.EditDialog
{
    public class EditDto
    {
        public int? Cooldown { get; set; }
        public decimal? MartingaleStepCoefficient { get; set; }
        public decimal? MartingaleVolumeCoefficient { get; set; }
        public decimal? SafetyOrderStepPercentage { get; set; }
        public int? ActiveSafetyOrdersCount { get; set; }
        public int? MaxSafetyOrders { get; set; }
        public decimal? TrailingDeviation { get; set; }
        public decimal? StopLossPercentage { get; set; }
        public bool? TrailingEnabled { get; set; }
        public decimal? TakeProfit { get; set; }
        public decimal? SafetyOrderVolume { get; set; }
        public string Name { get; set; }
        public decimal? BaseOrderVolume { get; set; }
        public StartOrderType? StartOrderType { get; set; }
        public bool? IsEnabled { get; set; }
        public DisableAfterDealsCountDto DisableAfterDealsCountInfo { get; set; }
        public List<BotStrategy> DealStartConditions { get; set; } = new List<BotStrategy>();
        public VolumeType? BaseOrderVolumeType { get; set; }
        public VolumeType? SafetyOrderVolumeType { get; set; }
    }

    public class DisableAfterDealsCountDto
    {
        public bool Enable { get; set; }
        public int Value { get; set; }
    }
}
