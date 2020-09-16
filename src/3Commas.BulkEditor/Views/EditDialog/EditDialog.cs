using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.EditDialog
{
    public partial class EditDialog : Form
    {
        private readonly List<Bot> _botsToEdit;
        private readonly Misc.Keys _keys;
        private readonly ILogger _logger;
        private readonly IMessageBoxService _mbs = new MessageBoxService();

        public EditDialog(List<Bot> botsToEdit, Misc.Keys keys, ILogger logger)
        {
            _botsToEdit = botsToEdit;
            _keys = keys;
            _logger = logger;
            InitializeComponent();

            cmbIsEnabled.DataBindings.Add(nameof(ComboBox.Visible), chkChangeIsEnabled, nameof(CheckBox.Checked));
            cmbStartOrderType.DataBindings.Add(nameof(ComboBox.Visible), chkChangeStartOrderType, nameof(CheckBox.Checked));
            numBaseOrderVolume.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeBaseOrderSize, nameof(CheckBox.Checked));
            numSafetyOrderVolume.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeSafetyOrderSize, nameof(CheckBox.Checked));
            numTargetProfit.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeTargetProfit, nameof(CheckBox.Checked));
            cmbTtpEnabled.DataBindings.Add(nameof(ComboBox.Visible), chkChangeTrailingEnabled, nameof(CheckBox.Checked));
            numTrailingDeviation.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeTrailingDeviation, nameof(CheckBox.Checked));
            numMaxSafetyTradesCount.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeMaxSafetyTradesCount, nameof(CheckBox.Checked));
            numMaxActiveSafetyTradesCount.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeMaxActiveSafetyTradesCount, nameof(CheckBox.Checked));
            numPriceDeviationToOpenSafetyOrders.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangePriceDeviationToOpenSafetyOrders, nameof(CheckBox.Checked));
            numSafetyOrderVolumeScale.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeSafetyOrderVolumeScale, nameof(CheckBox.Checked));
            numSafetyOrderStepScale.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeSafetyOrderStepScale, nameof(CheckBox.Checked));
            numCooldownBetweenDeals.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeCooldownBetweenDeals, nameof(CheckBox.Checked));

            ControlHelper.AddValuesToCombobox<StartOrderType>(cmbStartOrderType);
            cmbIsEnabled.Items.Add("Enabled");
            cmbIsEnabled.Items.Add("Disabled");
            cmbTtpEnabled.Items.Add("Enabled");
            cmbTtpEnabled.Items.Add("Disabled");
        }

        public bool HasChanges => Controls.OfType<CheckBox>().Any(x => x.Checked);

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (!HasChanges)
            {
                _mbs.ShowInformation("No changes to save.");
                return;
            }

            if (IsValid())
            {
                var dr = _mbs.ShowQuestion($"Save these settings to {_botsToEdit.Count} bots now?");
                if (dr == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    var botMgr = new BotManager(_keys, _logger);

                    foreach (var bot in _botsToEdit)
                    {
                        var updateData = new BotUpdateData(bot);
                        if (chkChangeIsEnabled.Checked)
                        {
                            switch (cmbIsEnabled.SelectedItem.ToString())
                            {
                                case "Enabled":
                                    var aRes = await botMgr.Enable(bot.Id);
                                    if (aRes.IsSuccess)
                                    {
                                        _logger.LogInformation($"Bot {bot.Id} enabled");
                                    }
                                    else
                                    {
                                        _logger.LogError($"Could not enable Bot {bot.Id}. Reason: {aRes.Error}");
                                    }

                                    break;
                                case "Disabled":
                                    var dRes = await botMgr.Disable(bot.Id);
                                    if (dRes.IsSuccess)
                                    {
                                        _logger.LogInformation($"Bot {bot.Id} disabled");
                                    }
                                    else
                                    {
                                        _logger.LogError($"Could not disable Bot {bot.Id}. Reason: {dRes.Error}");
                                    }

                                    break;
                            }
                        }

                        if (chkChangeStartOrderType.Checked)
                        {
                            Enum.TryParse(cmbStartOrderType.SelectedItem.ToString(),  out StartOrderType startOrderType);
                            updateData.StartOrderType = startOrderType;
                        }
                        if (chkChangeBaseOrderSize.Checked) updateData.BaseOrderVolume = numBaseOrderVolume.Value;
                        if (chkChangeSafetyOrderSize.Checked) updateData.SafetyOrderVolume = numSafetyOrderVolume.Value;
                        if (chkChangeTargetProfit.Checked) updateData.TakeProfit = numTargetProfit.Value;
                        if (chkChangeTrailingEnabled.Checked) updateData.TrailingEnabled = (cmbTtpEnabled.SelectedItem.ToString() == "Enabled") ? true : false;
                        if (chkChangeTrailingDeviation.Checked) updateData.TrailingDeviation = numTrailingDeviation.Value;
                        if (chkChangeMaxSafetyTradesCount.Checked) updateData.MaxSafetyOrders = (int)numMaxSafetyTradesCount.Value;
                        if (chkChangeMaxActiveSafetyTradesCount.Checked) updateData.ActiveSafetyOrdersCount = (int)numMaxActiveSafetyTradesCount.Value;
                        if (chkChangePriceDeviationToOpenSafetyOrders.Checked) updateData.SafetyOrderStepPercentage = numPriceDeviationToOpenSafetyOrders.Value;
                        if (chkChangeSafetyOrderVolumeScale.Checked) updateData.MartingaleVolumeCoefficient = numSafetyOrderVolumeScale.Value;
                        if (chkChangeSafetyOrderStepScale.Checked) updateData.MartingaleStepCoefficient = numSafetyOrderStepScale.Value;
                        if (chkChangeCooldownBetweenDeals.Checked) updateData.Cooldown = (int)numCooldownBetweenDeals.Value;
                        
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

                    Cursor.Current = Cursors.Default;

                    _mbs.ShowInformation("Bulk Edit finished. See output section for details.");
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool IsValid()
        {
            var errors = new List<string>();

            if (chkChangeIsEnabled.Checked && cmbIsEnabled.SelectedItem == null) errors.Add("New value for \"Enabled\" missing.");
            if (chkChangeStartOrderType.Checked && cmbStartOrderType.SelectedItem == null) errors.Add("New value for \"Start Order Type\" missing.");
            if (chkChangeBaseOrderSize.Checked && numBaseOrderVolume.Value == 0) errors.Add("New value for \"Base order size\" missing.");
            if (chkChangeSafetyOrderSize.Checked && numSafetyOrderVolume.Value == 0) errors.Add("New value for \"Safety order size\" missing.");
            if (chkChangeTrailingEnabled.Checked && cmbTtpEnabled.SelectedItem == null) errors.Add("New value for \"TTP Enabled\" missing.");

            if (errors.Any())
            {
                _mbs.ShowError(String.Join(Environment.NewLine, errors), "Validation Error");
            }

            return !errors.Any();
        }
    }
}
