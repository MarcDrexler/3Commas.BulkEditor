using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using _3Commas.BulkEditor.Views.BaseControls;
using _3Commas.BulkEditor.Views.EditDialog;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;
using Keys = _3Commas.BulkEditor.Misc.Keys;

namespace _3Commas.BulkEditor.Views.ManageBotControl
{
    public partial class ManageBotControl : UserControl
    {
        private IMessageBoxService _mbs;
        private Keys _keys;
        private ILogger _logger;

        public ManageBotControl()
        {
            InitializeComponent();
            tableControl.IsBusyChanged += TableControlOnIsBusy;
        }

        public void Init(Misc.Keys keys, ILogger logger, IMessageBoxService mbs)
        {
            _mbs = mbs;
            _keys = keys;
            _logger = logger;
            tableControl.Init(keys, logger, mbs);
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
            var ids = tableControl.SelectedIds;
            if (IsValid(ids))
            {
                var dlg = new EditDialog.EditDialog(ids.Count, new XCommasLayer(_keys, _logger));
                EditDto editData = new EditDto();
                dlg.EditDto = editData;
                var dr = dlg.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    var botMgr = new XCommasLayer(_keys, _logger);
                    await ExecuteBulkOperation("Applying new settings", async botId =>
                    {
                        if (editData.IsEnabled.HasValue)
                        {
                            if (editData.IsEnabled.Value)
                            {
                                await botMgr.Enable(botId);
                            }
                            else
                            {
                                await botMgr.Disable(botId);
                            }
                        }

                        var bot = await botMgr.GetBotById(botId);
                        var updateData = new BotUpdateData(bot);
                        if (editData.ActiveSafetyOrdersCount.HasValue) updateData.ActiveSafetyOrdersCount = editData.ActiveSafetyOrdersCount.Value;
                        if (editData.BaseOrderVolume.HasValue) updateData.BaseOrderVolume = editData.BaseOrderVolume.Value;
                        if (editData.Cooldown.HasValue) updateData.Cooldown = editData.Cooldown.Value;
                        if (editData.MartingaleStepCoefficient.HasValue) updateData.MartingaleStepCoefficient = editData.MartingaleStepCoefficient.Value;
                        if (editData.MartingaleVolumeCoefficient.HasValue) updateData.MartingaleVolumeCoefficient = editData.MartingaleVolumeCoefficient.Value;
                        if (editData.MaxSafetyOrders.HasValue) updateData.MaxSafetyOrders = editData.MaxSafetyOrders.Value;
                        if (!string.IsNullOrWhiteSpace(editData.Name)) updateData.Name = XCommasLayer.GenerateNewName(editData.Name, bot.Strategy.ToString(), bot.Pairs.Single(), bot.AccountName);
                        if (editData.SafetyOrderStepPercentage.HasValue) updateData.SafetyOrderStepPercentage = editData.SafetyOrderStepPercentage.Value;
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

                        var res = await botMgr.SaveBot(botId, updateData);
                        if (res.IsSuccess)
                        {
                            _logger.LogInformation($"Bot {botId} updated");
                        }
                        else
                        {
                            _logger.LogError($"Could not update Bot {botId}. Reason: {res.Error}");
                        }
                    });
                }
            }
        }

        private async void btnCopy_Click(object sender, EventArgs e)
        {
            var dlg = new ChooseAccount.ChooseAccount(_keys, _logger);
            var dr = dlg.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                var botMgr = new XCommasLayer(_keys, _logger);
                await ExecuteBulkOperation($"Copy {tableControl.SelectedIds.Count} Bots in Account '{dlg.Account.Name}' now?", "Bots are now being copied", async botId =>
                {
                    var bot = await botMgr.GetBotById(botId);
                    bot.AccountId = dlg.Account.Id;
                    var res = await botMgr.CreateBot(dlg.Account.Id, bot.Strategy, bot);
                    if (res.IsSuccess)
                    {
                        if (bot.IsEnabled)
                        {
                            await botMgr.Enable(res.Data.Id);
                        }
                        _logger.LogInformation($"Bot {res.Data.Id} created (as a copy of Bot {botId})");
                    }
                    else
                    {
                        _logger.LogError($"Could not copy Bot {botId}. Reason: {res.Error}");
                    }
                });
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var botMgr = new XCommasLayer(_keys, _logger);
            await ExecuteBulkOperation($"Do you really want to delete {tableControl.SelectedIds.Count} Bots?", "Bots are now being deleted", async botId =>
            {
                var res = await botMgr.DeleteBot(botId);
                if (res.IsSuccess)
                {
                    _logger.LogInformation($"Bot {botId} deleted");
                }
                else
                {
                    _logger.LogError($"Could not delete Bot {botId}. Reason: {res.Error}");
                }
            });
        }

        private async Task ExecuteBulkOperation(string confirmationMessage, string inProgressText, Func<int, Task> updateOperation)
        {
            var dr = _mbs.ShowQuestion(confirmationMessage);
            if (dr == DialogResult.Yes)
            {
                await ExecuteBulkOperation(inProgressText, updateOperation);
            }
        }

        private async Task ExecuteBulkOperation(string inProgressText, Func<int, Task> updateOperation)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var loadingView = new ProgressView.ProgressView(inProgressText, cancellationTokenSource, tableControl.SelectedIds.Count);
            loadingView.Show(this);

            int i = 0;
            foreach (var botId in tableControl.SelectedIds)
            {
                i++;
                loadingView.SetProgress(i);

                if (cancellationTokenSource.IsCancellationRequested) break;

                await updateOperation(botId);
            }

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
            await tableControl.RefreshData();
        }

        private bool IsValid(List<int> ids)
        {
            if (!ids.Any())
            {
                _mbs.ShowInformation("No Bots selected");
                return false;
            }

            if (tableControl.Items.Where(x => ids.Contains(x.Id)).Any(x => x.Type != "Bot::SingleBot"))
            {
                _mbs.ShowError("Sorry, Bulk Edit only works for Simple Bots, not advanced.");
                return false;
            }

            return true;
        }

        public void SetDataSource()
        {
            tableControl.SetDataSource();
        }

        public async Task RefreshData()
        {
            await tableControl.RefreshData();
        }
    }
}
