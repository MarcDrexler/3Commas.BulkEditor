using System;
using System.Windows.Forms;
using _3Commas.BulkEditor.Misc;

namespace _3Commas.BulkEditor.Views.Settings
{
    public partial class AddAccountDialog : Form
    {
        private readonly XCommasAccount _account;

        public AddAccountDialog(string title, string buttonAction, string permissionsNeeded, XCommasAccount account)
        {
            _account = account;
            InitializeComponent();
            
            Text = title;
            btnApply.Text = buttonAction;
            lblPermissionsNeeded.Text = permissionsNeeded;

            txtDescription.Text = _account.Name;
            txtBinanceApiKey.Text = _account.ApiKey;
            txtBinanceSecret.Text = _account.Secret;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            _account.Name = txtDescription.Text;
            _account.ApiKey = txtBinanceApiKey.Text;
            _account.Secret = txtBinanceSecret.Text;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
