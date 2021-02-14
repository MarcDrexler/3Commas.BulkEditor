using System;
using System.Linq;
using System.Threading.Tasks;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using _3Commas.BulkEditor.Views.BaseControls;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;
using Keys = _3Commas.BulkEditor.Misc.Keys;

namespace _3Commas.BulkEditor.Views.ManageBotControl
{
    public class BotTableControl : EntityTableControl<Bot>
    {
        private Keys _keys;
        private ILogger _logger;
        private IMessageBoxService _mbs;

        public BotTableControl()
        {
            InitializeComponent();
            base.OnRefreshClicked += OnOnRefreshClicked;
        }

        public void Init(Misc.Keys keys, ILogger logger, IMessageBoxService mbs)
        {
            _mbs = mbs;
            _keys = keys;
            _logger = logger;
            base.Init("Bots", _keys);
        }

        private async void OnOnRefreshClicked(object sender, EventArgs e)
        {
            await RefreshData();
        }
        
        public async Task RefreshData()
        {
            await base.RefreshData<BotViewModel>(async () =>
                {
                    var botMgr = new XCommasLayer(_keys, _logger);
                    return (await botMgr.GetAllBots()).OrderBy(x => x.Id).ToList();
                },
                nameof(BotViewModel.Id),
                nameof(BotViewModel.Type),
                nameof(BotViewModel.IsEnabled),
                nameof(BotViewModel.Name),
                nameof(BotViewModel.Strategy),
                nameof(BotViewModel.Pair),
                nameof(BotViewModel.AccountName),
                nameof(BotViewModel.MaxActiveDeals),
                nameof(BotViewModel.ActiveDealsCount),
                nameof(BotViewModel.TakeProfit),
                nameof(BotViewModel.TakeProfitType),
                nameof(BotViewModel.ProfitCurrency),
                nameof(BotViewModel.TrailingEnabled),
                nameof(BotViewModel.TrailingDeviation),
                nameof(BotViewModel.DealStartCondition),
                nameof(BotViewModel.StopLossPercentage),
                nameof(BotViewModel.StopLossType),
                nameof(BotViewModel.StopLossTimeoutEnabled),
                nameof(BotViewModel.StopLossTimeoutInSeconds),
                nameof(BotViewModel.BaseOrderVolume),
                nameof(BotViewModel.BaseOrderVolumeType),
                nameof(BotViewModel.StartOrderType),
                nameof(BotViewModel.SafetyOrderVolume),
                nameof(BotViewModel.SafetyOrderVolumeType),
                nameof(BotViewModel.MaxSafetyOrders),
                nameof(BotViewModel.ActiveSafetyOrdersCount),
                nameof(BotViewModel.SafetyOrderStepPercentage),
                nameof(BotViewModel.StopLossPercentage),
                nameof(BotViewModel.LeverageType),
                nameof(BotViewModel.LeverageCustomValue),
                nameof(BotViewModel.MartingaleVolumeCoefficient),
                nameof(BotViewModel.MartingaleStepCoefficient),
                nameof(BotViewModel.MinPrice),
                nameof(BotViewModel.MaxPrice),
                nameof(BotViewModel.MinVolumeBtc24h),
                nameof(BotViewModel.Cooldown),
                nameof(BotViewModel.DisableAfterDealsCount),
                nameof(BotViewModel.FinishedDealsCount),
                nameof(BotViewModel.FinishedDealsProfitUsd),
                nameof(BotViewModel.ProfitRatio),
                nameof(BotViewModel.CreatedAt),
                nameof(BotViewModel.UpdatedAt),
                nameof(BotViewModel.IsDeleteable));
        }
        
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BotTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "BotTableControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
