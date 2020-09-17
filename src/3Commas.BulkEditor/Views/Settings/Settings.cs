using System;
using System.Configuration;
using System.Windows.Forms;

namespace _3Commas.BulkEditor.Views.Settings
{
    public partial class Settings : Form
    {
        private bool _viewLoaded = false;

        public Settings(bool persistSettings, string title, string permissionsNeeded, string apiKey, string secret)
        {
            InitializeComponent();
            chkPersist.Checked = persistSettings;
            Text = title;
            lblPermissionsNeeded.Text = permissionsNeeded;

            ApiKey = apiKey;
            Secret = secret;
            txtBinanceApiKey.Text = apiKey;
            txtBinanceSecret.Text = secret;

            _viewLoaded = true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApiKey = txtBinanceApiKey.Text;
            Secret = txtBinanceSecret.Text;

            DialogResult = DialogResult.OK;
        }

        public string ApiKey { get; set; } 
    
        public string Secret { get; set; }

        public bool PersistKeys => chkPersist.Checked;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkPersist_CheckedChanged(object sender, EventArgs e)
        {
            if (_viewLoaded && chkPersist.Checked)
            {
                MessageBox.Show("Your keys will be persisted in your user directory. Be aware that other programs may potentially have access to it. In addition, after an application update, the configuration files of previous versions may still exist. Only an uninstallation will delete all configuration data." + Environment.NewLine + Environment.NewLine +
                                "Settings location: " + System.IO.Path.GetDirectoryName(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
