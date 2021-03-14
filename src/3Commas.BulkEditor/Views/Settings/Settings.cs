using System;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;

namespace _3Commas.BulkEditor.Views.Settings
{
    public partial class Settings : Form
    {
        private bool _viewLoaded = false;

        public Settings(bool persistSettings, string title, XCommasAccounts accounts)
        {
            InitializeComponent();
            chkPersist.Checked = persistSettings;
            Text = title;

            Accounts = new BindingList<XCommasAccount>(accounts.Accounts);

            listBox.DataSource = Accounts;
            listBox.DisplayMember = nameof(XCommasAccount.Name);
            listBox.ValueMember = nameof(XCommasAccount.Id);

            _viewLoaded = true;
        }

        public BindingList<XCommasAccount> Accounts { get; set; }

        public bool PersistKeys => chkPersist.Checked;

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (PersistKeys)
            {
                ObjectContainer.KeyManager.Save(new XCommasAccounts() {Accounts = Accounts.ToList()});
            }
            else
            {
                ObjectContainer.KeyManager.Clear();
            }

            DialogResult = DialogResult.OK;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newAccount = new XCommasAccount();
            var settings = new AddAccountDialog("Add 3Commas Account", "Add", "Permissions Needed: BotsRead, BotsWrite, AccountsRead", newAccount);
            var dr = settings.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Accounts.Add(newAccount);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                ObjectContainer.MessageBoxService.ShowError("No Account selected.");
                return;
            }

            var account = listBox.SelectedItem as XCommasAccount;
            var settings = new AddAccountDialog("Edit 3Commas Account", "Apply", "Permissions Needed: BotsRead, BotsWrite, AccountsRead", account);
            var dr = settings.ShowDialog();
            if (dr == DialogResult.OK)
            {
                listBox.DataSource = null;
                listBox.DataSource = Accounts;
                listBox.DisplayMember = nameof(XCommasAccount.Name);
                listBox.ValueMember = nameof(XCommasAccount.Id);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                ObjectContainer.MessageBoxService.ShowError("No Account selected.");
                return;
            }

            var account = listBox.SelectedItem as XCommasAccount;
            var dr = ObjectContainer.MessageBoxService.ShowQuestion($"Are you sure to delete Account '{account.Name}' ?");
            if (dr == DialogResult.Yes)
            {
                Accounts.Remove(account);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
