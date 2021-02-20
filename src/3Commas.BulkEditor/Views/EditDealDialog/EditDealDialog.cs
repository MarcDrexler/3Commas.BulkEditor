using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.EditDealDialog
{
    public partial class EditDealDialog : Form
    {
        private readonly int _dealCount;
        private readonly XCommasLayer _manager;
        private readonly IMessageBoxService _mbs = new MessageBoxService();
        private readonly List<BotStrategy> _startConditions = new List<BotStrategy>();

        public EditDealDialog(int dealCount, XCommasLayer manager)
        {
            _dealCount = dealCount;
            _manager = manager;
            InitializeComponent();

            numTargetProfit.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeTargetProfit, nameof(CheckBox.Checked));
            cmbTakeProfitType.DataBindings.Add(nameof(ComboBox.Visible), chkChangeTakeProfitType, nameof(CheckBox.Checked));
            cmbTtpEnabled.DataBindings.Add(nameof(ComboBox.Visible), chkChangeTrailingEnabled, nameof(CheckBox.Checked));
            numTrailingDeviation.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeTrailingDeviation, nameof(CheckBox.Checked));
            numMaxSafetyTradesCount.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeMaxSafetyTradesCount, nameof(CheckBox.Checked));
            numMaxActiveSafetyTradesCount.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeMaxActiveSafetyTradesCount, nameof(CheckBox.Checked));
            numStopLossPercentage.DataBindings.Add(nameof(NumericUpDown.Visible), chkStopLossPercentage, nameof(CheckBox.Checked));
            cmbStopLossType.DataBindings.Add(nameof(ComboBox.Visible), chkStopLossType, nameof(CheckBox.Checked));
            cmbStopLossTimeoutEnabled.DataBindings.Add(nameof(ComboBox.Visible), chkStopLossTimeoutEnabled, nameof(CheckBox.Checked));
            numStopLossTimeout.DataBindings.Add(nameof(NumericUpDown.Visible), chkStopLossTimeout, nameof(CheckBox.Checked));

            ControlHelper.AddValuesToCombobox<TakeProfitType>(cmbTakeProfitType);
            ControlHelper.AddValuesToCombobox<StopLossType>(cmbStopLossType);

            cmbTtpEnabled.Items.Add("Enable");
            cmbTtpEnabled.Items.Add("Disable");
            cmbStopLossTimeoutEnabled.Items.Add("Enable");
            cmbStopLossTimeoutEnabled.Items.Add("Disable");
        }

        public EditDealDto EditDto { get; set; } = new EditDealDto();

        public bool HasChanges => Controls.OfType<CheckBox>().Any(x => x.Checked);

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!HasChanges)
            {
                _mbs.ShowInformation("No changes to save.");
                return;
            }

            if (IsValid())
            {
                if (chkChangeTargetProfit.Checked) EditDto.TakeProfit = numTargetProfit.Value;
                if (chkChangeTakeProfitType.Checked)
                {
                    Enum.TryParse(cmbTakeProfitType.SelectedItem.ToString(), out TakeProfitType takeProfitType);
                    EditDto.TakeProfitType = takeProfitType;
                }
                if (chkChangeTrailingEnabled.Checked) EditDto.TrailingEnabled = cmbTtpEnabled.SelectedItem.ToString() == "Enable" ? true : false;
                if (chkChangeTrailingDeviation.Checked) EditDto.TrailingDeviation = numTrailingDeviation.Value;
                if (chkChangeMaxSafetyTradesCount.Checked) EditDto.MaxSafetyOrders = (int)numMaxSafetyTradesCount.Value;
                if (chkChangeMaxActiveSafetyTradesCount.Checked) EditDto.ActiveSafetyOrdersCount = (int)numMaxActiveSafetyTradesCount.Value;
                if (chkStopLossPercentage.Checked) EditDto.StopLossPercentage = numStopLossPercentage.Value;
                if (chkStopLossType.Checked)
                {
                    Enum.TryParse(cmbStopLossType.SelectedItem.ToString(), out StopLossType stopLossType);
                    EditDto.StopLossType = stopLossType;
                }
                if (chkStopLossTimeoutEnabled.Checked) EditDto.StopLossTimeoutEnabled = cmbStopLossTimeoutEnabled.SelectedItem.ToString() == "Enable" ? true : false;
                if (chkStopLossTimeout.Checked) EditDto.StopLossTimeout = (int)numStopLossTimeout.Value;

                this.DialogResult = DialogResult.OK;
            }
        }

        private bool IsValid()
        {
            var errors = new List<string>();

            if (chkChangeTakeProfitType.Checked && cmbTakeProfitType.SelectedItem == null) errors.Add("New value for \"Take Profit Type\" missing.");
            if (chkChangeTrailingEnabled.Checked && cmbTtpEnabled.SelectedItem == null) errors.Add("New value for \"TTP Enabled\" missing.");

            if (errors.Any())
            {
                _mbs.ShowError(String.Join(Environment.NewLine, errors), "Validation Error");
            }

            return !errors.Any();
        }
    }
}
