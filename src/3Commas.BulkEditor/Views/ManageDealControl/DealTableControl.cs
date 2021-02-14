using System;
using System.Linq;
using System.Threading.Tasks;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using _3Commas.BulkEditor.Views.BaseControls;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;
using Keys = _3Commas.BulkEditor.Misc.Keys;

namespace _3Commas.BulkEditor.Views.ManageDealControl
{
    public class DealTableControl : EntityTableControl<Deal>
    {
        private Keys _keys;
        private ILogger _logger;

        public DealTableControl()
        {
            InitializeComponent();
            OnRefreshClicked += OnOnRefreshClicked;
        }

        public void Init(Keys keys, ILogger logger, IMessageBoxService mbs)
        {
            _keys = keys;
            _logger = logger;
            base.Init("Deals", _keys);
        }

        private async void OnOnRefreshClicked(object sender, EventArgs e)
        {
            await RefreshData();
        }
        
        public async Task RefreshData()
        {
            await base.RefreshData<DealViewModel>(async () =>
                {
                    var botMgr = new XCommasLayer(_keys, _logger);
                    return (await botMgr.GetAllDeals()).OrderBy(x => x.Id).ToList();
                },
                nameof(DealViewModel.Id),
                nameof(DealViewModel.DealType),
                nameof(DealViewModel.AccountId),
                // Currently 3c API returns empty string for account: https://github.com/3commas-io/3commas-official-api-docs/issues/35
                //nameof(DealViewModel.AccountName),
                nameof(DealViewModel.BotId),
                nameof(DealViewModel.BotName),
                nameof(DealViewModel.Pair),
                nameof(DealViewModel.DealHasErrors),
                nameof(DealViewModel.ErrorMessage),
                nameof(DealViewModel.TakeProfit),
                nameof(DealViewModel.TakeProfitType),
                nameof(DealViewModel.IsTrailingEnabled),
                nameof(DealViewModel.TrailingDeviation),
                nameof(DealViewModel.TrailingMaxPrice),
                nameof(DealViewModel.BoughtAmount),
                nameof(DealViewModel.BoughtVolume),
                nameof(DealViewModel.BoughtAveragePrice),
                nameof(DealViewModel.SoldAmount),
                nameof(DealViewModel.SoldVolume),
                nameof(DealViewModel.SoldAveragePrice),
                nameof(DealViewModel.BaseOrderVolume),
                nameof(DealViewModel.BaseOrderVolumeType),
                nameof(DealViewModel.SafetyOrderVolume),
                nameof(DealViewModel.SafetyOrderVolumeType),
                nameof(DealViewModel.MartingaleCoefficient),
                nameof(DealViewModel.MaxSafetyOrders),
                nameof(DealViewModel.ActiveSafetyOrdersCount),
                nameof(DealViewModel.CompletedSafetyOrdersCount),
                nameof(DealViewModel.CurrentActiveSafetyOrdersCount),
                nameof(DealViewModel.SafetyOrderStepPercentage),
                nameof(DealViewModel.IsCancellable),
                nameof(DealViewModel.IsPanicSellable),
                nameof(DealViewModel.CreatedAt),
                nameof(DealViewModel.UpdatedAt));
        }
        
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // DealTableControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Name = "DealTableControl";
            ResumeLayout(false);
            PerformLayout();

        }
    }
}
