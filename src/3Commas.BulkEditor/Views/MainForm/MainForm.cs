using System;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using Microsoft.Extensions.Logging;

namespace _3Commas.BulkEditor.Views.MainForm
{
    public sealed partial class MainForm : Form, IMainForm
    {
        private readonly MainFormPresenter _presenter;

        public MainForm()
        {
            InitializeComponent();

            Text = $"{AssemblyHelper.AssemblyTitle} {AssemblyHelper.AssemblyVersion}";

            ObjectContainer.Logger = new TextBoxLogger(txtOutput);

            _presenter = new MainFormPresenter(this, ObjectContainer.Logger, ObjectContainer.MessageBoxService, ObjectContainer.EventBroker);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await _presenter.OnViewReady();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _presenter.OnClear();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox.AboutBox box = new AboutBox.AboutBox();
            box.ShowDialog(this);
        }
        
        public void ClearLog()
        {
            txtOutput.Clear();
        }

        public void InitGrids(XCommasAccounts keys, ILogger logger, IMessageBoxService mbs)
        {
            manageBotControl.Init(keys, logger, mbs);
            manageDealControl.Init(keys, logger, mbs);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NotifyCurrentTab();
        }

        public void SetAccountCount(int numberOfAccounts)
        {
            lblAccountsLoaded.Text = $"3Commas Accounts loaded: {numberOfAccounts}";
        }

        public void SetExchangeCount(int numberOfExchanges)
        {
            lblExchangesLoaded.Text = $"Total Exchanges loaded: {numberOfExchanges}";
        }

        public void EnablePanicButton()
        {
            btnStopAllBots.Enabled = true;
        }

        private void NotifyCurrentTab()
        {
            // Workaround:
            // we can only set the datasource if the grid is really visible to the user. Otherwise this gridview will throw an exception while binding the data :/
            if (tabControl1.SelectedTab.Text == "Bots")
            {
                manageBotControl.SetDataSource();
            }
            else
            {
                manageDealControl.SetDataSource();
            }
        }

        private void btnStopAllBots_Click(object sender, EventArgs e)
        {
            _presenter.OnStopAllBots();
        }

        private void btnManageApiKeys_Click(object sender, EventArgs e)
        {
            _presenter.OnManageApiKeys();
        }
    }
}
