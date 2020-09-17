using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using FastMember;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.MainForm
{
    public partial class MainForm : Form, IMainForm
    {
        private readonly MainFormPresenter _presenter;
        private readonly DataTable _dataTable;
        private readonly DataSet _dataSet;
        private bool _isDataLoaded;

        public MainForm()
        {
            InitializeComponent();

            this.Text = $"{AssemblyHelper.AssemblyTitle} {AssemblyHelper.AssemblyVersion}";

            _presenter = new MainFormPresenter(this, new TextBoxLogger(txtOutput), new MessageBoxService());

            // Initialize DataSet
            _dataSet = new DataSet();
            _dataTable = _dataSet.Tables.Add("Bots");

            // initialize BindingSource
            bindingSource.DataSource = _dataSet;

            // initialize Datagridview
            grid.SetDoubleBuffered();
            grid.DataSource = bindingSource;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _presenter.OnViewReady();
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

        public void SetTotalBotCount(int count)
        {
            lblBotCount.Text = $"{count} Bots found:";
        }

        public void RefreshBotGrid(List<Bot> bots)
        {
            _isDataLoaded = true;

            _dataTable.Clear();

            using (var reader = ObjectReader.Create(new List<Bot>(bots),
                nameof(Bot.Id),
                nameof(Bot.Type),
                nameof(Bot.IsEnabled),
                nameof(Bot.Name),
                nameof(Bot.Strategy),
                nameof(Bot.AccountName),
                nameof(Bot.MaxActiveDeals),
                nameof(Bot.ActiveDealsCount),
                nameof(Bot.TakeProfit),
                nameof(Bot.TakeProfitType),
                nameof(Bot.ProfitCurrency),
                nameof(Bot.TrailingEnabled),
                nameof(Bot.TrailingDeviation),
                nameof(Bot.StopLossPercentage),
                nameof(Bot.BaseOrderVolume),
                nameof(Bot.BaseOrderVolumeType),
                nameof(Bot.StartOrderType),
                nameof(Bot.SafetyOrderVolume),
                nameof(Bot.SafetyOrderVolumeType),
                nameof(Bot.MaxSafetyOrders),
                nameof(Bot.ActiveSafetyOrdersCount),
                nameof(Bot.SafetyOrderStepPercentage),
                nameof(Bot.StopLossPercentage),
                nameof(Bot.LeverageType),
                nameof(Bot.LeverageCustomValue),
                nameof(Bot.MartingaleVolumeCoefficient),
                nameof(Bot.MartingaleStepCoefficient),
                nameof(Bot.MinPrice),
                nameof(Bot.MaxPrice),
                nameof(Bot.MinVolumeBtc24h),
                nameof(Bot.Cooldown),
                nameof(Bot.DisableAfterDealsCount),
                nameof(Bot.FinishedDealsCount),
                nameof(Bot.FinishedDealsProfitUsd),
                nameof(Bot.CreatedAt),
                nameof(Bot.UpdatedAt),
                nameof(Bot.IsDeleteable)))
            {
                _dataTable.Load(reader);
            }

            bindingSource.DataMember = _dataTable.TableName;

            grid.ClearSelection();
        }

        public void ClearLog()
        {
            txtOutput.Clear();
        }

        public void SetCreateInProgress(bool inProgress)
        {
            Cursor.Current = inProgress ? Cursors.WaitCursor : Cursors.Default;
            pbLoading.Visible = inProgress;
            grid.ReadOnly = inProgress;
            grid.Enabled = !inProgress;
            Application.DoEvents();
            btnEdit.Enabled = !inProgress;
            btnRefresh.Enabled = !inProgress;
        }

        public void SetVisibleCount(int count)
        {
            lblVisibleBotCount.Text = $"{count} Bots visible";
        }

        public void ShowFilterInformation(bool show)
        {
            lblFilterActive.Visible = show;
            btnClearFilter.Visible = show;
        }

        public void SetSelectedRowCount(int count)
        {
            lblSelectedBotCount.Text = $"{count} Bots selected";
        }

        private void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (_isDataLoaded) _presenter.OnListChanged(bindingSource.List.Count);
        }

        private void grid_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            _presenter.OnGridFilterChanged(e.FilterString);
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            _presenter.OnSelectionChanged(grid.SelectedRows.Count);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _presenter.OnEdit();
        }

        public List<int> SelectedBotIds
        {
            get
            {
                var ids = new List<int>();
                foreach (DataGridViewRow row in grid.SelectedRows)
                {
                    ids.Add((int) row.Cells[nameof(Bot.Id)].Value);
                }
                return ids;
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            grid.CleanFilter();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await _presenter.OnRefresh();
        }
    }
}
