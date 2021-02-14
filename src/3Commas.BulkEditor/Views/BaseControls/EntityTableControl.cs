using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using AutoMapper.Configuration;
using FastMember;
using Keys = _3Commas.BulkEditor.Misc.Keys;
// ReSharper disable LocalizableElement

namespace _3Commas.BulkEditor.Views.BaseControls
{
    public partial class EntityTableControl<T> : UserControl where T : class
    {
        private DataSet _dataSet;
        private DataTable _dataTable;
        private string _entityName;
        private bool _isDataLoaded;
        private List<T> _items;
        private Keys _keys;
        private bool _isBusy;

        public EntityTableControl()
        {
            InitializeComponent();
        }

        protected void Init(string entityName, Keys keys)
        {
            _entityName = entityName;
            _keys = keys;

            btnRefresh.Text = $"Reload {entityName}";
            lblTotalCount.Text = $"0 {_entityName} found:";
            lblVisibleCount.Text = $"0 {_entityName} visible";
            lblSelectedCount.Text = $"0 {_entityName} selected";

            // Initialize DataSet
            _dataSet = new DataSet();
            _dataTable = _dataSet.Tables.Add(entityName);

            // initialize BindingSource
            bindingSource.DataSource = _dataSet;

            // initialize Datagridview
            grid.SetDoubleBuffered();
        }

        public void SetDataSource()
        {
            grid.DataSource = bindingSource;
        }

        public List<int> SelectedIds
        {
            get
            {
                var ids = new List<int>();
                foreach (DataGridViewRow row in grid.SelectedRows)
                {
                    ids.Add((int)row.Cells["Id"].Value);
                }

                return ids;
            }
        }

        protected internal List<T> Items => _items;

        private void SetTotalCount(int count)
        {
            lblTotalCount.Text = $"{count} {_entityName} found";
        }

        private void grid_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            ShowFilterInformation(!string.IsNullOrWhiteSpace(e.FilterString));
            lblVisibleCount.Text = $"{grid.RowCount} {_entityName} visible";
        }

        private void ShowFilterInformation(bool show)
        {
            lblFilterActive.Visible = show;
            btnClearFilter.Visible = show;
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            lblSelectedCount.Text = $"{grid.SelectedRows.Count} {_entityName} selected";
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            grid.CleanFilter();
        }

        private void RefreshGrid<TViewModel>(List<T> entities, params string[] fields)
        {
            _isDataLoaded = true;

            _dataTable.Clear();

            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<T, TViewModel>();
            var mapperConfig = new MapperConfiguration(cfg);
            var mapper = mapperConfig.CreateMapper();
            var botViewModels = mapper.Map<IEnumerable<T>, IEnumerable<TViewModel>>(entities);

            using (var reader = ObjectReader.Create(botViewModels, fields))
            {
                _dataTable.Load(reader);
            }

            bindingSource.DataMember = _dataTable.TableName;

            SetTotalCount(entities.Count);

            grid.ClearSelection();
        }

        private void bindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (_isDataLoaded)
            {
                lblVisibleCount.Text = $"{bindingSource.List.Count} {_entityName} visible";
            }
        }

        private void SetButtonState(bool inProgress)
        {
            btnRefresh.Enabled = !inProgress;
            pbLoading.Visible = inProgress;
            grid.ReadOnly = inProgress;
        }

        public event EventHandler OnRefreshClicked;
        public event EventHandler<IsBusyEventArgs> IsBusyChanged;

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OnRefreshClicked?.Invoke(sender, e);
        }

        protected async Task RefreshData<TViewModel>(Func<Task<List<T>>> getDataFunc, params string[] fields)
        {
            _items = new List<T>();
            IsBusy = true;
            RefreshGrid<TViewModel>(_items, fields);
            if (!String.IsNullOrWhiteSpace(_keys.Secret3Commas) && !String.IsNullOrWhiteSpace(_keys.ApiKey3Commas))
            {
                _items = await getDataFunc();
            }
            RefreshGrid<TViewModel>(_items, fields);
            lblRefreshedAt.Visible = true;
            lblRefreshedAt.Text = $"Last refreshed: " + DateTime.Now.ToLongTimeString();
            IsBusy = false;
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    SetButtonState(value);
                    _isBusy = value;
                    IsBusyChanged?.Invoke(this, new IsBusyEventArgs(value));
                }
            }
        }
    }
}
