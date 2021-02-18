namespace _3Commas.BulkEditor.Views.EditDealsDialog
{
    partial class EditDealDialog
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
            this.numTargetProfit = new System.Windows.Forms.NumericUpDown();
            this.chkChangeTrailingEnabled = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTrailing = new System.Windows.Forms.Label();
            this.numTrailingDeviation = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.numMaxSafetyTradesCount = new System.Windows.Forms.NumericUpDown();
            this.numMaxActiveSafetyTradesCount = new System.Windows.Forms.NumericUpDown();
            this.lblMaxSafetyTradesCount = new System.Windows.Forms.Label();
            this.chkChangeTargetProfit = new System.Windows.Forms.CheckBox();
            this.chkChangeTrailingDeviation = new System.Windows.Forms.CheckBox();
            this.chkChangeMaxSafetyTradesCount = new System.Windows.Forms.CheckBox();
            this.chkChangeMaxActiveSafetyTradesCount = new System.Windows.Forms.CheckBox();
            this.cmbTtpEnabled = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkStopLossPercentage = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numStopLossPercentage = new System.Windows.Forms.NumericUpDown();
            this.cmbStopLossType = new System.Windows.Forms.ComboBox();
            this.chkStopLossType = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbStopLossTimeoutEnabled = new System.Windows.Forms.ComboBox();
            this.chkStopLossTimeoutEnabled = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.chkStopLossTimeout = new System.Windows.Forms.CheckBox();
            this.numStopLossTimeout = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.chkChangeTakeProfitType = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbTakeProfitType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrailingDeviation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSafetyTradesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxActiveSafetyTradesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStopLossPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStopLossTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // numTargetProfit
            // 
            this.numTargetProfit.DecimalPlaces = 2;
            this.numTargetProfit.Location = new System.Drawing.Point(272, 38);
            this.numTargetProfit.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numTargetProfit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numTargetProfit.Name = "numTargetProfit";
            this.numTargetProfit.Size = new System.Drawing.Size(121, 20);
            this.numTargetProfit.TabIndex = 15;
            this.numTargetProfit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkChangeTrailingEnabled
            // 
            this.chkChangeTrailingEnabled.AutoSize = true;
            this.chkChangeTrailingEnabled.Location = new System.Drawing.Point(249, 95);
            this.chkChangeTrailingEnabled.Name = "chkChangeTrailingEnabled";
            this.chkChangeTrailingEnabled.Size = new System.Drawing.Size(15, 14);
            this.chkChangeTrailingEnabled.TabIndex = 18;
            this.chkChangeTrailingEnabled.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(162, 41);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 13);
            this.label19.TabIndex = 102;
            this.label19.Text = "Target Profit (%)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(148, 95);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 13);
            this.label15.TabIndex = 97;
            this.label15.Text = "Trailing Take Profit";
            // 
            // lblTrailing
            // 
            this.lblTrailing.AutoSize = true;
            this.lblTrailing.Location = new System.Drawing.Point(139, 121);
            this.lblTrailing.Name = "lblTrailing";
            this.lblTrailing.Size = new System.Drawing.Size(106, 13);
            this.lblTrailing.TabIndex = 98;
            this.lblTrailing.Text = "Trailing Deviation (%)";
            // 
            // numTrailingDeviation
            // 
            this.numTrailingDeviation.DecimalPlaces = 2;
            this.numTrailingDeviation.Location = new System.Drawing.Point(272, 118);
            this.numTrailingDeviation.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numTrailingDeviation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numTrailingDeviation.Name = "numTrailingDeviation";
            this.numTrailingDeviation.Size = new System.Drawing.Size(121, 20);
            this.numTrailingDeviation.TabIndex = 21;
            this.numTrailingDeviation.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(92, 279);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(152, 13);
            this.label18.TabIndex = 100;
            this.label18.Text = "Max active safety trades count";
            // 
            // numMaxSafetyTradesCount
            // 
            this.numMaxSafetyTradesCount.Location = new System.Drawing.Point(272, 250);
            this.numMaxSafetyTradesCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxSafetyTradesCount.Name = "numMaxSafetyTradesCount";
            this.numMaxSafetyTradesCount.Size = new System.Drawing.Size(51, 20);
            this.numMaxSafetyTradesCount.TabIndex = 31;
            this.numMaxSafetyTradesCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMaxActiveSafetyTradesCount
            // 
            this.numMaxActiveSafetyTradesCount.Location = new System.Drawing.Point(272, 276);
            this.numMaxActiveSafetyTradesCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMaxActiveSafetyTradesCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxActiveSafetyTradesCount.Name = "numMaxActiveSafetyTradesCount";
            this.numMaxActiveSafetyTradesCount.Size = new System.Drawing.Size(51, 20);
            this.numMaxActiveSafetyTradesCount.TabIndex = 33;
            this.numMaxActiveSafetyTradesCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMaxSafetyTradesCount
            // 
            this.lblMaxSafetyTradesCount.AutoSize = true;
            this.lblMaxSafetyTradesCount.Location = new System.Drawing.Point(124, 253);
            this.lblMaxSafetyTradesCount.Name = "lblMaxSafetyTradesCount";
            this.lblMaxSafetyTradesCount.Size = new System.Drawing.Size(120, 13);
            this.lblMaxSafetyTradesCount.TabIndex = 99;
            this.lblMaxSafetyTradesCount.Text = "Max safety trades count";
            // 
            // chkChangeTargetProfit
            // 
            this.chkChangeTargetProfit.AutoSize = true;
            this.chkChangeTargetProfit.Location = new System.Drawing.Point(249, 40);
            this.chkChangeTargetProfit.Name = "chkChangeTargetProfit";
            this.chkChangeTargetProfit.Size = new System.Drawing.Size(15, 14);
            this.chkChangeTargetProfit.TabIndex = 14;
            this.chkChangeTargetProfit.UseVisualStyleBackColor = true;
            // 
            // chkChangeTrailingDeviation
            // 
            this.chkChangeTrailingDeviation.AutoSize = true;
            this.chkChangeTrailingDeviation.Location = new System.Drawing.Point(249, 121);
            this.chkChangeTrailingDeviation.Name = "chkChangeTrailingDeviation";
            this.chkChangeTrailingDeviation.Size = new System.Drawing.Size(15, 14);
            this.chkChangeTrailingDeviation.TabIndex = 20;
            this.chkChangeTrailingDeviation.UseVisualStyleBackColor = true;
            // 
            // chkChangeMaxSafetyTradesCount
            // 
            this.chkChangeMaxSafetyTradesCount.AutoSize = true;
            this.chkChangeMaxSafetyTradesCount.Location = new System.Drawing.Point(249, 253);
            this.chkChangeMaxSafetyTradesCount.Name = "chkChangeMaxSafetyTradesCount";
            this.chkChangeMaxSafetyTradesCount.Size = new System.Drawing.Size(15, 14);
            this.chkChangeMaxSafetyTradesCount.TabIndex = 30;
            this.chkChangeMaxSafetyTradesCount.UseVisualStyleBackColor = true;
            // 
            // chkChangeMaxActiveSafetyTradesCount
            // 
            this.chkChangeMaxActiveSafetyTradesCount.AutoSize = true;
            this.chkChangeMaxActiveSafetyTradesCount.Location = new System.Drawing.Point(249, 280);
            this.chkChangeMaxActiveSafetyTradesCount.Name = "chkChangeMaxActiveSafetyTradesCount";
            this.chkChangeMaxActiveSafetyTradesCount.Size = new System.Drawing.Size(15, 14);
            this.chkChangeMaxActiveSafetyTradesCount.TabIndex = 32;
            this.chkChangeMaxActiveSafetyTradesCount.UseVisualStyleBackColor = true;
            // 
            // cmbTtpEnabled
            // 
            this.cmbTtpEnabled.FormattingEnabled = true;
            this.cmbTtpEnabled.Location = new System.Drawing.Point(272, 91);
            this.cmbTtpEnabled.Name = "cmbTtpEnabled";
            this.cmbTtpEnabled.Size = new System.Drawing.Size(121, 21);
            this.cmbTtpEnabled.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(539, 334);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 23);
            this.btnCancel.TabIndex = 54;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkStopLossPercentage
            // 
            this.chkStopLossPercentage.AutoSize = true;
            this.chkStopLossPercentage.Location = new System.Drawing.Point(249, 147);
            this.chkStopLossPercentage.Name = "chkStopLossPercentage";
            this.chkStopLossPercentage.Size = new System.Drawing.Size(15, 14);
            this.chkStopLossPercentage.TabIndex = 22;
            this.chkStopLossPercentage.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(134, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 13);
            this.label11.TabIndex = 173;
            this.label11.Text = "Stop Loss Percentage";
            // 
            // numStopLossPercentage
            // 
            this.numStopLossPercentage.DecimalPlaces = 1;
            this.numStopLossPercentage.Location = new System.Drawing.Point(272, 144);
            this.numStopLossPercentage.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numStopLossPercentage.Name = "numStopLossPercentage";
            this.numStopLossPercentage.Size = new System.Drawing.Size(121, 20);
            this.numStopLossPercentage.TabIndex = 23;
            // 
            // cmbStopLossType
            // 
            this.cmbStopLossType.FormattingEnabled = true;
            this.cmbStopLossType.Location = new System.Drawing.Point(272, 170);
            this.cmbStopLossType.Name = "cmbStopLossType";
            this.cmbStopLossType.Size = new System.Drawing.Size(121, 21);
            this.cmbStopLossType.TabIndex = 25;
            // 
            // chkStopLossType
            // 
            this.chkStopLossType.AutoSize = true;
            this.chkStopLossType.Location = new System.Drawing.Point(249, 174);
            this.chkStopLossType.Name = "chkStopLossType";
            this.chkStopLossType.Size = new System.Drawing.Size(15, 14);
            this.chkStopLossType.TabIndex = 24;
            this.chkStopLossType.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(163, 173);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 176;
            this.label16.Text = "Stop Loss Type";
            // 
            // cmbStopLossTimeoutEnabled
            // 
            this.cmbStopLossTimeoutEnabled.FormattingEnabled = true;
            this.cmbStopLossTimeoutEnabled.Location = new System.Drawing.Point(272, 197);
            this.cmbStopLossTimeoutEnabled.Name = "cmbStopLossTimeoutEnabled";
            this.cmbStopLossTimeoutEnabled.Size = new System.Drawing.Size(121, 21);
            this.cmbStopLossTimeoutEnabled.TabIndex = 27;
            // 
            // chkStopLossTimeoutEnabled
            // 
            this.chkStopLossTimeoutEnabled.AutoSize = true;
            this.chkStopLossTimeoutEnabled.Location = new System.Drawing.Point(249, 201);
            this.chkStopLossTimeoutEnabled.Name = "chkStopLossTimeoutEnabled";
            this.chkStopLossTimeoutEnabled.Size = new System.Drawing.Size(15, 14);
            this.chkStopLossTimeoutEnabled.TabIndex = 26;
            this.chkStopLossTimeoutEnabled.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(149, 201);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 13);
            this.label20.TabIndex = 179;
            this.label20.Text = "Stop Loss Timeout";
            // 
            // chkStopLossTimeout
            // 
            this.chkStopLossTimeout.AutoSize = true;
            this.chkStopLossTimeout.Location = new System.Drawing.Point(249, 227);
            this.chkStopLossTimeout.Name = "chkStopLossTimeout";
            this.chkStopLossTimeout.Size = new System.Drawing.Size(15, 14);
            this.chkStopLossTimeout.TabIndex = 28;
            this.chkStopLossTimeout.UseVisualStyleBackColor = true;
            // 
            // numStopLossTimeout
            // 
            this.numStopLossTimeout.Location = new System.Drawing.Point(272, 224);
            this.numStopLossTimeout.Maximum = new decimal(new int[] {
            2591999,
            0,
            0,
            0});
            this.numStopLossTimeout.Name = "numStopLossTimeout";
            this.numStopLossTimeout.Size = new System.Drawing.Size(121, 20);
            this.numStopLossTimeout.TabIndex = 29;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(100, 227);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(144, 13);
            this.label21.TabIndex = 182;
            this.label21.Text = "Stop Loss Timeout (seconds)";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Image = global::_3Commas.BulkEditor.Properties.Resources.Export_16x16;
            this.btnCreate.Location = new System.Drawing.Point(344, 334);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(189, 23);
            this.btnCreate.TabIndex = 53;
            this.btnCreate.Text = "Publish new settings to Deals";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // chkChangeTakeProfitType
            // 
            this.chkChangeTakeProfitType.AutoSize = true;
            this.chkChangeTakeProfitType.Location = new System.Drawing.Point(249, 67);
            this.chkChangeTakeProfitType.Name = "chkChangeTakeProfitType";
            this.chkChangeTakeProfitType.Size = new System.Drawing.Size(15, 14);
            this.chkChangeTakeProfitType.TabIndex = 16;
            this.chkChangeTakeProfitType.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(158, 67);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(86, 13);
            this.label23.TabIndex = 191;
            this.label23.Text = "Take Profit Type";
            // 
            // cmbTakeProfitType
            // 
            this.cmbTakeProfitType.DisplayMember = "Text";
            this.cmbTakeProfitType.FormattingEnabled = true;
            this.cmbTakeProfitType.Location = new System.Drawing.Point(272, 64);
            this.cmbTakeProfitType.Name = "cmbTakeProfitType";
            this.cmbTakeProfitType.Size = new System.Drawing.Size(121, 21);
            this.cmbTakeProfitType.TabIndex = 17;
            // 
            // EditDealDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 369);
            this.Controls.Add(this.chkChangeTakeProfitType);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cmbTakeProfitType);
            this.Controls.Add(this.numStopLossPercentage);
            this.Controls.Add(this.chkStopLossTimeout);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numStopLossTimeout);
            this.Controls.Add(this.chkStopLossPercentage);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbStopLossTimeoutEnabled);
            this.Controls.Add(this.chkStopLossType);
            this.Controls.Add(this.chkStopLossTimeoutEnabled);
            this.Controls.Add(this.cmbStopLossType);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbTtpEnabled);
            this.Controls.Add(this.chkChangeMaxActiveSafetyTradesCount);
            this.Controls.Add(this.chkChangeMaxSafetyTradesCount);
            this.Controls.Add(this.chkChangeTrailingDeviation);
            this.Controls.Add(this.chkChangeTargetProfit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.numTargetProfit);
            this.Controls.Add(this.chkChangeTrailingEnabled);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblTrailing);
            this.Controls.Add(this.numTrailingDeviation);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.numMaxSafetyTradesCount);
            this.Controls.Add(this.numMaxActiveSafetyTradesCount);
            this.Controls.Add(this.lblMaxSafetyTradesCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditDealDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bulk Edit";
            ((System.ComponentModel.ISupportInitialize)(this.numTargetProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrailingDeviation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSafetyTradesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxActiveSafetyTradesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStopLossPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStopLossTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.NumericUpDown numTargetProfit;
        private System.Windows.Forms.CheckBox chkChangeTrailingEnabled;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTrailing;
        private System.Windows.Forms.NumericUpDown numTrailingDeviation;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numMaxSafetyTradesCount;
        private System.Windows.Forms.NumericUpDown numMaxActiveSafetyTradesCount;
        private System.Windows.Forms.Label lblMaxSafetyTradesCount;
        private System.Windows.Forms.CheckBox chkChangeTargetProfit;
        private System.Windows.Forms.CheckBox chkChangeTrailingDeviation;
        private System.Windows.Forms.CheckBox chkChangeMaxSafetyTradesCount;
        private System.Windows.Forms.CheckBox chkChangeMaxActiveSafetyTradesCount;
        private System.Windows.Forms.ComboBox cmbTtpEnabled;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkStopLossPercentage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numStopLossPercentage;
        private System.Windows.Forms.ComboBox cmbStopLossType;
        private System.Windows.Forms.CheckBox chkStopLossType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbStopLossTimeoutEnabled;
        private System.Windows.Forms.CheckBox chkStopLossTimeoutEnabled;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chkStopLossTimeout;
        private System.Windows.Forms.NumericUpDown numStopLossTimeout;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox chkChangeTakeProfitType;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbTakeProfitType;
    }
}