using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3Commas.BulkEditor.Misc;
using FastMember;
using static System.String;

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
        private XCommasAccounts _keys;
        private bool _isBusy;
        private Tuple<string, int>[] _fields;

        public EntityTableControl()
        {
            InitializeComponent();
        }

        protected void Init(string entityName, XCommasAccounts keys)
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

        public void SetDataSource<TViewModel>()
        {
            if (grid.Visible)
            {
                grid.DataSource = bindingSource;
                SetInitialColumnWidth();

                var viewModelProperties = typeof(TViewModel).GetProperties().ToList();
                for (int i = 0; i < grid.ColumnCount; i++)
                {
                    var properties = viewModelProperties.Where(x => x.Name == grid.Columns[i].Name).ToList();
                    if (properties.Any())
                    {
                        PropertyInfo property;
                        if (properties.Count > 1)
                        {
                            var pViewModel = properties.SingleOrDefault(x => x.DeclaringType.Name == typeof(TViewModel).Name);
                            property = pViewModel != null ? pViewModel : properties.First(x => x.DeclaringType.Name != typeof(TViewModel).Name);
                        }
                        else
                        {
                            property = properties.Single();
                        }

                        var displayNameAttribute = property.GetCustomAttribute(typeof(DisplayNameAttribute));
                        if (displayNameAttribute != null)
                        {
                            grid.Columns[i].HeaderText = ((DisplayNameAttribute)displayNameAttribute).DisplayName;
                        }
                    }
                }
            }
        }

        private void SetInitialColumnWidth()
        {
            for (int i = 0; i < grid.ColumnCount; i++)
            {
                var fieldDefinition = _fields.SingleOrDefault(x => x.Item1 == grid.Columns[i].Name);
                if (fieldDefinition != null)
                {
                    grid.Columns[i].Width = fieldDefinition.Item2;
                }
            }
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
            ShowFilterInformation(!IsNullOrWhiteSpace(e.FilterString));
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

        private void RefreshGrid(List<T> entities, params Tuple<string, int>[] fields)
        {
            _isDataLoaded = true;

            _fields = fields;

            _dataTable.Clear();

            using (var reader = ObjectReader.Create(entities, fields.Select(x => x.Item1).ToArray()))
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

        protected async Task RefreshData<TViewModel>(Func<Task<List<T>>> getDataFunc, params Tuple<string, int>[] fields)
        {
            _items = new List<T>();
            IsBusy = true;
            RefreshGrid(_items, fields);
            if (!_keys.IsEmpty)
            {
                _items = await getDataFunc();
            }
            RefreshGrid(_items, fields);
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
