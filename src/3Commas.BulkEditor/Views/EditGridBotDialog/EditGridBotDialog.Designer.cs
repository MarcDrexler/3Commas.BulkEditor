namespace _3Commas.BulkEditor.Views.EditGridBotDialog
{
    partial class EditGridBotDialog
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
            this.label3 = new System.Windows.Forms.Label();
            this.numUpperLimit = new System.Windows.Forms.NumericUpDown();
            this.chkChangeIsEnabled = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numLowerLimit = new System.Windows.Forms.NumericUpDown();
            this.numGridQuantity = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkChangeUpperLimit = new System.Windows.Forms.CheckBox();
            this.chkChangeLowerLimit = new System.Windows.Forms.CheckBox();
            this.chkChangeGridQuantity = new System.Windows.Forms.CheckBox();
            this.cmbIsEnabled = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.toolTipName = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.numQuantityPerGrid = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chkChangeQuantityPerGrid = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpperLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowerLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGridQuantity)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityPerGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Upper limit price";
            // 
            // numUpperLimit
            // 
            this.numUpperLimit.DecimalPlaces = 8;
            this.numUpperLimit.Location = new System.Drawing.Point(237, 43);
            this.numUpperLimit.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numUpperLimit.Name = "numUpperLimit";
            this.numUpperLimit.Size = new System.Drawing.Size(121, 20);
            this.numUpperLimit.TabIndex = 7;
            this.numUpperLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkChangeIsEnabled
            // 
            this.chkChangeIsEnabled.AutoSize = true;
            this.chkChangeIsEnabled.Location = new System.Drawing.Point(214, 19);
            this.chkChangeIsEnabled.Name = "chkChangeIsEnabled";
            this.chkChangeIsEnabled.Size = new System.Drawing.Size(15, 14);
            this.chkChangeIsEnabled.TabIndex = 0;
            this.chkChangeIsEnabled.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Lower limit price";
            // 
            // numLowerLimit
            // 
            this.numLowerLimit.DecimalPlaces = 8;
            this.numLowerLimit.Location = new System.Drawing.Point(237, 69);
            this.numLowerLimit.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numLowerLimit.Name = "numLowerLimit";
            this.numLowerLimit.Size = new System.Drawing.Size(121, 20);
            this.numLowerLimit.TabIndex = 11;
            this.numLowerLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numGridQuantity
            // 
            this.numGridQuantity.Location = new System.Drawing.Point(237, 95);
            this.numGridQuantity.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numGridQuantity.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numGridQuantity.Name = "numGridQuantity";
            this.numGridQuantity.Size = new System.Drawing.Size(121, 20);
            this.numGridQuantity.TabIndex = 15;
            this.numGridQuantity.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(143, 98);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 13);
            this.label19.TabIndex = 102;
            this.label19.Text = "Grid quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Enabled";
            // 
            // chkChangeUpperLimit
            // 
            this.chkChangeUpperLimit.AutoSize = true;
            this.chkChangeUpperLimit.Location = new System.Drawing.Point(214, 46);
            this.chkChangeUpperLimit.Name = "chkChangeUpperLimit";
            this.chkChangeUpperLimit.Size = new System.Drawing.Size(15, 14);
            this.chkChangeUpperLimit.TabIndex = 6;
            this.chkChangeUpperLimit.UseVisualStyleBackColor = true;
            // 
            // chkChangeLowerLimit
            // 
            this.chkChangeLowerLimit.AutoSize = true;
            this.chkChangeLowerLimit.Location = new System.Drawing.Point(214, 72);
            this.chkChangeLowerLimit.Name = "chkChangeLowerLimit";
            this.chkChangeLowerLimit.Size = new System.Drawing.Size(15, 14);
            this.chkChangeLowerLimit.TabIndex = 10;
            this.chkChangeLowerLimit.UseVisualStyleBackColor = true;
            // 
            // chkChangeGridQuantity
            // 
            this.chkChangeGridQuantity.AutoSize = true;
            this.chkChangeGridQuantity.Location = new System.Drawing.Point(214, 98);
            this.chkChangeGridQuantity.Name = "chkChangeGridQuantity";
            this.chkChangeGridQuantity.Size = new System.Drawing.Size(15, 14);
            this.chkChangeGridQuantity.TabIndex = 14;
            this.chkChangeGridQuantity.UseVisualStyleBackColor = true;
            // 
            // cmbIsEnabled
            // 
            this.cmbIsEnabled.FormattingEnabled = true;
            this.cmbIsEnabled.Location = new System.Drawing.Point(237, 16);
            this.cmbIsEnabled.Name = "cmbIsEnabled";
            this.cmbIsEnabled.Size = new System.Drawing.Size(121, 21);
            this.cmbIsEnabled.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(425, 194);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 25);
            this.btnCancel.TabIndex = 54;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Image = global::_3Commas.BulkEditor.Properties.Resources.Export_16x16;
            this.btnCreate.Location = new System.Drawing.Point(230, 194);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(189, 25);
            this.btnCreate.TabIndex = 53;
            this.btnCreate.Text = "Publish new settings to Bots";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // toolTipName
            // 
            this.toolTipName.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.numQuantityPerGrid);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkChangeQuantityPerGrid);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.numGridQuantity);
            this.panel1.Controls.Add(this.numLowerLimit);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkChangeIsEnabled);
            this.panel1.Controls.Add(this.numUpperLimit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkChangeUpperLimit);
            this.panel1.Controls.Add(this.chkChangeLowerLimit);
            this.panel1.Controls.Add(this.chkChangeGridQuantity);
            this.panel1.Controls.Add(this.cmbIsEnabled);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 171);
            this.panel1.TabIndex = 193;
            // 
            // numQuantityPerGrid
            // 
            this.numQuantityPerGrid.DecimalPlaces = 8;
            this.numQuantityPerGrid.Location = new System.Drawing.Point(237, 121);
            this.numQuantityPerGrid.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numQuantityPerGrid.Name = "numQuantityPerGrid";
            this.numQuantityPerGrid.Size = new System.Drawing.Size(121, 20);
            this.numQuantityPerGrid.TabIndex = 117;
            this.numQuantityPerGrid.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 118;
            this.label2.Text = "Quantity per Grid";
            // 
            // chkChangeQuantityPerGrid
            // 
            this.chkChangeQuantityPerGrid.AutoSize = true;
            this.chkChangeQuantityPerGrid.Location = new System.Drawing.Point(214, 124);
            this.chkChangeQuantityPerGrid.Name = "chkChangeQuantityPerGrid";
            this.chkChangeQuantityPerGrid.Size = new System.Drawing.Size(15, 14);
            this.chkChangeQuantityPerGrid.TabIndex = 116;
            this.chkChangeQuantityPerGrid.UseVisualStyleBackColor = true;
            // 
            // EditGridBotDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(525, 231);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditGridBotDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bulk Edit";
            ((System.ComponentModel.ISupportInitialize)(this.numUpperLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowerLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGridQuantity)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantityPerGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numUpperLimit;
        private System.Windows.Forms.CheckBox chkChangeIsEnabled;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numLowerLimit;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.NumericUpDown numGridQuantity;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkChangeUpperLimit;
        private System.Windows.Forms.CheckBox chkChangeLowerLimit;
        private System.Windows.Forms.CheckBox chkChangeGridQuantity;
        private System.Windows.Forms.ComboBox cmbIsEnabled;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTipName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numQuantityPerGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkChangeQuantityPerGrid;
    }
}