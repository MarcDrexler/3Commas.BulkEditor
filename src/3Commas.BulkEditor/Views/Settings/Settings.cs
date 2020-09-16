using System;
using System.Windows.Forms;

namespace _3Commas.BulkEditor.Views.Settings
{
    public partial class Settings : Form
    {
        public Settings(string title, string permissionsNeeded, string apiKey, string secret)
        {
            InitializeComponent();
            Text = title;
            lblPermissionsNeeded.Text = permissionsNeeded;

            ApiKey = apiKey;
            Secret = secret;
            txtBinanceApiKey.Text = apiKey;
            txtBinanceSecret.Text = secret;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApiKey = txtBinanceApiKey.Text;
            Secret = txtBinanceSecret.Text;
            DialogResult = DialogResult.OK;
        }

        public string ApiKey { get; set; } 
    
        public string Secret { get; set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
