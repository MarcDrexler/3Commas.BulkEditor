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

namespace _3Commas.BulkEditor.Views.ManageGridBotControl
{
    public class GridBotTableControl : EntityTableControl<GridBotViewModel>
    {
        private XCommasAccounts _keys;
        private ILogger _logger;

        public GridBotTableControl()
        {
            InitializeComponent();
            OnRefreshClicked += OnOnRefreshClicked;
        }

        public void Init(XCommasAccounts keys, ILogger logger)
        {
            _keys = keys;
            _logger = logger;
            base.Init("Grid Bots", _keys);
        }

        private async void OnOnRefreshClicked(object sender, EventArgs e)
        {
            await RefreshData(_keys);
        }

        public async Task RefreshData(XCommasAccounts keys)
        {
            await base.RefreshData<GridBotViewModel>(async () =>
                {
                    var botMgr = new XCommasLayer(keys, _logger);
                    var allBots = (await botMgr.GetAllGridBots()).OrderBy(x => x.Bot.Id).ToList();

                    var cfg = new MapperConfigurationExpression();
                    cfg.CreateMap<GridBot, GridBotViewModel>();
                    var mapperConfig = new MapperConfiguration(cfg);
                    var mapper = mapperConfig.CreateMapper();

                    var result = new List<GridBotViewModel>();
                    foreach (var botWithExchangeInfo in allBots)
                    {
                        var botViewModel = mapper.Map<GridBot, GridBotViewModel>(botWithExchangeInfo.Bot);
                        botViewModel.XCommasAccountId = botWithExchangeInfo.XCommasAccount;
                        botViewModel.XCommasAccountName = botWithExchangeInfo.XCommasAccountName;
                        result.Add(botViewModel);
                    }

                    return result;
                },
                new[]
                {
                    new Tuple<string, int>(nameof(GridBotViewModel.Id), 55),
                    new Tuple<string, int>(nameof(GridBotViewModel.IsEnabled), 80),
                    new Tuple<string, int>(nameof(GridBotViewModel.XCommasAccountName), 120),
                    new Tuple<string, int>(nameof(GridBotViewModel.AccountName), 120),
                    new Tuple<string, int>(nameof(GridBotViewModel.Name), 120),
                    new Tuple<string, int>(nameof(GridBotViewModel.Pair), 100),
                    // new Tuple<string, int>(nameof(GridBotViewModel.LeverageType), 80),
                    // new Tuple<string, int>(nameof(GridBotViewModel.LeverageCustomValue), 80),
                    new Tuple<string, int>(nameof(GridBotViewModel.UpperLimitPrice), 100),
                    new Tuple<string, int>(nameof(GridBotViewModel.LowerLimitPrice), 100),
                    new Tuple<string, int>(nameof(GridBotViewModel.GridsQuantity), 100),
                    new Tuple<string, int>(nameof(GridBotViewModel.QuantityPerGrid), 100),
                    new Tuple<string, int>(nameof(GridBotViewModel.CreatedAt), 100),
                    new Tuple<string, int>(nameof(GridBotViewModel.UpdatedAt), 100),
                });
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // BotTableControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Name = "GridBotTableControl";
            ResumeLayout(false);
            PerformLayout();

        }
    }
}
