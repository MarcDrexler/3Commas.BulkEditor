using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using Microsoft.Extensions.Logging;
using Keys = _3Commas.BulkEditor.Misc.Keys;

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

            _presenter = new MainFormPresenter(this, ObjectContainer.Logger, ObjectContainer.MessageBoxService);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await _presenter.OnViewReady();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _presenter.OnClearClick();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox.AboutBox box = new AboutBox.AboutBox();
            box.ShowDialog(this);
        }

        private async void linkLabel3Commas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            await _presenter.On3CommasLinkClicked();
        }
        
        public void ClearLog()
        {
            txtOutput.Clear();
        }

        public void InitGrids(Keys keys, ILogger logger, IMessageBoxService mbs)
        {
            manageBotControl.Init(keys, logger, mbs);
            manageDealControl.Init(keys, logger, mbs);
        }

        public async Task ReloadData()
        {
            await Task.WhenAll(manageBotControl.RefreshData(), manageDealControl.RefreshData());
            NotifyCurrentTab();
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NotifyCurrentTab();
        }
    }
}
