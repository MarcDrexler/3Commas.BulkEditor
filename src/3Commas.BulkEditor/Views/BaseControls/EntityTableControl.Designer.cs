
namespace _3Commas.BulkEditor.Views.BaseControls
{
    partial class EntityTableControl<T> where T : class
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblVisibleCount = new System.Windows.Forms.Label();
            this.lblFilterActive = new System.Windows.Forms.Label();
            this.grid = new Zuby.ADGV.AdvancedDataGridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.lblSelectedCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblRefreshedAt = new System.Windows.Forms.Label();
            this.tableLayoutPanelUpper = new System.Windows.Forms.TableLayoutPanel();
            this.panelUpper = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.tableLayoutPanelUpper.SuspendLayout();
            this.panelUpper.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVisibleCount
            // 
            this.lblVisibleCount.AutoSize = true;
            this.lblVisibleCount.Location = new System.Drawing.Point(198, 5);
            this.lblVisibleCount.Name = "lblVisibleCount";
            this.lblVisibleCount.Size = new System.Drawing.Size(82, 13);
            this.lblVisibleCount.TabIndex = 82;
            this.lblVisibleCount.Text = "0 Entities visible";
            // 
            // lblFilterActive
            // 
            this.lblFilterActive.AutoSize = true;
            this.lblFilterActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFilterActive.Location = new System.Drawing.Point(308, 5);
            this.lblFilterActive.Name = "lblFilterActive";
            this.lblFilterActive.Size = new System.Drawing.Size(87, 13);
            this.lblFilterActive.TabIndex = 83;
            this.lblFilterActive.Text = "Filter is turned on";
            this.lblFilterActive.Visible = false;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToOrderColumns = true;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.FilterAndSortEnabled = true;
            this.grid.GridColor = System.Drawing.SystemColors.ControlLight;
            this.grid.Location = new System.Drawing.Point(3, 58);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grid.Size = new System.Drawing.Size(1128, 589);
            this.grid.TabIndex = 81;
            this.grid.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.grid_FilterStringChanged);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // bindingSource
            // 
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoading.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbLoading.Image = global::_3Commas.BulkEditor.Properties.Resources.loader2;
            this.pbLoading.Location = new System.Drawing.Point(6, 87);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(1118, 534);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLoading.TabIndex = 80;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilter.FlatAppearance.BorderSize = 0;
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.Image = global::_3Commas.BulkEditor.Properties.Resources.Close_16x16;
            this.btnClearFilter.Location = new System.Drawing.Point(284, -1);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(26, 25);
            this.btnClearFilter.TabIndex = 85;
            this.btnClearFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Visible = false;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // lblSelectedCount
            // 
            this.lblSelectedCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectedCount.AutoSize = true;
            this.lblSelectedCount.Location = new System.Drawing.Point(3, 650);
            this.lblSelectedCount.Name = "lblSelectedCount";
            this.lblSelectedCount.Size = new System.Drawing.Size(93, 13);
            this.lblSelectedCount.TabIndex = 86;
            this.lblSelectedCount.Text = "0 Entities selected";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = global::_3Commas.BulkEditor.Properties.Resources.Convert_16x16;
            this.btnRefresh.Location = new System.Drawing.Point(3, 26);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(127, 27);
            this.btnRefresh.TabIndex = 88;
            this.btnRefresh.Text = "Reload Entities";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Location = new System.Drawing.Point(3, 10);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(127, 13);
            this.lblTotalCount.TabIndex = 87;
            this.lblTotalCount.Text = "0 Entities found";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRefreshedAt
            // 
            this.lblRefreshedAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRefreshedAt.Location = new System.Drawing.Point(929, 33);
            this.lblRefreshedAt.Name = "lblRefreshedAt";
            this.lblRefreshedAt.Size = new System.Drawing.Size(195, 13);
            this.lblRefreshedAt.TabIndex = 89;
            this.lblRefreshedAt.Text = "Last refreshed: xx.xx.xxxx";
            this.lblRefreshedAt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRefreshedAt.Visible = false;
            // 
            // tableLayoutPanelUpper
            // 
            this.tableLayoutPanelUpper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelUpper.ColumnCount = 3;
            this.tableLayoutPanelUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanelUpper.Controls.Add(this.panelUpper, 1, 0);
            this.tableLayoutPanelUpper.Location = new System.Drawing.Point(171, 24);
            this.tableLayoutPanelUpper.Name = "tableLayoutPanelUpper";
            this.tableLayoutPanelUpper.RowCount = 1;
            this.tableLayoutPanelUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelUpper.Size = new System.Drawing.Size(742, 29);
            this.tableLayoutPanelUpper.TabIndex = 90;
            // 
            // panelUpper
            // 
            this.panelUpper.Controls.Add(this.lblVisibleCount);
            this.panelUpper.Controls.Add(this.btnClearFilter);
            this.panelUpper.Controls.Add(this.lblFilterActive);
            this.panelUpper.Location = new System.Drawing.Point(72, 3);
            this.panelUpper.Name = "panelUpper";
            this.panelUpper.Size = new System.Drawing.Size(596, 23);
            this.panelUpper.TabIndex = 78;
            // 
            // EntityTableControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanelUpper);
            this.Controls.Add(this.lblRefreshedAt);
            this.Controls.Add(this.lblSelectedCount);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.grid);
            this.Name = "EntityTableControl";
            this.Size = new System.Drawing.Size(1134, 665);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.tableLayoutPanelUpper.ResumeLayout(false);
            this.panelUpper.ResumeLayout(false);
            this.panelUpper.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVisibleCount;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Label lblFilterActive;
        private System.Windows.Forms.Button btnClearFilter;
        private Zuby.ADGV.AdvancedDataGridView grid;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Label lblSelectedCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblRefreshedAt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUpper;
        private System.Windows.Forms.Panel panelUpper;
    }
}
