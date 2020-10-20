using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using _3Commas.BulkEditor.Views.EditDialog;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;
using Keys = _3Commas.BulkEditor.Misc.Keys;

namespace _3Commas.BulkEditor.Views.MainForm
{
    public class MainFormPresenter : PresenterBase<IMainForm>
    {
        private readonly Keys _keys = new Keys();
        private readonly ILogger _logger;
        private readonly IMessageBoxService _mbs;
        private List<Bot> _bots = new List<Bot>();

        public MainFormPresenter(IMainForm view, ILogger logger, IMessageBoxService mbs) : base(view)
        {
            _logger = logger;
            _mbs = mbs;
            _keys.ApiKey3Commas = Properties.Settings.Default.ApiKey3Commas;
            _keys.Secret3Commas = Properties.Settings.Default.Secret3Commas;
        }

        internal async Task OnViewReady()
        {
            if (!string.IsNullOrWhiteSpace(_keys.ApiKey3Commas) && !string.IsNullOrWhiteSpace(_keys.Secret3Commas))
            {
                await RefreshBots();
            }
        }

        public async Task On3CommasLinkClicked()
        {
            var settingsPersisted = !string.IsNullOrWhiteSpace(Properties.Settings.Default.ApiKey3Commas);
            var settings = new Settings.Settings(settingsPersisted, "3Commas API Credentials", "Permissions Needed: BotsRead, BotsWrite, AccountsRead", _keys.ApiKey3Commas, _keys.Secret3Commas);
            var dr = settings.ShowDialog();
            if (dr == DialogResult.OK)
            {
                _keys.ApiKey3Commas = settings.ApiKey;
                _keys.Secret3Commas = settings.Secret;

                Properties.Settings.Default.ApiKey3Commas = settings.PersistKeys ? settings.ApiKey : "";
                Properties.Settings.Default.Secret3Commas = settings.PersistKeys ? settings.Secret : "";
                Properties.Settings.Default.Save();

                await RefreshBots();
            }
        }

        private async Task RefreshBots()
        {
            View.SetOperationInProgress(true);
            _bots = new List<Bot>();
            View.RefreshBotGrid(_bots);
            if (!String.IsNullOrWhiteSpace(_keys.Secret3Commas) && !String.IsNullOrWhiteSpace(_keys.ApiKey3Commas))
            {
                var botMgr = new BotManager(_keys, _logger);
                _bots = (await botMgr.GetAllBots()).OrderBy(x => x.Id).ToList();
            }
            View.RefreshBotGrid(_bots);
            View.SetTotalBotCount(_bots.Count);
            View.SetOperationInProgress(false);
        }

        public void OnClearClick()
        {
            View.ClearLog();
        }

        public void OnListChanged(int count)
        {
            View.SetVisibleCount(count);
        }

        public void OnGridFilterChanged(string filterString)
        {
            View.ShowFilterInformation(!string.IsNullOrWhiteSpace(filterString));
        }

        public void OnSelectionChanged(int count)
        {
            View.SetSelectedRowCount(count);
        }

        public async void OnEdit()
        {
            var ids = View.SelectedBotIds;

            if (IsValid(ids))
            {
                var dlg = new EditDialog.EditDialog(ids.Count);
                EditDto editData = new EditDto();
                dlg.EditDto = editData;
                var dr = dlg.ShowDialog(View);
                if (dr == DialogResult.OK)
                {
                    var cancellationTokenSource = new CancellationTokenSource();
                    var loadingView = new ProgressView.ProgressView("Applying new settings", cancellationTokenSource, ids.Count);
                    loadingView.Show(View);
                    
                    var botMgr = new BotManager(_keys, _logger);

                    int i = 0;
                    foreach (var botId in ids)
                    {
                        i++;
                        loadingView.SetProgress(i);

                        if (cancellationTokenSource.IsCancellationRequested)
                        {
                            break;
                        }

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
                        if (!string.IsNullOrWhiteSpace(editData.Name)) updateData.Name = BotManager.GenerateNewName(editData.Name, bot.Strategy.ToString(), bot.Pairs.Single());
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
                    }

                    loadingView.Close();
                    if (cancellationTokenSource.IsCancellationRequested)
                    {
                        _logger.LogInformation("Operation cancelled");
                        _mbs.ShowError("Operation cancelled!", "");
                    }
                    else
                    {
                        _mbs.ShowInformation("Bulk Edit finished. See output section for details.");
                    }

                    _logger.LogInformation("Refreshing Bots");
                    await RefreshBots();
                }
            }
        }

