using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using _3Commas.BulkEditor.Views.BaseControls;
using _3Commas.BulkEditor.Views.EditDealDialog;
using Dasync.Collections;
using M.EventBroker;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;
using Keys = _3Commas.BulkEditor.Misc.Keys;

namespace _3Commas.BulkEditor.Views.ManageDealControl
{
    public partial class ManageDealControl : UserControl
    {
        private IMessageBoxService _mbs;
        private Keys _keys;
        private ILogger _logger;
        private IEventBroker _eventBroker;

        public ManageDealControl()
        {
            InitializeComponent();
            tableControl.IsBusyChanged += TableControlOnIsBusy;
        }

        public void Init(Misc.Keys keys, ILogger logger, IMessageBoxService mbs)
        {
            _mbs = mbs;
            _keys = keys;
            _logger = logger;
            _eventBroker = ObjectContainer.EventBroker;
            _eventBroker.Subscribe<KeysChangedEventArgs>(args => this.RunInUiThread(RefreshData));
            tableControl.Init(keys, logger, mbs);

            if (!keys.IsEmpty())
            {
                RefreshData().ConfigureAwait(false);
            }
        }

        private void TableControlOnIsBusy(object sender, IsBusyEventArgs e)
        {
            SetButtonState(!e.IsBusy);
        }

        public void SetButtonState(bool enableButtons)
        {
            btnEdit.Enabled = enableButtons;
            btnDisableTTP.Enabled = enableButtons;
            btnEnableTTP.Enabled = enableButtons;
            btnCancel.Enabled = enableButtons;
            btnPanicSell.Enabled = enableButtons;
        }

        private bool IsValid(List<int> ids)
        {
            if (!ids.Any())
            {
                _mbs.ShowInformation("No deals selected.");
                return false;
            }

            return true;
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var ids = tableControl.SelectedIds;
            if (IsValid(ids))
            {
                var dlg = new EditDealDialog.EditDealDialog(ids.Count, new XCommasLayer(_keys, _logger));
                EditDealDto editData = new EditDealDto();
                dlg.EditDto = editData;
                var dr = dlg.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    var botMgr = new XCommasLayer(_keys, _logger);
                    await ExecuteBulkOperation($"Are you sure to update {tableControl.SelectedIds.Count} deals?", "Applying new settings", async dealId =>
                    {
                        var updateData = new DealUpdateData(dealId);
                        if (editData.ActiveSafetyOrdersCount.HasValue) updateData.MaxSafetyOrdersCount = editData.ActiveSafetyOrdersCount.Value;
                        if (editData.MaxSafetyOrders.HasValue) updateData.MaxSafetyOrders = editData.MaxSafetyOrders.Value;
                        if (editData.TakeProfit.HasValue) updateData.TakeProfit = editData.TakeProfit.Value;
                        if (editData.TakeProfitType.HasValue) updateData.TakeProfitType = editData.TakeProfitType.Value;
                        if (editData.TrailingDeviation.HasValue) updateData.TrailingDeviation = editData.TrailingDeviation.Value;
                        if (editData.TrailingEnabled.HasValue) updateData.TrailingEnabled = editData.TrailingEnabled.Value;
                        if (editData.StopLossPercentage.HasValue) updateData.StopLossPercentage = editData.StopLossPercentage.Value;
                        if (editData.StopLossType.HasValue) updateData.StopLossType = editData.StopLossType.Value;
                        if (editData.StopLossTimeoutEnabled.HasValue) updateData.StopLossTimeoutEnabled = editData.StopLossTimeoutEnabled.Value;
                        if (editData.StopLossTimeout.HasValue) updateData.StopLossTimeoutInSeconds = editData.StopLossTimeout.Value;

                        await botMgr.UpdateDealAsync(updateData);
                    });
                }
            }
        }

        private async void btnEnableTTP_Click(object sender, EventArgs e)
        {
            var mgr = new XCommasLayer(_keys, _logger);
            await ExecuteBulkOperation($"Are you sure to enable TTP for {tableControl.SelectedIds.Count} deals?", "Enable Trailing Take Profit", dealId => mgr.EnableTrailing(dealId)).ConfigureAwait(true);
        }

        private async void btnDisableTTP_Click(object sender, EventArgs e)
        {
            var mgr = new XCommasLayer(_keys, _logger);
            await ExecuteBulkOperation($"Are you sure to disable TTP for {tableControl.SelectedIds.Count} deals?", "Disable Trailing Take Profit", dealId => mgr.DisableTrailing(dealId));
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            var mgr = new XCommasLayer(_keys, _logger);
            await ExecuteBulkOperation($"Are you sure to cancel {tableControl.SelectedIds.Count} deals?", "Cancel Deals", dealId => mgr.CancelDeal(dealId));
        }

        private async void btnPanicSell_Click(object sender, EventArgs e)
        {
            var mgr = new XCommasLayer(_keys, _logger);
            await ExecuteBulkOperation($"Are you sure to panic sell {tableControl.SelectedIds.Count} deals?", "Panic Sell Deals", dealId => mgr.PanicSellDeal(dealId));
        }

        private async Task ExecuteBulkOperation(string confirmationMessage, string operationName, Func<int, Task> updateOperation)
        {
            if (IsValid(tableControl.SelectedIds))
            {
                var dr = _mbs.ShowQuestion(confirmationMessage);
                if (dr == DialogResult.Yes)
                {
                    var cancellationTokenSource = new CancellationTokenSource();
                    var loadingView = new ProgressView.ProgressView(operationName, cancellationTokenSource, tableControl.SelectedIds.Count);
                    loadingView.Show(this);

                    int i = 0;
                    await tableControl.SelectedIds.ParallelForEachAsync(
                        async dealId =>
                        {
                            await updateOperation(dealId);
                            i++;
                            loadingView.SetProgress(i);
                        }, 2, cancellationTokenSource.Token).ConfigureAwait(true);
                    
                    loadingView.Close();
                    if (cancellationTokenSource.IsCancellationRequested)
                    {
                        _logger.LogInformation("Operation cancelled");
                        _mbs.ShowError("Operation cancelled!", "");
                    }
                    else
                    {
                        _mbs.ShowInformation($"Operation finished. See output section for details.");
                    }

                    _logger.LogInformation("Refreshing Deals");
                    await tableControl.RefreshData();
                }
            }
        }

        public void SetDataSource()
        {
            tableControl.SetDataSource<DealViewModel>();
        }

        public async Task RefreshData()
        {
            await tableControl.RefreshData();
            SetDataSource();
        }
    }
}
