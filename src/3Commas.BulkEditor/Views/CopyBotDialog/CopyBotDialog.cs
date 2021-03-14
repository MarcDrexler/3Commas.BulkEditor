using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using Microsoft.Extensions.Logging;

namespace _3Commas.BulkEditor.Views.CopyBotDialog
{
    public partial class CopyBotDialog : Form
    {
        private readonly XCommasAccounts _keys;
        private readonly ILogger _logger;
        private readonly IMessageBoxService _mbs = new MessageBoxService();

        public CopyBotDialog(XCommasAccounts keys, ILogger logger)
        {
            _keys = keys;
            _logger = logger;
            InitializeComponent();

            cmbIsEnabled.Items.Add("Same as original bot");
            cmbIsEnabled.Items.Add("Enabled");
            cmbIsEnabled.Items.Add("Disabled");
            cmbIsEnabled.SelectedIndex = 0;
        }

        public AccountViewModel Account { get; private set; }
        public bool? IsEnabled { get; set; }
        
        private async void ChooseAccount_Load(object sender, EventArgs e)
        {
            await BindAccountsAndSetSelection();
        }

        private async Task BindAccountsAndSetSelection()
        {
            var botMgr = new XCommasLayer(_keys, _logger);
            var accounts = await botMgr.RetrieveAccounts();
            cmbAccount.DataSource = accounts;
            cmbAccount.ValueMember = nameof(AccountViewModel.Id);
            cmbAccount.DisplayMember = nameof(AccountViewModel.Name);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Account = cmbAccount.SelectedItem as AccountViewModel;
                if (cmbIsEnabled.SelectedIndex == 0)
                {
                    IsEnabled = null;
                }
                else if (cmbIsEnabled.SelectedIndex == 1)
                {
                    IsEnabled = true;
                }
                else if (cmbIsEnabled.SelectedIndex == 2)
                {
                    IsEnabled = false;
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private bool IsValid()
        {
            var errors = new List<string>();

            if (cmbAccount.SelectedItem == null) errors.Add("No \"Account\" selected.");

            if (errors.Any())
            {
                _mbs.ShowError(String.Join(Environment.NewLine, errors), "Validation Error");
            }

            return !errors.Any();
        }
    }
}
