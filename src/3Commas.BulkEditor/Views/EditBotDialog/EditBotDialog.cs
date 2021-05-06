using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.EditBotDialog
{
    public partial class EditBotDialog : Form
    {
        private readonly int _botCount;
        private readonly XCommasLayer _manager;
        private readonly IMessageBoxService _mbs = new MessageBoxService();
        private readonly List<BotStrategy> _startConditions = new List<BotStrategy>();

        public EditBotDialog(int botCount, XCommasLayer manager)
        {
            _botCount = botCount;
            _manager = manager;
            InitializeComponent();

            cmbIsEnabled.DataBindings.Add(nameof(ComboBox.Visible), chkChangeIsEnabled, nameof(CheckBox.Checked));
            cmbPair.DataBindings.Add(nameof(ComboBox.Visible), chkChangePair, nameof(CheckBox.Checked));
            cmbProfitCurrency.DataBindings.Add(nameof(ComboBox.Visible), chkChangeProfitCurrency, nameof(CheckBox.Checked));
            lblPairWarning.DataBindings.Add(nameof(Label.Visible), chkChangePair, nameof(CheckBox.Checked));
            txtName.DataBindings.Add(nameof(TextBox.Visible), chkChangeName, nameof(CheckBox.Checked));
            numMaxActiveDeals.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeMaxActiveDeals, nameof(CheckBox.Checked));
            lblPreviewTitle.DataBindings.Add(nameof(Label.Visible), chkChangeName, nameof(CheckBox.Checked));
            lblNamePreview.DataBindings.Add(nameof(Label.Visible), chkChangeName, nameof(CheckBox.Checked));
            cmbStartOrderType.DataBindings.Add(nameof(ComboBox.Visible), chkChangeStartOrderType, nameof(CheckBox.Checked));
            numBaseOrderVolume.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeBaseOrderSize, nameof(CheckBox.Checked));
            cmbBaseOrderVolumeType.DataBindings.Add(nameof(ComboBox.Visible), chkChangeBaseOrderSizeType, nameof(CheckBox.Checked));
            numSafetyOrderVolume.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeSafetyOrderSize, nameof(CheckBox.Checked));
            cmbSafetyOrderVolumeType.DataBindings.Add(nameof(ComboBox.Visible), chkChangeSafetyOrderSizeType, nameof(CheckBox.Checked));
            numTargetProfit.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeTargetProfit, nameof(CheckBox.Checked));
            cmbTakeProfitType.DataBindings.Add(nameof(ComboBox.Visible), chkChangeTakeProfitType, nameof(CheckBox.Checked));
            cmbTtpEnabled.DataBindings.Add(nameof(ComboBox.Visible), chkChangeTrailingEnabled, nameof(CheckBox.Checked));
            numTrailingDeviation.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeTrailingDeviation, nameof(CheckBox.Checked));
            numMaxSafetyTradesCount.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeMaxSafetyTradesCount, nameof(CheckBox.Checked));
            numMaxActiveSafetyTradesCount.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeMaxActiveSafetyTradesCount, nameof(CheckBox.Checked));
            numPriceDeviationToOpenSafetyOrders.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangePriceDeviationToOpenSafetyOrders, nameof(CheckBox.Checked));
            numSafetyOrderVolumeScale.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeSafetyOrderVolumeScale, nameof(CheckBox.Checked));
            numSafetyOrderStepScale.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeSafetyOrderStepScale, nameof(CheckBox.Checked));
            numCooldownBetweenDeals.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeCooldownBetweenDeals, nameof(CheckBox.Checked));
            cmbDisableAfterDealsCount.DataBindings.Add(nameof(NumericUpDown.Visible), chkDisableAfterDealsCount, nameof(CheckBox.Checked));
            numDisableAfterDealsCount.DataBindings.Add(nameof(NumericUpDown.Visible), chkDisableAfterDealsCount, nameof(CheckBox.Checked));
            listViewStartConditions.DataBindings.Add(nameof(ListView.Visible), chkChangeDealStartCondition, nameof(CheckBox.Checked));
            btnAddStartCondition.DataBindings.Add(nameof(Button.Visible), chkChangeDealStartCondition, nameof(CheckBox.Checked));
            btnRemoveStartCondition.DataBindings.Add(nameof(Button.Visible), chkChangeDealStartCondition, nameof(CheckBox.Checked));
            lblStartConditionWarning.DataBindings.Add(nameof(Label.Visible), chkChangeDealStartCondition, nameof(CheckBox.Checked));
            numStopLossPercentage.DataBindings.Add(nameof(NumericUpDown.Visible), chkStopLossPercentage, nameof(CheckBox.Checked));
            cmbStopLossType.DataBindings.Add(nameof(ComboBox.Visible), chkStopLossType, nameof(CheckBox.Checked));
            cmbStopLossTimeoutEnabled.DataBindings.Add(nameof(ComboBox.Visible), chkStopLossTimeoutEnabled, nameof(CheckBox.Checked));
            numStopLossTimeout.DataBindings.Add(nameof(NumericUpDown.Visible), chkStopLossTimeout, nameof(CheckBox.Checked));
            cmbLeverageType.DataBindings.Add(nameof(ComboBox.Visible), chkChangeLeverageType, nameof(CheckBox.Checked));
            numLeverageCustomValue.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeCustomLeverageValue, nameof(CheckBox.Checked));
            numMaxPrice.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeMaxPrice, nameof(CheckBox.Checked));

            ControlHelper.AddValuesToCombobox<StartOrderType>(cmbStartOrderType);
            ControlHelper.AddValuesToCombobox<TakeProfitType>(cmbTakeProfitType);
            ControlHelper.AddValuesToCombobox<StopLossType>(cmbStopLossType);
            ControlHelper.AddValuesToCombobox<LeverageType>(cmbLeverageType);
            ControlHelper.AddValuesToCombobox<ProfitCurrency>(cmbProfitCurrency);
            cmbBaseOrderVolumeType.Items.Add(new ComboBoxItem(VolumeType.QuoteCurrency, "Quote"));
            cmbBaseOrderVolumeType.Items.Add(new ComboBoxItem(VolumeType.BaseCurrency, "Base"));
            cmbBaseOrderVolumeType.Items.Add(new ComboBoxItem(VolumeType.Percent, "% (Base)"));
            cmbSafetyOrderVolumeType.Items.Add(new ComboBoxItem(VolumeType.QuoteCurrency, "Quote"));
            cmbSafetyOrderVolumeType.Items.Add(new ComboBoxItem(VolumeType.BaseCurrency, "Base"));
            cmbSafetyOrderVolumeType.Items.Add(new ComboBoxItem(VolumeType.Percent, "% (Base)"));

            cmbPair.Items.AddRange(ObjectContainer.Cache.Pairs.ToArray());
            cmbIsEnabled.Items.Add("Enable");
            cmbIsEnabled.Items.Add("Disable");
            cmbTtpEnabled.Items.Add("Enable");
            cmbTtpEnabled.Items.Add("Disable");
            cmbDisableAfterDealsCount.Items.Add("Enable");
            cmbDisableAfterDealsCount.Items.Add("Disable");
            cmbStopLossTimeoutEnabled.Items.Add("Enable");
            cmbStopLossTimeoutEnabled.Items.Add("Disable");
        }

        public EditBotDto EditDto { get; set; } = new EditBotDto();

        public bool HasChanges => panel1.Controls.OfType<CheckBox>().Any(x => x.Checked);

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!HasChanges)
            {
                _mbs.ShowInformation("No changes to save.");
                return;
            }

            if (IsValid())
            {
                var dr = _mbs.ShowQuestion($"Save these settings to {_botCount} bots now?");
                if (dr == DialogResult.Yes)
                {
                    if (chkChangeIsEnabled.Checked)
                    {
                        if (cmbIsEnabled.SelectedItem.ToString() == "Enable") EditDto.IsEnabled = true;
                        else if (cmbIsEnabled.SelectedItem.ToString() == "Disable") EditDto.IsEnabled = false;
                    }
                    
                    if (chkChangePair.Checked) EditDto.Pair = cmbPair.SelectedItem.ToString();
                    if (chkChangeMaxActiveDeals.Checked) EditDto.MaxActiveDeals = (int)numMaxActiveDeals.Value;

                    if (chkChangeProfitCurrency.Checked)
                    {
                        Enum.TryParse(cmbProfitCurrency.SelectedItem.ToString(), out ProfitCurrency profitCurrency);
                        EditDto.ProfitCurrency = profitCurrency;
                    }

                    if (chkChangeStartOrderType.Checked)
                    {
                        Enum.TryParse(cmbStartOrderType.SelectedItem.ToString(), out StartOrderType startOrderType);
                        EditDto.StartOrderType = startOrderType;
                    }
                    if (chkChangeBaseOrderSize.Checked) EditDto.BaseOrderVolume = numBaseOrderVolume.Value;
                    if (chkChangeBaseOrderSizeType.Checked)
                    {
                        EditDto.BaseOrderVolumeType = (VolumeType?) ((ComboBoxItem)cmbBaseOrderVolumeType.SelectedItem).EnumValue;
                    }
                    if (chkChangeName.Checked) EditDto.Name = txtName.Text;
                    if (chkChangeSafetyOrderSize.Checked) EditDto.SafetyOrderVolume = numSafetyOrderVolume.Value;
                    if (chkChangeSafetyOrderSizeType.Checked)
                    {
                        EditDto.SafetyOrderVolumeType = (VolumeType?)((ComboBoxItem)cmbSafetyOrderVolumeType.SelectedItem).EnumValue;
                    }
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
                    if (chkChangePriceDeviationToOpenSafetyOrders.Checked) EditDto.SafetyOrderStepPercentage = numPriceDeviationToOpenSafetyOrders.Value;
                    if (chkChangeSafetyOrderVolumeScale.Checked) EditDto.MartingaleVolumeCoefficient = numSafetyOrderVolumeScale.Value;
                    if (chkChangeSafetyOrderStepScale.Checked) EditDto.MartingaleStepCoefficient = numSafetyOrderStepScale.Value;
                    if (chkChangeCooldownBetweenDeals.Checked) EditDto.Cooldown = (int)numCooldownBetweenDeals.Value;
                    if (chkChangeDealStartCondition.Checked) EditDto.DealStartConditions = _startConditions;
                    if (chkChangeMaxPrice.Checked) EditDto.MaxPrice = numMaxPrice.Value;
                    if (chkStopLossPercentage.Checked) EditDto.StopLossPercentage = numStopLossPercentage.Value;
                    if (chkChangeLeverageType.Checked)
                    {
                        Enum.TryParse(cmbLeverageType.SelectedItem.ToString(), out LeverageType leverageType);
                        EditDto.LeverageType = leverageType;
                    }
                    if (chkChangeCustomLeverageValue.Checked) EditDto.LeverageCustomValue = numLeverageCustomValue.Value;
                    if (chkStopLossType.Checked)
                    {
                        Enum.TryParse(cmbStopLossType.SelectedItem.ToString(), out StopLossType stopLossType);
                        EditDto.StopLossType = stopLossType;
                    }
                    if (chkStopLossTimeoutEnabled.Checked) EditDto.StopLossTimeoutEnabled = cmbStopLossTimeoutEnabled.SelectedItem.ToString() == "Enable" ? true : false;
                    if (chkStopLossTimeout.Checked) EditDto.StopLossTimeout = (int)numStopLossTimeout.Value;

                    if (chkDisableAfterDealsCount.Checked)
                    {
                        EditDto.DisableAfterDealsCountInfo = new DisableAfterDealsCountDto();
                        if (cmbDisableAfterDealsCount.SelectedItem.ToString() == "Enable")
                        {
                            EditDto.DisableAfterDealsCountInfo.Enable = true;
                            EditDto.DisableAfterDealsCountInfo.Value = (int) numDisableAfterDealsCount.Value;
                        }
                    }

                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool IsValid()
        {
            var errors = new List<string>();

            if (chkChangePair.Checked && cmbPair.SelectedItem == null) errors.Add("New value for \"Pair\" missing.");
            if (chkChangeIsEnabled.Checked && cmbIsEnabled.SelectedItem == null) errors.Add("New value for \"Enabled\" missing.");
            if (chkChangeName.Checked && string.IsNullOrWhiteSpace(txtName.Text)) errors.Add("New value for \"Name\" missing.");
            if (chkChangeProfitCurrency.Checked && cmbProfitCurrency.SelectedItem == null) errors.Add("New value for \"Profit Currency\" missing.");
            if (chkChangeTakeProfitType.Checked && cmbTakeProfitType.SelectedItem == null) errors.Add("New value for \"Take Profit Type\" missing.");
            if (chkChangeStartOrderType.Checked && cmbStartOrderType.SelectedItem == null) errors.Add("New value for \"Start Order Type\" missing.");
            if (chkChangeBaseOrderSizeType.Checked && cmbBaseOrderVolumeType.SelectedItem == null) errors.Add("New value for \"Base Order Type\" missing.");
            if (chkChangeSafetyOrderSizeType.Checked && cmbSafetyOrderVolumeType.SelectedItem == null) errors.Add("New value for \"Safety Order Type\" missing.");
            if (chkChangeBaseOrderSize.Checked && numBaseOrderVolume.Value == 0) errors.Add("New value for \"Base order size\" missing.");
            if (chkChangeSafetyOrderSize.Checked && numSafetyOrderVolume.Value == 0) errors.Add("New value for \"Safety order size\" missing.");
            if (chkChangeTrailingEnabled.Checked && cmbTtpEnabled.SelectedItem == null) errors.Add("New value for \"TTP Enabled\" missing.");
            if (chkDisableAfterDealsCount.Checked && cmbDisableAfterDealsCount.SelectedItem == null) errors.Add("New value for \"Open deals & stop\" missing.");
            if (chkChangeDealStartCondition.Checked && !_startConditions.Any()) errors.Add("New value for \"Deal Start Condition\" missing.");
            if (chkChangeLeverageType.Checked && cmbLeverageType.SelectedItem == null) errors.Add("New value for \"Leverage Type\" missing.");

            if (errors.Any())
            {
                _mbs.ShowError(String.Join(Environment.NewLine, errors), "Validation Error");
            }

            return !errors.Any();
        }
         
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lblNamePreview.Text = XCommasLayer.GenerateNewName(txtName.Text, "Long", new[] {"USDT_BTC"}, "AccountName");
        }

        private void cmbDisableAfterDealsCount_SelectedValueChanged(object sender, EventArgs e)
        {
            numDisableAfterDealsCount.Enabled = cmbDisableAfterDealsCount.SelectedItem?.ToString() == "Enable";
        }

        private void btnAddStartCondition_Click(object sender, EventArgs e)
        {
            ChooseSignal.ChooseSignal form = new ChooseSignal.ChooseSignal(_manager);
            var dr = form.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                _startConditions.Add(form.Strategy);
                RefreshStartConditions(_startConditions);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (string hash in SelectedStartConditions)
            {
                _startConditions.RemoveAll(x => x.GetHashCode().ToString() == hash);
            }
            RefreshStartConditions(_startConditions);
        }

        public void RefreshStartConditions(List<BotStrategy> startConditions)
        {
            listViewStartConditions.Clear();

            foreach (var startCondition in startConditions)
            {
                listViewStartConditions.Items.Add(new ListViewItem() { Tag = startCondition, Text = startCondition.ToHumanReadableString(), Name = startCondition.GetHashCode().ToString() });
            }
        }

        public List<string> SelectedStartConditions => listViewStartConditions.SelectedItems.Cast<ListViewItem>().Select(selectedItem => selectedItem.Name).ToList();
    }
}
