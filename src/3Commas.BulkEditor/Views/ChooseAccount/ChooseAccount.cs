using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;
using Keys = _3Commas.BulkEditor.Misc.Keys;

namespace _3Commas.BulkEditor.Views.ChooseAccount
{
    public partial class ChooseAccount : Form
    {
        private readonly Keys _keys;
        private readonly ILogger _logger;
        private readonly IMessageBoxService _mbs = new MessageBoxService();

        public ChooseAccount(Keys keys, ILogger logger)
        {
            _keys = keys;
            _logger = logger;
            InitializeComponent();
        }

        public Account Account { get; private set; }
        
        private async void ChooseAccount_Load(object sender, EventArgs e)
        {
            await BindAccountsAndSetSelection();
        }

        private async Task BindAccountsAndSetSelection()
        {
            var botMgr = new XCommasLayer(_keys, _logger);
            var accounts = await botMgr.RetrieveAccounts();
            cmbAccount.DataSource = accounts;
            cmbAccount.ValueMember = nameof(Account.Id);
            cmbAccount.DisplayMember = nameof(Account.Name);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Account = cmbAccount.SelectedItem as Account;

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
