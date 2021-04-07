using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using _3Commas.BulkEditor.Views.BaseControls;
using _3Commas.BulkEditor.Views.EditGridBotDialog;
using Dasync.Collections;
using M.EventBroker;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.ManageGridBotControl
{
    public partial class ManageGridBotControl : UserControl
    {
        private IMessageBoxService _mbs;
        private XCommasAccounts _keys;
        private ILogger _logger;
        private IEventBroker _eventBroker;

        public ManageGridBotControl()
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

        private List<GridBotViewModel> GetSelectedBots(List<int> ids)
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
                var dlg = new EditGridBotDialog.EditGridBotDialog(bots.Count, new XCommasLayer(_keys, _logger));
                EditGridBotDto editData = new EditGridBotDto();
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
                                await botMgr.EnableGridBot(botVm.Id, botVm.XCommasAccountId);
                            }
                            else
                            {
                                await botMgr.DisableGridBot(botVm.Id, botVm.XCommasAccountId);
                            }
                        }

                        var botData = await botMgr.GetGridBotById(botVm.Id, botVm.XCommasAccountId);
                        var updateData = new GridBotUpdateData(botVm.Id, botData);
                        if (editData.QuantityPerGrid.HasValue) updateData.QuantityPerGrid = editData.QuantityPerGrid.Value;
                        if (editData.UpperLimitPrice.HasValue) updateData.UpperLimitPrice = editData.UpperLimitPrice.Value;
                        if (editData.LowerLimitPrice.HasValue) updateData.LowerLimitPrice = editData.LowerLimitPrice.Value;
                        if (editData.GridsQuantity.HasValue) updateData.GridsQuantity = editData.GridsQuantity.Value;

                        var res = await botMgr.SaveGridBot(botVm.Id, updateData, botVm.XCommasAccountId);
                        if (res.IsSuccess)
                        {
                            _logger.LogInformation($"Grid Bot {botVm.Id} updated");
                        }
                        else
                        {
                            _logger.LogError($"Could not update Grid Bot {botVm.Id}. Reason: {res.Error}");
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
                await ExecuteBulkOperation($"Copy {tableControl.SelectedIds.Count} Grid Bots in Account '{dlg.Account.Name}' now?", "Grid Bots are now being copied", GetSelectedBots(tableControl.SelectedIds), async botVm =>
                {
                    var botEntity = await botMgr.GetGridBotById(botVm.Id, botVm.XCommasAccountId);
                    botEntity.AccountId = dlg.Account.Id;

                    var res = await botMgr.CreateGridBot(dlg.Account.Id, botEntity, dlg.Account.XCommasAccountId);
                    if (res.IsSuccess)
                    {
                        if (dlg.IsEnabled.HasValue && dlg.IsEnabled.Value || !dlg.IsEnabled.HasValue && botEntity.IsEnabled)
                        {
                            await botMgr.EnableGridBot(res.Data.Id, dlg.Account.XCommasAccountId);
                        }
                        _logger.LogInformation($"Grid Bot {res.Data.Id} created (as a copy of Grid Bot {botVm.Id})");
                    }
                    else
                    {
                        _logger.LogError($"Could not copy Grid Bot {botVm.Id}. Reason: {res.Error}");
                    }
                });
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var botMgr = new XCommasLayer(_keys, _logger);
            await ExecuteBulkOperation($"Do you really want to delete {tableControl.SelectedIds.Count} Grid Bots?", "Grid Bots are now being deleted", GetSelectedBots(tableControl.SelectedIds), async botVm =>
            {
                var res = await botMgr.DeleteGridBot(botVm.Id, botVm.XCommasAccountId);
                if (res.IsSuccess)
                {
                    _logger.LogInformation($"Grid Bot {botVm.Id} deleted");
                }
                else
                {
                    _logger.LogError($"Could not delete Grid Bot {botVm.Id}. Reason: {res.Error}");
                }
            });
        }

        public async Task StopAllBots()
        {
            var botMgr = new XCommasLayer(_keys, _logger);
            await ExecuteBulkOperation($"Do you really want to stop {tableControl.Items.Count} Grid Bots?", "Grid Bots are now being stopped", tableControl.Items, async botVm =>
            {
                var res = await botMgr.Disable(botVm.Id, botVm.XCommasAccountId);
                if (res.IsSuccess)
                {
                    _logger.LogInformation($"Grid Bot {botVm.Id} stopped");
                }
                else
                {
                    _logger.LogError($"Could not stop Grid Bot {botVm.Id}. Reason: {res.Error}");
                }
            });
        }

        private async Task ExecuteBulkOperation(string confirmationMessage, string inProgressText, List<GridBotViewModel> bots, Func<GridBotViewModel, Task> updateOperation)
        {
            var dr = _mbs.ShowQuestion(confirmationMessage);
            if (dr == DialogResult.Yes)
            {
                await ExecuteBulkOperation(inProgressText, bots, updateOperation).ConfigureAwait(false);
            }
        }

        private async Task ExecuteBulkOperation(string inProgressText, List<GridBotViewModel> bots, Func<GridBotViewModel, Task> updateOperation)
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

        private bool IsValid(List<GridBotViewModel> ids)
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
            tableControl.SetDataSource<GridBotViewModel>();
        }

        public async Task RefreshData(XCommasAccounts keys)
        {
            await tableControl.RefreshData(keys);
            SetDataSource();
        }
    }
}