        public async Task OnCopy()
        {
            var ids = View.SelectedBotIds;

            if (IsValid(ids))
            {
                var dlg = new ChooseAccount.ChooseAccount(_keys, _logger);
                var dr = dlg.ShowDialog(View);
                if (dr == DialogResult.OK)
                {
                    dr = _mbs.ShowQuestion($"Copy {ids.Count} Bots in Account '{dlg.Account.Name}' now?");
                    if (dr == DialogResult.Yes)
                    {
                        var cancellationTokenSource = new CancellationTokenSource();
                        var loadingView = new ProgressView.ProgressView("Bots are now being copied", cancellationTokenSource, ids.Count);
                        loadingView.Show(View);

                        var botMgr = new BotManager(_keys, _logger);

                        int i = 0;
                        foreach (var botId in ids)
                        {
                            i++;
                            loadingView.SetProgress(i);

                            if (cancellationTokenSource.IsCancellationRequested)
                            {
                                break;
                            }

                            var bot = await botMgr.GetBotById(botId);
                            bot.AccountId = dlg.Account.Id;
                            var res = await botMgr.CreateBot(dlg.Account.Id, bot.Strategy, bot);
                            if (res.IsSuccess)
                            {
                                _logger.LogInformation($"Bot {botId} created");
                            }
                            else
                            {
                                _logger.LogError($"Could not copy Bot {botId}. Reason: {res.Error}");
                            }
                        }

                        loadingView.Close();
                        if (cancellationTokenSource.IsCancellationRequested)
                        {
                            _logger.LogInformation("Operation cancelled");
                            _mbs.ShowError("Operation cancelled!", "");
                        }
                        else
                        {
                            _mbs.ShowInformation("Bulk Copy finished. See output section for details.");
                        }

                        _logger.LogInformation("Refreshing Bots");
                        await RefreshBots();
                    }
                }
            }
        }

        public async Task OnDelete()
        {
            var ids = View.SelectedBotIds;

            if (IsValid(ids))
            {
                var dr = _mbs.ShowQuestion($"Do you really want to delete {ids.Count} Bots?");
                if (dr == DialogResult.Yes)
                {
                    var cancellationTokenSource = new CancellationTokenSource();
                    var loadingView = new ProgressView.ProgressView("Bots are now being deleted", cancellationTokenSource, ids.Count);
                    loadingView.Show(View);

                    var botMgr = new BotManager(_keys, _logger);

                    int i = 0;
                    foreach (var botId in ids)
                    {
                        i++;
                        loadingView.SetProgress(i);

                        if (cancellationTokenSource.IsCancellationRequested)
                        {
                            break;
                        }

                        var res = await botMgr.DeleteBot(botId);
                        if (res.IsSuccess)
                        {
                            _logger.LogInformation($"Bot {botId} deleted");
                        }
                        else
                        {
                            _logger.LogError($"Could not delete Bot {botId}. Reason: {res.Error}");
                        }
                    }

                    loadingView.Close();
                    if (cancellationTokenSource.IsCancellationRequested)
                    {
                        _logger.LogInformation("Operation cancelled");
                        _mbs.ShowError("Operation cancelled!", "");
                    }
                    else
                    {
                        _mbs.ShowInformation("Delete finished. See output section for details.");
                    }

                    _logger.LogInformation("Refreshing Bots");
                    await RefreshBots();
                }
            }
        }

        private bool IsValid(List<int> ids)
        {
            if (!ids.Any())
            {
                _mbs.ShowInformation("No Bots selected");
                return false;
            }

            if (_bots.Where(x => ids.Contains(x.Id)).Any(x => x.Type != "Bot::SingleBot"))
            {
                _mbs.ShowError("Sorry, Bulk Edit only works for Simple Bots, not advanced.");
                return false;
            }

            return true;
        }

        public async Task OnRefresh()
        {
            await RefreshBots();
        }
    }
}
