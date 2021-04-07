using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3Commas.BulkEditor.Misc;
using _3Commas.BulkEditor.Views.BaseControls;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.ManageBotControl
{
    public class BotTableControl : EntityTableControl<BotViewModel>
    {
        private XCommasAccounts _keys;
        private ILogger _logger;

        public BotTableControl()
        {
            InitializeComponent();
            OnRefreshClicked += OnOnRefreshClicked;
        }

        public void Init(XCommasAccounts keys, ILogger logger)
        {
            _keys = keys;
            _logger = logger;
            base.Init("DCA Bots", _keys);
        }

        private async void OnOnRefreshClicked(object sender, EventArgs e)
        {
            await RefreshData(_keys);
        }

        public async Task RefreshData(XCommasAccounts keys)
        {
            await base.RefreshData<BotViewModel>(async () =>
                {
                    var botMgr = new XCommasLayer(keys, _logger);
                    var allBots = (await botMgr.GetAllBots()).OrderBy(x => x.Bot.Id).ToList();

                    var cfg = new MapperConfigurationExpression();
                    cfg.CreateMap<Bot, BotViewModel>();
                    var mapperConfig = new MapperConfiguration(cfg);
                    var mapper = mapperConfig.CreateMapper();

                    var result = new List<BotViewModel>();
                    foreach (var botWithExchangeInfo in allBots)
                    {
                        var botViewModel = mapper.Map<Bot, BotViewModel>(botWithExchangeInfo.Bot);
                        botViewModel.XCommasAccountId = botWithExchangeInfo.XCommasAccount;
                        botViewModel.XCommasAccountName = botWithExchangeInfo.XCommasAccountName;
                        result.Add(botViewModel);
                    }
                    return result;
                },
                new[]
                {
                    new Tuple<string, int>(nameof(BotViewModel.Id), 55),
                    new Tuple<string, int>(nameof(BotViewModel.BotType), 70),
                    new Tuple<string, int>(nameof(BotViewModel.IsEnabled), 65),
                    new Tuple<string, int>(nameof(BotViewModel.XCommasAccountName), 120),
                    new Tuple<string, int>(nameof(BotViewModel.AccountName), 120),
                    new Tuple<string, int>(nameof(BotViewModel.Name), 120),
                    new Tuple<string, int>(nameof(BotViewModel.Strategy), 70),
                    new Tuple<string, int>(nameof(BotViewModel.Pair), 100),
                    new Tuple<string, int>(nameof(BotViewModel.MaxActiveDeals), 100),
                    new Tuple<string, int>(nameof(BotViewModel.ActiveDealsCount), 100),
                    new Tuple<string, int>(nameof(BotViewModel.TakeProfit), 50),
                    new Tuple<string, int>(nameof(BotViewModel.TakeProfitType), 70),
                    new Tuple<string, int>(nameof(BotViewModel.ProfitCurrency), 90),
                    new Tuple<string, int>(nameof(BotViewModel.TrailingEnabled), 70),
                    new Tuple<string, int>(nameof(BotViewModel.TrailingDeviation), 90),
                    new Tuple<string, int>(nameof(BotViewModel.DealStartCondition), 200),
                    new Tuple<string, int>(nameof(BotViewModel.StopLossPercentage), 100),
                    new Tuple<string, int>(nameof(BotViewModel.StopLossType), 70),
                    new Tuple<string, int>(nameof(BotViewModel.StopLossTimeoutEnabled), 100),
                    new Tuple<string, int>(nameof(BotViewModel.StopLossTimeoutInSeconds), 80),
                    new Tuple<string, int>(nameof(BotViewModel.BaseOrderVolume), 60),
                    new Tuple<string, int>(nameof(BotViewModel.BaseOrderVolumeType), 80),
                    new Tuple<string, int>(nameof(BotViewModel.StartOrderType), 60),
                    new Tuple<string, int>(nameof(BotViewModel.SafetyOrderVolume), 60),
                    new Tuple<string, int>(nameof(BotViewModel.SafetyOrderVolumeType), 80),
                    new Tuple<string, int>(nameof(BotViewModel.MaxSafetyOrders), 80),
                    new Tuple<string, int>(nameof(BotViewModel.ActiveSafetyOrdersCount), 80),
                    new Tuple<string, int>(nameof(BotViewModel.SafetyOrderStepPercentage), 80),
                    new Tuple<string, int>(nameof(BotViewModel.LeverageType), 80),
                    new Tuple<string, int>(nameof(BotViewModel.LeverageCustomValue), 80),
                    new Tuple<string, int>(nameof(BotViewModel.MartingaleVolumeCoefficient), 80),
                    new Tuple<string, int>(nameof(BotViewModel.MartingaleStepCoefficient), 80),
                    new Tuple<string, int>(nameof(BotViewModel.MinPrice), 80),
                    new Tuple<string, int>(nameof(BotViewModel.MaxPrice), 80),
                    new Tuple<string, int>(nameof(BotViewModel.MinVolumeBtc24h), 80),
                    new Tuple<string, int>(nameof(BotViewModel.Cooldown), 80),
                    new Tuple<string, int>(nameof(BotViewModel.DisableAfterDealsCount), 80),
                    new Tuple<string, int>(nameof(BotViewModel.FinishedDealsCount), 80),
                    new Tuple<string, int>(nameof(BotViewModel.FinishedDealsProfitUsd), 80),
                    new Tuple<string, int>(nameof(BotViewModel.ProfitRatio), 80),
                    new Tuple<string, int>(nameof(BotViewModel.CreatedAt), 100),
                    new Tuple<string, int>(nameof(BotViewModel.UpdatedAt), 100),
                    new Tuple<string, int>(nameof(BotViewModel.IsDeleteable), 80)
                });
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // BotTableControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Name = "BotTableControl";
            ResumeLayout(false);
            PerformLayout();

        }
    }
}
