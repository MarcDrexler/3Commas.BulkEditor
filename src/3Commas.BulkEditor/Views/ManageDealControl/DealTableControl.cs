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
                new Tuple<string, int>[]
                {
                    new Tuple<string, int>(nameof(DealViewModel.Id), 65),
                    new Tuple<string, int>(nameof(DealViewModel.DealType), 50),
                    new Tuple<string, int>(nameof(DealViewModel.Account), 100),
                    new Tuple<string, int>(nameof(DealViewModel.BotId), 55),
                    new Tuple<string, int>(nameof(DealViewModel.BotName), 130),
                    new Tuple<string, int>(nameof(DealViewModel.Pair), 100),
                    new Tuple<string, int>(nameof(DealViewModel.DealHasErrors), 50),
                    new Tuple<string, int>(nameof(DealViewModel.ErrorMessage), 100),
                    new Tuple<string, int>(nameof(DealViewModel.TakeProfit), 50),
                    new Tuple<string, int>(nameof(DealViewModel.TakeProfitType), 70),
                    new Tuple<string, int>(nameof(DealViewModel.IsTrailingEnabled), 70),
                    new Tuple<string, int>(nameof(DealViewModel.TrailingDeviation), 90),
                    new Tuple<string, int>(nameof(DealViewModel.TrailingMaxPrice), 80),
                    new Tuple<string, int>(nameof(DealViewModel.BoughtAmount), 80),
                    new Tuple<string, int>(nameof(DealViewModel.BoughtVolume), 80),
                    new Tuple<string, int>(nameof(DealViewModel.BoughtAveragePrice), 80),
                    new Tuple<string, int>(nameof(DealViewModel.SoldAmount), 80),
                    new Tuple<string, int>(nameof(DealViewModel.SoldVolume), 80),
                    new Tuple<string, int>(nameof(DealViewModel.SoldAveragePrice), 80),
                    new Tuple<string, int>(nameof(DealViewModel.BaseOrderVolume), 80),
                    new Tuple<string, int>(nameof(DealViewModel.BaseOrderVolumeType), 80),
                    new Tuple<string, int>(nameof(DealViewModel.SafetyOrderVolume), 80),
                    new Tuple<string, int>(nameof(DealViewModel.SafetyOrderVolumeType), 80),
                    new Tuple<string, int>(nameof(DealViewModel.MartingaleCoefficient), 80),
                    new Tuple<string, int>(nameof(DealViewModel.MaxSafetyOrders), 80),
                    new Tuple<string, int>(nameof(DealViewModel.ActiveSafetyOrdersCount), 80),
                    new Tuple<string, int>(nameof(DealViewModel.CompletedSafetyOrdersCount), 80),
                    new Tuple<string, int>(nameof(DealViewModel.CurrentActiveSafetyOrdersCount), 80),
                    new Tuple<string, int>(nameof(DealViewModel.SafetyOrderStepPercentage), 80),
                    new Tuple<string, int>(nameof(DealViewModel.IsCancellable), 80),
                    new Tuple<string, int>(nameof(DealViewModel.IsPanicSellable), 80),
                    new Tuple<string, int>(nameof(DealViewModel.CreatedAt), 100),
                    new Tuple<string, int>(nameof(DealViewModel.UpdatedAt), 100)
                });
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
