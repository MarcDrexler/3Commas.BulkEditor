using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using _3Commas.BulkEditor.Views.BaseControls;
using _3Commas.BulkEditor.Views.EditBotDialog;
using Dasync.Collections;
using M.EventBroker;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.ManageBotControl
{
    public partial class ManageBotControl : UserControl
    {
        private IMessageBoxService _mbs;
        private XCommasAccounts _keys;
        private ILogger _logger;
        private IEventBroker _eventBroker;

        public ManageBotControl()
        {
            InitializeComponent();
            tableControl.IsBusyChanged += TableControlOnIsBusy;
        }

        public void Init(XCommasAccounts keys, ILogger logger, IMessageBoxService mbs)
        {
            _mbs = mbs;
            _keys = keys;
            _logger = logger;
            _eventBroker = ObjectContainer.EventBroker;
            _eventBroker.Subscribe<KeysChangedEventArgs>(args => this.RunInUiThread(() => RefreshData(args.Keys)));
            _eventBroker.Subscribe<StopAllBotsEventArgs>(args => this.RunInUiThread(StopAllBots));
            tableControl.Init(keys, logger);

            if (!keys.IsEmpty)
            {
                RefreshData(keys).ConfigureAwait(false);
            }
        }

        private List<BotViewModel> GetSelectedBots(List<int> ids)
        {
            var selectedBots = tableControl.Items.Where(x => ids.Contains(x.Id)).ToList();
            return selectedBots;
        }

        private void TableControlOnIsBusy(object sender, IsBusyEventArgs e)
        {
            SetButtonState(!e.IsBusy);
        }

        public void SetButtonState(bool enableButtons)
        {
            btnEdit.Enabled = enableButtons;
            btnCopy.Enabled = enableButtons;
            btnDelete.Enabled = enableButtons;
        }

        public async void btnEdit_Click(object sender, EventArgs e)
        {
            var bots = GetSelectedBots(tableControl.SelectedIds);
            if (IsValid(bots))
            {
                var dlg = new EditBotDialog.EditBotDialog(bots.Count, new XCommasLayer(_keys, _logger));
                EditBotDto editData = new EditBotDto();
                dlg.EditDto = editData;
                var dr = dlg.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    var botMgr = new XCommasLayer(_keys, _logger);
                    await ExecuteBulkOperation("Applying new settings", bots, async botVm =>
                    {
                        if (editData.IsEnabled.HasValue)
                        {
                            if (editData.IsEnabled.Value)
                            {
                                await botMgr.Enable(botVm.Id, botVm.XCommasAccountId);
                            }
                            else
                            {
                                await botMgr.Disable(botVm.Id, botVm.XCommasAccountId);
                            }
                        }

                        var bot = await botMgr.GetBotById(botVm.Id, botVm.XCommasAccountId);
                        var updateData = new BotUpdateData(bot);

                        string[] pairs = bot.Pairs;
                        if (!string.IsNullOrWhiteSpace(editData.Pair))
                        {
                            pairs = new[] { editData.Pair };
                            updateData.Pairs = pairs;
                        }
                        if (!string.IsNullOrWhiteSpace(editData.Name)) updateData.Name = XCommasLayer.GenerateNewName(editData.Name, bot.Strategy.ToString(), pairs, bot.AccountName);
                        if (editData.MaxActiveDeals.HasValue) updateData.MaxActiveDeals = editData.MaxActiveDeals.Value;
                        if (editData.ActiveSafetyOrdersCount.HasValue) updateData.ActiveSafetyOrdersCount = editData.ActiveSafetyOrdersCount.Value;
                        if (editData.BaseOrderVolume.HasValue) updateData.BaseOrderVolume = editData.BaseOrderVolume.Value;
                        if (editData.Cooldown.HasValue) updateData.Cooldown = editData.Cooldown.Value;
                        if (editData.MartingaleStepCoefficient.HasValue) updateData.MartingaleStepCoefficient = editData.MartingaleStepCoefficient.Value;
                        if (editData.MartingaleVolumeCoefficient.HasValue) updateData.MartingaleVolumeCoefficient = editData.MartingaleVolumeCoefficient.Value;
                        if (editData.MaxSafetyOrders.HasValue) updateData.MaxSafetyOrders = editData.MaxSafetyOrders.Value;
                        if (editData.SafetyOrderStepPercentage.HasValue) updateData.SafetyOrderStepPercentage = editData.SafetyOrderStepPercentage.Value;
                        if (editData.ProfitCurrency.HasValue) updateData.ProfitCurrency = editData.ProfitCurrency.Value;
                        if (editData.StartOrderType.HasValue) updateData.StartOrderType = editData.StartOrderType.Value;
                        if (editData.SafetyOrderVolume.HasValue) updateData.SafetyOrderVolume = editData.SafetyOrderVolume.Value;
                        if (editData.TakeProfit.HasValue) updateData.TakeProfit = editData.TakeProfit.Value;
                        if (editData.TakeProfitType.HasValue) updateData.TakeProfitType = editData.TakeProfitType.Value;
                        if (editData.TrailingDeviation.HasValue) updateData.TrailingDeviation = editData.TrailingDeviation.Value;
                        if (editData.TrailingEnabled.HasValue) updateData.TrailingEnabled = editData.TrailingEnabled.Value;
                        if (editData.BaseOrderVolumeType.HasValue) updateData.BaseOrderVolumeType = editData.BaseOrderVolumeType.Value;
                        if (editData.SafetyOrderVolumeType.HasValue) updateData.SafetyOrderVolumeType = editData.SafetyOrderVolumeType.Value;
                        if (editData.StopLossPercentage.HasValue) updateData.StopLossPercentage = editData.StopLossPercentage.Value;
                        if (editData.StopLossType.HasValue) updateData.StopLossType = editData.StopLossType.Value;
                        if (editData.StopLossTimeoutEnabled.HasValue) updateData.StopLossTimeoutEnabled = editData.StopLossTimeoutEnabled.Value;
                        if (editData.StopLossTimeout.HasValue) updateData.StopLossTimeoutInSeconds = editData.StopLossTimeout.Value;
                        if (editData.LeverageType.HasValue) updateData.LeverageType = editData.LeverageType.Value;
                        if (editData.LeverageCustomValue.HasValue) updateData.LeverageCustomValue = editData.LeverageCustomValue.Value;

                        if (editData.DisableAfterDealsCountInfo != null)
                        {
                            if (editData.DisableAfterDealsCountInfo.Enable)
                            {
                                updateData.DisableAfterDealsCount = editData.DisableAfterDealsCountInfo.Value;
                            }
                            else
                            {
                                updateData.DisableAfterDealsCount = null;
                            }
                        }

                        if (editData.DealStartConditions.Any())
                        {
                            updateData.Strategies.Clear();
                            updateData.Strategies.AddRange(editData.DealStartConditions);
                        }

                        var res = await botMgr.SaveBot(botVm.Id, updateData, botVm.XCommasAccountId);
                        if (res.IsSuccess)
                        {
                            _logger.LogInformation($"Bot {botVm.Id} updated");
                        }
                        else
                        {
                            _logger.LogError($"Could not update Bot {botVm.Id}. Reason: {res.Error}");
                        }
                    });
                }
            }
        }

        private async void btnCopy_Click(object sender, EventArgs e)
        {
            var dlg = new CopyBotDialog.CopyBotDialog(_keys, _logger);
            var dr = dlg.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                var botMgr = new XCommasLayer(_keys, _logger);
                await ExecuteBulkOperation($"Copy {tableControl.SelectedIds.Count} Bots in Account '{dlg.Account.Name}' now?", "Bots are now being copied", GetSelectedBots(tableControl.SelectedIds), async botVm =>
                {
                    var botEntity = await botMgr.GetBotById(botVm.Id, botVm.XCommasAccountId);
                    botEntity.AccountId = dlg.Account.Id;

                    var res = await botMgr.CreateBot(dlg.Account.Id, botEntity.Strategy, botEntity, dlg.Account.XCommasAccountId);
                    if (res.IsSuccess)
                    {
                        if (dlg.IsEnabled.HasValue && dlg.IsEnabled.Value || !dlg.IsEnabled.HasValue && botEntity.IsEnabled)
                        {
                            await botMgr.Enable(res.Data.Id, dlg.Account.XCommasAccountId);
                        }
                        _logger.LogInformation($"Bot {res.Data.Id} created (as a copy of Bot {botVm.Id})");
                    }
                    else
                    {
                        _logger.LogError($"Could not copy Bot {botVm.Id}. Reason: {res.Error}");
                    }
                });
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var botMgr = new XCommasLayer(_keys, _logger);
            await ExecuteBulkOperation($"Do you really want to delete {tableControl.SelectedIds.Count} Bots?", "Bots are now being deleted", GetSelectedBots(tableControl.SelectedIds), async botVm =>
            {
                var res = await botMgr.DeleteBot(botVm.Id, botVm.XCommasAccountId);
                if (res.IsSuccess)
                {
                    _logger.LogInformation($"Bot {botVm.Id} deleted");
                }
                else
                {
                    _logger.LogError($"Could not delete Bot {botVm.Id}. Reason: {res.Error}");
                }
            });
        }

        public async Task StopAllBots()
        {
            var botMgr = new XCommasLayer(_keys, _logger);
            await ExecuteBulkOperation($"Do you really want to stop {tableControl.Items.Count} Bots?", "Bots are now being stopped", tableControl.Items, async botVm =>
            {
                var res = await botMgr.Disable(botVm.Id, botVm.XCommasAccountId);
                if (res.IsSuccess)
                {
                    _logger.LogInformation($"Bot {botVm.Id} stopped");
                }
                else
                {
                    _logger.LogError($"Could not stop Bot {botVm.Id}. Reason: {res.Error}");
                }
            });
        }

        private async Task ExecuteBulkOperation(string confirmationMessage, string inProgressText, List<BotViewModel> bots, Func<BotViewModel, Task> updateOperation)
        {
            var dr = _mbs.ShowQuestion(confirmationMessage);
            if (dr == DialogResult.Yes)
            {
                await ExecuteBulkOperation(inProgressText, bots, updateOperation).ConfigureAwait(false);
            }
        }

        private async Task ExecuteBulkOperation(string inProgressText, List<BotViewModel> bots, Func<BotViewModel, Task> updateOperation)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var loadingView = new ProgressView.ProgressView(inProgressText, cancellationTokenSource, bots.Count);
            loadingView.Show(this);

            int i = 0;
            await bots.ParallelForEachAsync(
                async bot =>
                {
                    await updateOperation(bot);
                    i++;
                    loadingView.SetProgress(i);
                }, 5, cancellationTokenSource.Token).ConfigureAwait(true);

            loadingView.Close();
            if (cancellationTokenSource.IsCancellationRequested)
            {
                _logger.LogInformation("Operation cancelled");
                _mbs.ShowError("Operation cancelled!", "");
            }
            else
            {
                _mbs.ShowInformation("Operation finished. See output section for details.");
            }

            _logger.LogInformation("Refreshing Bots");
            await tableControl.RefreshData(_keys);
        }

        private bool IsValid(List<BotViewModel> ids)
        {
            if (!ids.Any())
            {
                _mbs.ShowInformation("No Bots selected");
                return false;
            }

            return true;
        }

        public void SetDataSource()
        {
            tableControl.SetDataSource<BotViewModel>();
        }

        public async Task RefreshData(XCommasAccounts keys)
        {
            await tableControl.RefreshData(keys);
            SetDataSource();
        }
    }
}
