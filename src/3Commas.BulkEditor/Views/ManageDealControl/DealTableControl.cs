using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using _3Commas.BulkEditor.Views.BaseControls;
using _3Commas.BulkEditor.Views.ManageBotControl;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.ManageDealControl
{
    public class DealTableControl : EntityTableControl<DealViewModel>
    {
        private XCommasAccounts _keys;
        private ILogger _logger;

        public DealTableControl()
        {
            InitializeComponent();
            OnRefreshClicked += OnOnRefreshClicked;
        }

        public void Init(XCommasAccounts keys, ILogger logger, IMessageBoxService mbs)
        {
            _keys = keys;
            _logger = logger;
            base.Init("Deals", keys);
        }

        private async void OnOnRefreshClicked(object sender, EventArgs e)
        {
            await RefreshData(_keys);
        }

        public List<DealViewModel> SelectedItems
        {
            get
            {
                var selectedIds = base.SelectedIds;
                return base.Items.Where(x => selectedIds.Contains(x.Id)).ToList();
            }
        }

        public async Task RefreshData(XCommasAccounts keys)
        {
            await base.RefreshData<DealViewModel>(async () =>
                {
                    var botMgr = new XCommasLayer(keys, _logger);
                    var allDeals = (await botMgr.GetAllDeals()).OrderBy(x => x.Deal.Id).ToList();

                    var cfg = new MapperConfigurationExpression();
                    cfg.CreateMap<Deal, DealViewModel>();
                    var mapperConfig = new MapperConfiguration(cfg);
                    var mapper = mapperConfig.CreateMapper();

                    var result = new List<DealViewModel>();
                    foreach (var dealWithExchangeInfo in allDeals)
                    {
                        var dealViewModel = mapper.Map<Deal, DealViewModel>(dealWithExchangeInfo.Deal);
                        dealViewModel.XCommasAccountId = dealWithExchangeInfo.XCommasAccount;
                        dealViewModel.XCommasAccountName = dealWithExchangeInfo.XCommasAccountName;
                        result.Add(dealViewModel);
                    }
                    return result;
                },
                new Tuple<string, int>[]
                {
                    new Tuple<string, int>(nameof(DealViewModel.Id), 65),
                    new Tuple<string, int>(nameof(DealViewModel.DealType), 50),
                    new Tuple<string, int>(nameof(DealViewModel.XCommasAccountName), 100),
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
