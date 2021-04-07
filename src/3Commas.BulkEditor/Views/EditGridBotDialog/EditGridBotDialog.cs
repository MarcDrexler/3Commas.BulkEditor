using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;

namespace _3Commas.BulkEditor.Views.EditGridBotDialog
{
    public partial class EditGridBotDialog : Form
    {
        private readonly int _botCount;
        private readonly XCommasLayer _manager;
        private readonly IMessageBoxService _mbs = new MessageBoxService();

        public EditGridBotDialog(int botCount, XCommasLayer manager)
        {
            _botCount = botCount;
            _manager = manager;
            InitializeComponent();

            cmbIsEnabled.DataBindings.Add(nameof(ComboBox.Visible), chkChangeIsEnabled, nameof(CheckBox.Checked));
            numUpperLimit.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeUpperLimit, nameof(CheckBox.Checked));
            numLowerLimit.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeLowerLimit, nameof(CheckBox.Checked));
            numGridQuantity.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeGridQuantity, nameof(CheckBox.Checked));
            numQuantityPerGrid.DataBindings.Add(nameof(NumericUpDown.Visible), chkChangeQuantityPerGrid, nameof(CheckBox.Checked));
            
            cmbIsEnabled.Items.Add("Enable");
            cmbIsEnabled.Items.Add("Disable");
        }

        public EditGridBotDto EditDto { get; set; } = new EditGridBotDto();

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
                    
                    if (chkChangeLowerLimit.Checked) EditDto.LowerLimitPrice = numLowerLimit.Value;
                    if (chkChangeUpperLimit.Checked) EditDto.UpperLimitPrice = numUpperLimit.Value;
                    if (chkChangeQuantityPerGrid.Checked) EditDto.QuantityPerGrid = numQuantityPerGrid.Value;
                    if (chkChangeGridQuantity.Checked) EditDto.GridsQuantity = Convert.ToInt32(numGridQuantity.Value);

                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool IsValid()
        {
            var errors = new List<string>();

            if (chkChangeIsEnabled.Checked && cmbIsEnabled.SelectedItem == null) errors.Add("New value for \"Enabled\" missing.");
            if (chkChangeUpperLimit.Checked && numUpperLimit.Value == 0) errors.Add("New value for \"Upper Limit Price\" missing.");
            if (chkChangeLowerLimit.Checked && numLowerLimit.Value == 0) errors.Add("New value for \"Lower Limit Price\" missing.");
            if (chkChangeQuantityPerGrid.Checked && numQuantityPerGrid.Value == 0) errors.Add("New value for \"Quantity per Grid\" missing.");
            if (chkChangeGridQuantity.Checked && numGridQuantity.Value == 0) errors.Add("New value for \"Grid Quantity\" missing.");
            
            if (errors.Any())
            {
                _mbs.ShowError(String.Join(Environment.NewLine, errors), "Validation Error");
            }

            return !errors.Any();
        }
    }
}
