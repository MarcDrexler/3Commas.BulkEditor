namespace _3Commas.BulkEditor.Views.MainForm
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.groupBoxCredentials = new System.Windows.Forms.GroupBox();
            this.linkLabel3Commas = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBotCount = new System.Windows.Forms.Label();
            this.lblOutputLog = new System.Windows.Forms.Label();
            this.grid = new Zuby.ADGV.AdvancedDataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblVisibleBotCount = new System.Windows.Forms.Label();
            this.lblFilterActive = new System.Windows.Forms.Label();
            this.lblSelectedBotCount = new System.Windows.Forms.Label();
            this.groupBoxCredentials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(12, 593);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(1008, 172);
            this.txtOutput.TabIndex = 0;
            // 
            // groupBoxCredentials
            // 
            this.groupBoxCredentials.Controls.Add(this.linkLabel3Commas);
            this.groupBoxCredentials.Controls.Add(this.pictureBox1);
            this.groupBoxCredentials.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCredentials.Name = "groupBoxCredentials";
            this.groupBoxCredentials.Size = new System.Drawing.Size(189, 89);
            this.groupBoxCredentials.TabIndex = 64;
            this.groupBoxCredentials.TabStop = false;
            this.groupBoxCredentials.Text = "API Credentials";
            // 
            // linkLabel3Commas
            // 
            this.linkLabel3Commas.AutoSize = true;
            this.linkLabel3Commas.Location = new System.Drawing.Point(15, 64);
            this.linkLabel3Commas.Name = "linkLabel3Commas";
            this.linkLabel3Commas.Size = new System.Drawing.Size(64, 13);
            this.linkLabel3Commas.TabIndex = 64;
            this.linkLabel3Commas.TabStop = true;
            this.linkLabel3Commas.Text = "Set API Key";
            this.linkLabel3Commas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3Commas_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_3Commas.BulkEditor.Properties.Resources._3Commas;
            this.pictureBox1.Location = new System.Drawing.Point(15, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // lblBotCount
            // 
            this.lblBotCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBotCount.AutoSize = true;
            this.lblBotCount.Location = new System.Drawing.Point(12, 491);
            this.lblBotCount.Name = "lblBotCount";
            this.lblBotCount.Size = new System.Drawing.Size(67, 13);
            this.lblBotCount.TabIndex = 66;
            this.lblBotCount.Text = "0 Bots found";
            // 
            // lblOutputLog
            // 
            this.lblOutputLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutputLog.AutoSize = true;
            this.lblOutputLog.Location = new System.Drawing.Point(12, 574);
            this.lblOutputLog.Name = "lblOutputLog";
            this.lblOutputLog.Size = new System.Drawing.Size(63, 13);
            this.lblOutputLog.TabIndex = 67;
            this.lblOutputLog.Text = "Output Log:";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToOrderColumns = true;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.FilterAndSortEnabled = true;
            this.grid.Location = new System.Drawing.Point(12, 107);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grid.Size = new System.Drawing.Size(1008, 372);
            this.grid.TabIndex = 68;
            this.grid.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.grid_FilterStringChanged);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::_3Commas.BulkEditor.Properties.Resources.EditDataSource_16x16;
            this.btnEdit.Location = new System.Drawing.Point(347, 485);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(141, 25);
            this.btnEdit.TabIndex = 69;
            this.btnEdit.Text = "Change Bot Settings";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Image = global::_3Commas.BulkEditor.Properties.Resources.Info_16x16;
            this.btnAbout.Location = new System.Drawing.Point(936, 12);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(84, 25);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "About";
            this.btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::_3Commas.BulkEditor.Properties.Resources.Clear_16x16;
            this.button1.Location = new System.Drawing.Point(950, 562);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clear";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // bindingSource
            // 
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource1_ListChanged);
            // 
            // lblVisibleBotCount
            // 
            this.lblVisibleBotCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVisibleBotCount.AutoSize = true;
            this.lblVisibleBotCount.Location = new System.Drawing.Point(120, 491);
            this.lblVisibleBotCount.Name = "lblVisibleBotCount";
            this.lblVisibleBotCount.Size = new System.Drawing.Size(69, 13);
            this.lblVisibleBotCount.TabIndex = 70;
            this.lblVisibleBotCount.Text = "0 Bots visible";
            // 
            // lblFilterActive
            // 
            this.lblFilterActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFilterActive.AutoSize = true;
            this.lblFilterActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFilterActive.Location = new System.Drawing.Point(120, 513);
            this.lblFilterActive.Name = "lblFilterActive";
            this.lblFilterActive.Size = new System.Drawing.Size(87, 13);
            this.lblFilterActive.TabIndex = 71;
            this.lblFilterActive.Text = "Filter is turned on";
            this.lblFilterActive.Visible = false;
            // 
            // lblSelectedBotCount
            // 
            this.lblSelectedBotCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectedBotCount.AutoSize = true;
            this.lblSelectedBotCount.Location = new System.Drawing.Point(228, 491);
            this.lblSelectedBotCount.Name = "lblSelectedBotCount";
            this.lblSelectedBotCount.Size = new System.Drawing.Size(80, 13);
            this.lblSelectedBotCount.TabIndex = 72;
            this.lblSelectedBotCount.Text = "0 Bots selected";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 777);
            this.Controls.Add(this.lblSelectedBotCount);
            this.Controls.Add(this.lblFilterActive);
            this.Controls.Add(this.lblVisibleBotCount);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.lblOutputLog);
            this.Controls.Add(this.lblBotCount);
            this.Controls.Add(this.groupBoxCredentials);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOutput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1048, 590);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulk Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxCredentials.ResumeLayout(false);
            this.groupBoxCredentials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.GroupBox groupBoxCredentials;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel3Commas;
        private System.Windows.Forms.Label lblBotCount;
        private System.Windows.Forms.Label lblOutputLog;
        private Zuby.ADGV.AdvancedDataGridView grid;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Label lblVisibleBotCount;
        private System.Windows.Forms.Label lblFilterActive;
        private System.Windows.Forms.Label lblSelectedBotCount;
    }
}

