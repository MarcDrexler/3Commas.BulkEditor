using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using _3Commas.BulkEditor.Views.EditDealDialog;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.AddFundsDialog
{
    public partial class AddFundsDialog : Form
    {
        private readonly IMessageBoxService _mbs = new MessageBoxService();

        public AddFundsDialog()
        {
            InitializeComponent();
        }

        public AddFundsDto EditDto { get; set; } = new AddFundsDto();

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (radioBtc.Checked) EditDto.QtyInBTC = (decimal)numQtyBtc.Value;
                if (radioUsdt.Checked) EditDto.QtyInUSD = (decimal)numQtyUsdt.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool IsValid()
        {
            var errors = new List<string>();

            if (radioBtc.Checked && numQtyBtc.Value < 0) errors.Add("Amount in BTC missing.");
            if (radioUsdt.Checked && numQtyUsdt.Value < 0) errors.Add("Amount in USD missing.");
            
            if (errors.Any())
            {
                _mbs.ShowError(String.Join(Environment.NewLine, errors), "Validation Error");
            }

            return !errors.Any();
        }

        private void radioUsdt_CheckedChanged(object sender, EventArgs e)
        {
            lblUsdt.Visible = sender == radioUsdt && radioUsdt.Checked;
            numQtyUsdt.Visible = sender == radioUsdt && radioUsdt.Checked;
            lblBtc.Visible = sender == radioBtc && radioBtc.Checked;
            numQtyBtc.Visible = sender == radioBtc && radioBtc.Checked;
        }
    }
}
