using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using _3Commas.BulkEditor.Views.EditDialog;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views
{
    public partial class ProgressView : Form
    {
        private readonly List<Bot> _bots;
        private readonly EditDto _newSettings;
        private readonly Misc.Keys _keys;
        private readonly ILogger _logger;
        private bool _cancelled;
        private MessageBoxService _mbs;

        public ProgressView(List<Bot> bots, EditDto newSettings, Misc.Keys keys, ILogger logger)
        {
            _bots = bots;
            _newSettings = newSettings;
            _keys = keys;
            _logger = logger;
            _mbs = new MessageBoxService();
            InitializeComponent();
        }

        private async void LoadingView_Load(object sender, EventArgs e)
        {
            var botMgr = new BotManager(_keys, _logger);
            progressBar.Maximum = _bots.Count;

            int i = 0;
            foreach (var bot in _bots)
            {
                i++;
                progressBar.Value = i;
                decimal percentage = ((decimal)i / _bots.Count) * 100;
                lblPercentage.Text = $"{(int)percentage} %";

                if (_cancelled)
                {
                    lblProgress.Text = "Operation has been cancelled.";
                    progressBar.Enabled = false;
                    btnCancel.Visible = false;
                    btnClose.Visible = true;
                    _mbs.ShowError("Operation cancelled!", "");
                    return;
                }

                if (_newSettings.IsEnabled.HasValue)
                {
                    if (_newSettings.IsEnabled.Value)
                    {
                        await botMgr.Enable(bot.Id);
                    }
                    else
                    {
                        await botMgr.Disable(bot.Id);
                    }
                }

                var updateData = new BotUpdateData(bot);
                if (_newSettings.ActiveSafetyOrdersCount.HasValue) updateData.ActiveSafetyOrdersCount = _newSettings.ActiveSafetyOrdersCount.Value;
                if (_newSettings.BaseOrderVolume.HasValue) updateData.BaseOrderVolume = _newSettings.BaseOrderVolume.Value;
                if (_newSettings.Cooldown.HasValue) updateData.Cooldown = _newSettings.Cooldown.Value;
                if (_newSettings.MartingaleStepCoefficient.HasValue) updateData.MartingaleStepCoefficient = _newSettings.MartingaleStepCoefficient.Value;
                if (_newSettings.MartingaleVolumeCoefficient.HasValue) updateData.MartingaleVolumeCoefficient = _newSettings.MartingaleVolumeCoefficient.Value;
                if (_newSettings.MaxSafetyOrders.HasValue) updateData.MaxSafetyOrders = _newSettings.MaxSafetyOrders.Value;
                if (!string.IsNullOrWhiteSpace(_newSettings.Name)) updateData.Name = BotManager.GenerateNewName(_newSettings.Name, bot.Strategy.ToString(), bot.Pairs.Single());
                if (_newSettings.SafetyOrderStepPercentage.HasValue) updateData.SafetyOrderStepPercentage = _newSettings.SafetyOrderStepPercentage.Value;
                if (_newSettings.StartOrderType.HasValue) updateData.StartOrderType = _newSettings.StartOrderType.Value;
                if (_newSettings.SafetyOrderVolume.HasValue) updateData.SafetyOrderVolume = _newSettings.SafetyOrderVolume.Value;
                if (_newSettings.TakeProfit.HasValue) updateData.TakeProfit = _newSettings.TakeProfit.Value;
                if (_newSettings.TrailingDeviation.HasValue) updateData.TrailingDeviation = _newSettings.TrailingDeviation.Value;
                if (_newSettings.TrailingEnabled.HasValue) updateData.TrailingEnabled = _newSettings.TrailingEnabled.Value;
                if (_newSettings.BaseOrderVolumeType.HasValue) updateData.BaseOrderVolumeType = _newSettings.BaseOrderVolumeType.Value; 
                if (_newSettings.SafetyOrderVolumeType.HasValue) updateData.SafetyOrderVolumeType = _newSettings.SafetyOrderVolumeType.Value;
                if (_newSettings.StopLossPercentage.HasValue) updateData.StopLossPercentage = _newSettings.StopLossPercentage.Value;
                if (_newSettings.StopLossType.HasValue) updateData.StopLossType = _newSettings.StopLossType.Value;
                if (_newSettings.StopLossTimeoutEnabled.HasValue) updateData.StopLossTimeoutEnabled = _newSettings.StopLossTimeoutEnabled.Value;
                if (_newSettings.StopLossTimeout.HasValue) updateData.StopLossTimeoutInSeconds = _newSettings.StopLossTimeout.Value;
                if (_newSettings.LeverageType.HasValue) updateData.LeverageType = _newSettings.LeverageType.Value;
                if (_newSettings.LeverageCustomValue.HasValue) updateData.LeverageCustomValue = _newSettings.LeverageCustomValue.Value;

                if (_newSettings.DisableAfterDealsCountInfo != null)
                {
                    if (_newSettings.DisableAfterDealsCountInfo.Enable)
                    {
                        updateData.DisableAfterDealsCount = _newSettings.DisableAfterDealsCountInfo.Value;
                    }
                    else
                    {
                        updateData.DisableAfterDealsCount = null;
                    }
                }

                if (_newSettings.DealStartConditions.Any())
                {
                    updateData.Strategies.Clear();
                    updateData.Strategies.AddRange(_newSettings.DealStartConditions);
                }

                var res = await botMgr.SaveBot(bot.Id, updateData);
                if (res.IsSuccess)
                {
                    _logger.LogInformation($"Bot {bot.Id} updated");
                }
                else
                {
                    _logger.LogError($"Could not update Bot {bot.Id}. Reason: {res.Error}");
                }
            }

            _mbs.ShowInformation("Bulk Edit finished. See output section for details.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _cancelled = true;
        }
    }
}
