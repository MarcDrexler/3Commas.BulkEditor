namespace _3Commas.BulkEditor.Views.EditDialog
{
    partial class EditDialog
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
            this.label3 = new System.Windows.Forms.Label();
            this.numBaseOrderVolume = new System.Windows.Forms.NumericUpDown();
            this.chkChangeIsEnabled = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numSafetyOrderVolume = new System.Windows.Forms.NumericUpDown();
            this.numCooldownBetweenDeals = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbStartOrderType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.numPriceDeviationToOpenSafetyOrders = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numSafetyOrderVolumeScale = new System.Windows.Forms.NumericUpDown();
            this.numTargetProfit = new System.Windows.Forms.NumericUpDown();
            this.chkChangeTrailingEnabled = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numSafetyOrderStepScale = new System.Windows.Forms.NumericUpDown();
            this.lblTrailing = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.numTrailingDeviation = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.numMaxSafetyTradesCount = new System.Windows.Forms.NumericUpDown();
            this.numMaxActiveSafetyTradesCount = new System.Windows.Forms.NumericUpDown();
            this.lblMaxSafetyTradesCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.chkChangeStartOrderType = new System.Windows.Forms.CheckBox();
            this.chkChangeBaseOrderSize = new System.Windows.Forms.CheckBox();
            this.chkChangeSafetyOrderSize = new System.Windows.Forms.CheckBox();
            this.chkChangeTargetProfit = new System.Windows.Forms.CheckBox();
            this.chkChangeTrailingDeviation = new System.Windows.Forms.CheckBox();
            this.chkChangeMaxSafetyTradesCount = new System.Windows.Forms.CheckBox();
            this.chkChangeMaxActiveSafetyTradesCount = new System.Windows.Forms.CheckBox();
            this.chkChangePriceDeviationToOpenSafetyOrders = new System.Windows.Forms.CheckBox();
            this.chkChangeSafetyOrderVolumeScale = new System.Windows.Forms.CheckBox();
            this.chkChangeSafetyOrderStepScale = new System.Windows.Forms.CheckBox();
            this.chkChangeCooldownBetweenDeals = new System.Windows.Forms.CheckBox();
            this.cmbIsEnabled = new System.Windows.Forms.ComboBox();
            this.cmbTtpEnabled = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseOrderVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafetyOrderVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCooldownBetweenDeals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceDeviationToOpenSafetyOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafetyOrderVolumeScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafetyOrderStepScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrailingDeviation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSafetyTradesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxActiveSafetyTradesCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Base order size";
            // 
            // numBaseOrderVolume
            // 
            this.numBaseOrderVolume.DecimalPlaces = 8;
            this.numBaseOrderVolume.Location = new System.Drawing.Point(272, 91);
            this.numBaseOrderVolume.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numBaseOrderVolume.Name = "numBaseOrderVolume";
            this.numBaseOrderVolume.Size = new System.Drawing.Size(121, 20);
            this.numBaseOrderVolume.TabIndex = 76;
            this.numBaseOrderVolume.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // chkChangeIsEnabled
            // 
            this.chkChangeIsEnabled.AutoSize = true;
            this.chkChangeIsEnabled.Location = new System.Drawing.Point(249, 40);
            this.chkChangeIsEnabled.Name = "chkChangeIsEnabled";
            this.chkChangeIsEnabled.Size = new System.Drawing.Size(15, 14);
            this.chkChangeIsEnabled.TabIndex = 64;
            this.chkChangeIsEnabled.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Safety order size";
            // 
            // numSafetyOrderVolume
            // 
            this.numSafetyOrderVolume.DecimalPlaces = 8;
            this.numSafetyOrderVolume.Location = new System.Drawing.Point(272, 117);
            this.numSafetyOrderVolume.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numSafetyOrderVolume.Name = "numSafetyOrderVolume";
            this.numSafetyOrderVolume.Size = new System.Drawing.Size(121, 20);
            this.numSafetyOrderVolume.TabIndex = 78;
            this.numSafetyOrderVolume.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // numCooldownBetweenDeals
            // 
            this.numCooldownBetweenDeals.Location = new System.Drawing.Point(272, 352);
            this.numCooldownBetweenDeals.Maximum = new decimal(new int[] {
            2591999,
            0,
            0,
            0});
            this.numCooldownBetweenDeals.Name = "numCooldownBetweenDeals";
            this.numCooldownBetweenDeals.Size = new System.Drawing.Size(121, 20);
            this.numCooldownBetweenDeals.TabIndex = 89;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 355);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 13);
            this.label8.TabIndex = 108;
            this.label8.Text = "Cooldown between deals (seconds)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(159, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 94;
            this.label12.Text = "Start Order Type";
            // 
            // cmbStartOrderType
            // 
            this.cmbStartOrderType.FormattingEnabled = true;
            this.cmbStartOrderType.Location = new System.Drawing.Point(272, 64);
            this.cmbStartOrderType.Name = "cmbStartOrderType";
            this.cmbStartOrderType.Size = new System.Drawing.Size(121, 21);
            this.cmbStartOrderType.TabIndex = 72;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(48, 277);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(196, 13);
            this.label14.TabIndex = 95;
            this.label14.Text = "Price deviation to open safety orders (%)";
            // 
            // numPriceDeviationToOpenSafetyOrders
            // 
            this.numPriceDeviationToOpenSafetyOrders.DecimalPlaces = 2;
            this.numPriceDeviationToOpenSafetyOrders.Location = new System.Drawing.Point(272, 274);
            this.numPriceDeviationToOpenSafetyOrders.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPriceDeviationToOpenSafetyOrders.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.numPriceDeviationToOpenSafetyOrders.Name = "numPriceDeviationToOpenSafetyOrders";
            this.numPriceDeviationToOpenSafetyOrders.Size = new System.Drawing.Size(121, 20);
            this.numPriceDeviationToOpenSafetyOrders.TabIndex = 86;
            this.numPriceDeviationToOpenSafetyOrders.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(115, 303);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 13);
            this.label13.TabIndex = 96;
            this.label13.Text = "Safety order volume scale";
            // 
            // numSafetyOrderVolumeScale
            // 
            this.numSafetyOrderVolumeScale.DecimalPlaces = 2;
            this.numSafetyOrderVolumeScale.Location = new System.Drawing.Point(272, 300);
            this.numSafetyOrderVolumeScale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSafetyOrderVolumeScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSafetyOrderVolumeScale.Name = "numSafetyOrderVolumeScale";
            this.numSafetyOrderVolumeScale.Size = new System.Drawing.Size(121, 20);
            this.numSafetyOrderVolumeScale.TabIndex = 87;
            this.numSafetyOrderVolumeScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numTargetProfit
            // 
            this.numTargetProfit.DecimalPlaces = 2;
            this.numTargetProfit.Location = new System.Drawing.Point(272, 143);
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
            this.numTargetProfit.TabIndex = 80;
            this.numTargetProfit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkChangeTrailingEnabled
            // 
            this.chkChangeTrailingEnabled.AutoSize = true;
            this.chkChangeTrailingEnabled.Location = new System.Drawing.Point(249, 173);
            this.chkChangeTrailingEnabled.Name = "chkChangeTrailingEnabled";
            this.chkChangeTrailingEnabled.Size = new System.Drawing.Size(15, 14);
            this.chkChangeTrailingEnabled.TabIndex = 81;
            this.chkChangeTrailingEnabled.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(162, 146);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 13);
            this.label19.TabIndex = 102;
            this.label19.Text = "Target Profit (%)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(175, 173);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 97;
            this.label15.Text = "TTP Enabled";
            // 
            // numSafetyOrderStepScale
            // 
            this.numSafetyOrderStepScale.DecimalPlaces = 2;
            this.numSafetyOrderStepScale.Location = new System.Drawing.Point(272, 326);
            this.numSafetyOrderStepScale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSafetyOrderStepScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSafetyOrderStepScale.Name = "numSafetyOrderStepScale";
            this.numSafetyOrderStepScale.Size = new System.Drawing.Size(121, 20);
            this.numSafetyOrderStepScale.TabIndex = 88;
            this.numSafetyOrderStepScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTrailing
            // 
            this.lblTrailing.AutoSize = true;
            this.lblTrailing.Location = new System.Drawing.Point(139, 199);
            this.lblTrailing.Name = "lblTrailing";
            this.lblTrailing.Size = new System.Drawing.Size(106, 13);
            this.lblTrailing.TabIndex = 98;
            this.lblTrailing.Text = "Trailing Deviation (%)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(130, 329);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(115, 13);
            this.label17.TabIndex = 101;
            this.label17.Text = "Safety order step scale";
            // 
            // numTrailingDeviation
            // 
            this.numTrailingDeviation.DecimalPlaces = 1;
            this.numTrailingDeviation.Location = new System.Drawing.Point(272, 196);
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
            this.numTrailingDeviation.TabIndex = 82;
            this.numTrailingDeviation.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(92, 251);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(152, 13);
            this.label18.TabIndex = 100;
            this.label18.Text = "Max active safety trades count";
            // 
            // numMaxSafetyTradesCount
            // 
            this.numMaxSafetyTradesCount.Location = new System.Drawing.Point(272, 222);
            this.numMaxSafetyTradesCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxSafetyTradesCount.Name = "numMaxSafetyTradesCount";
            this.numMaxSafetyTradesCount.Size = new System.Drawing.Size(51, 20);
            this.numMaxSafetyTradesCount.TabIndex = 84;
            this.numMaxSafetyTradesCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMaxActiveSafetyTradesCount
            // 
            this.numMaxActiveSafetyTradesCount.Location = new System.Drawing.Point(272, 248);
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
            this.numMaxActiveSafetyTradesCount.TabIndex = 85;
            this.numMaxActiveSafetyTradesCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMaxSafetyTradesCount
            // 
            this.lblMaxSafetyTradesCount.AutoSize = true;
            this.lblMaxSafetyTradesCount.Location = new System.Drawing.Point(124, 225);
            this.lblMaxSafetyTradesCount.Name = "lblMaxSafetyTradesCount";
            this.lblMaxSafetyTradesCount.Size = new System.Drawing.Size(120, 13);
            this.lblMaxSafetyTradesCount.TabIndex = 99;
            this.lblMaxSafetyTradesCount.Text = "Max safety trades count";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Enabled";
            // 
            // btnCreate
            // 
            this.btnCreate.Image = global::_3Commas.BulkEditor.Properties.Resources.Export_16x16;
            this.btnCreate.Location = new System.Drawing.Point(151, 412);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(189, 23);
            this.btnCreate.TabIndex = 92;
            this.btnCreate.Text = "Publish new settings to Bots";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // chkChangeStartOrderType
            // 
            this.chkChangeStartOrderType.AutoSize = true;
            this.chkChangeStartOrderType.Location = new System.Drawing.Point(249, 67);
            this.chkChangeStartOrderType.Name = "chkChangeStartOrderType";
            this.chkChangeStartOrderType.Size = new System.Drawing.Size(15, 14);
            this.chkChangeStartOrderType.TabIndex = 132;
            this.chkChangeStartOrderType.UseVisualStyleBackColor = true;
            // 
            // chkChangeBaseOrderSize
            // 
            this.chkChangeBaseOrderSize.AutoSize = true;
            this.chkChangeBaseOrderSize.Location = new System.Drawing.Point(249, 93);
            this.chkChangeBaseOrderSize.Name = "chkChangeBaseOrderSize";
            this.chkChangeBaseOrderSize.Size = new System.Drawing.Size(15, 14);
            this.chkChangeBaseOrderSize.TabIndex = 133;
            this.chkChangeBaseOrderSize.UseVisualStyleBackColor = true;
            // 
            // chkChangeSafetyOrderSize
            // 
            this.chkChangeSafetyOrderSize.AutoSize = true;
            this.chkChangeSafetyOrderSize.Location = new System.Drawing.Point(249, 119);
            this.chkChangeSafetyOrderSize.Name = "chkChangeSafetyOrderSize";
            this.chkChangeSafetyOrderSize.Size = new System.Drawing.Size(15, 14);
            this.chkChangeSafetyOrderSize.TabIndex = 134;
            this.chkChangeSafetyOrderSize.UseVisualStyleBackColor = true;
            // 
            // chkChangeTargetProfit
            // 
            this.chkChangeTargetProfit.AutoSize = true;
            this.chkChangeTargetProfit.Location = new System.Drawing.Point(249, 145);
            this.chkChangeTargetProfit.Name = "chkChangeTargetProfit";
            this.chkChangeTargetProfit.Size = new System.Drawing.Size(15, 14);
            this.chkChangeTargetProfit.TabIndex = 135;
            this.chkChangeTargetProfit.UseVisualStyleBackColor = true;
            // 
            // chkChangeTrailingDeviation
            // 
            this.chkChangeTrailingDeviation.AutoSize = true;
            this.chkChangeTrailingDeviation.Location = new System.Drawing.Point(249, 198);
            this.chkChangeTrailingDeviation.Name = "chkChangeTrailingDeviation";
            this.chkChangeTrailingDeviation.Size = new System.Drawing.Size(15, 14);
            this.chkChangeTrailingDeviation.TabIndex = 136;
            this.chkChangeTrailingDeviation.UseVisualStyleBackColor = true;
            // 
            // chkChangeMaxSafetyTradesCount
            // 
            this.chkChangeMaxSafetyTradesCount.AutoSize = true;
            this.chkChangeMaxSafetyTradesCount.Location = new System.Drawing.Point(249, 224);
            this.chkChangeMaxSafetyTradesCount.Name = "chkChangeMaxSafetyTradesCount";
            this.chkChangeMaxSafetyTradesCount.Size = new System.Drawing.Size(15, 14);
            this.chkChangeMaxSafetyTradesCount.TabIndex = 137;
            this.chkChangeMaxSafetyTradesCount.UseVisualStyleBackColor = true;
            // 
            // chkChangeMaxActiveSafetyTradesCount
            // 
            this.chkChangeMaxActiveSafetyTradesCount.AutoSize = true;
            this.chkChangeMaxActiveSafetyTradesCount.Location = new System.Drawing.Point(249, 251);
            this.chkChangeMaxActiveSafetyTradesCount.Name = "chkChangeMaxActiveSafetyTradesCount";
            this.chkChangeMaxActiveSafetyTradesCount.Size = new System.Drawing.Size(15, 14);
            this.chkChangeMaxActiveSafetyTradesCount.TabIndex = 138;
            this.chkChangeMaxActiveSafetyTradesCount.UseVisualStyleBackColor = true;
            // 
            // chkChangePriceDeviationToOpenSafetyOrders
            // 
            this.chkChangePriceDeviationToOpenSafetyOrders.AutoSize = true;
            this.chkChangePriceDeviationToOpenSafetyOrders.Location = new System.Drawing.Point(249, 276);
            this.chkChangePriceDeviationToOpenSafetyOrders.Name = "chkChangePriceDeviationToOpenSafetyOrders";
            this.chkChangePriceDeviationToOpenSafetyOrders.Size = new System.Drawing.Size(15, 14);
            this.chkChangePriceDeviationToOpenSafetyOrders.TabIndex = 139;
            this.chkChangePriceDeviationToOpenSafetyOrders.UseVisualStyleBackColor = true;
            // 
            // chkChangeSafetyOrderVolumeScale
            // 
            this.chkChangeSafetyOrderVolumeScale.AutoSize = true;
            this.chkChangeSafetyOrderVolumeScale.Location = new System.Drawing.Point(249, 303);
            this.chkChangeSafetyOrderVolumeScale.Name = "chkChangeSafetyOrderVolumeScale";
            this.chkChangeSafetyOrderVolumeScale.Size = new System.Drawing.Size(15, 14);
            this.chkChangeSafetyOrderVolumeScale.TabIndex = 140;
            this.chkChangeSafetyOrderVolumeScale.UseVisualStyleBackColor = true;
            // 
            // chkChangeSafetyOrderStepScale
            // 
            this.chkChangeSafetyOrderStepScale.AutoSize = true;
            this.chkChangeSafetyOrderStepScale.Location = new System.Drawing.Point(249, 328);
            this.chkChangeSafetyOrderStepScale.Name = "chkChangeSafetyOrderStepScale";
            this.chkChangeSafetyOrderStepScale.Size = new System.Drawing.Size(15, 14);
            this.chkChangeSafetyOrderStepScale.TabIndex = 141;
            this.chkChangeSafetyOrderStepScale.UseVisualStyleBackColor = true;
            // 
            // chkChangeCooldownBetweenDeals
            // 
            this.chkChangeCooldownBetweenDeals.AutoSize = true;
            this.chkChangeCooldownBetweenDeals.Location = new System.Drawing.Point(249, 354);
            this.chkChangeCooldownBetweenDeals.Name = "chkChangeCooldownBetweenDeals";
            this.chkChangeCooldownBetweenDeals.Size = new System.Drawing.Size(15, 14);
            this.chkChangeCooldownBetweenDeals.TabIndex = 142;
            this.chkChangeCooldownBetweenDeals.UseVisualStyleBackColor = true;
            // 
            // cmbIsEnabled
            // 
            this.cmbIsEnabled.FormattingEnabled = true;
            this.cmbIsEnabled.Location = new System.Drawing.Point(272, 37);
            this.cmbIsEnabled.Name = "cmbIsEnabled";
            this.cmbIsEnabled.Size = new System.Drawing.Size(121, 21);
            this.cmbIsEnabled.TabIndex = 143;
            // 
            // cmbTtpEnabled
            // 
            this.cmbTtpEnabled.FormattingEnabled = true;
            this.cmbTtpEnabled.Location = new System.Drawing.Point(272, 169);
            this.cmbTtpEnabled.Name = "cmbTtpEnabled";
            this.cmbTtpEnabled.Size = new System.Drawing.Size(121, 21);
            this.cmbTtpEnabled.TabIndex = 144;
            // 
            // EditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 470);
            this.Controls.Add(this.cmbTtpEnabled);
            this.Controls.Add(this.cmbIsEnabled);
            this.Controls.Add(this.chkChangeCooldownBetweenDeals);
            this.Controls.Add(this.chkChangeSafetyOrderStepScale);
            this.Controls.Add(this.chkChangeSafetyOrderVolumeScale);
            this.Controls.Add(this.chkChangePriceDeviationToOpenSafetyOrders);
            this.Controls.Add(this.chkChangeMaxActiveSafetyTradesCount);
            this.Controls.Add(this.chkChangeMaxSafetyTradesCount);
            this.Controls.Add(this.chkChangeTrailingDeviation);
            this.Controls.Add(this.chkChangeTargetProfit);
            this.Controls.Add(this.chkChangeSafetyOrderSize);
            this.Controls.Add(this.chkChangeBaseOrderSize);
            this.Controls.Add(this.chkChangeStartOrderType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numBaseOrderVolume);
            this.Controls.Add(this.chkChangeIsEnabled);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numSafetyOrderVolume);
            this.Controls.Add(this.numCooldownBetweenDeals);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbStartOrderType);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numPriceDeviationToOpenSafetyOrders);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numSafetyOrderVolumeScale);
            this.Controls.Add(this.numTargetProfit);
            this.Controls.Add(this.chkChangeTrailingEnabled);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.numSafetyOrderStepScale);
            this.Controls.Add(this.lblTrailing);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.numTrailingDeviation);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.numMaxSafetyTradesCount);
            this.Controls.Add(this.numMaxActiveSafetyTradesCount);
            this.Controls.Add(this.lblMaxSafetyTradesCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bulk Edit";
            ((System.ComponentModel.ISupportInitialize)(this.numBaseOrderVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafetyOrderVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCooldownBetweenDeals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceDeviationToOpenSafetyOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafetyOrderVolumeScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafetyOrderStepScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrailingDeviation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSafetyTradesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxActiveSafetyTradesCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numBaseOrderVolume;
        private System.Windows.Forms.CheckBox chkChangeIsEnabled;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numSafetyOrderVolume;
        private System.Windows.Forms.NumericUpDown numCooldownBetweenDeals;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbStartOrderType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numPriceDeviationToOpenSafetyOrders;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numSafetyOrderVolumeScale;
        private System.Windows.Forms.NumericUpDown numTargetProfit;
        private System.Windows.Forms.CheckBox chkChangeTrailingEnabled;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numSafetyOrderStepScale;
        private System.Windows.Forms.Label lblTrailing;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numTrailingDeviation;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numMaxSafetyTradesCount;
        private System.Windows.Forms.NumericUpDown numMaxActiveSafetyTradesCount;
        private System.Windows.Forms.Label lblMaxSafetyTradesCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkChangeStartOrderType;
        private System.Windows.Forms.CheckBox chkChangeBaseOrderSize;
        private System.Windows.Forms.CheckBox chkChangeSafetyOrderSize;
        private System.Windows.Forms.CheckBox chkChangeTargetProfit;
        private System.Windows.Forms.CheckBox chkChangeTrailingDeviation;
        private System.Windows.Forms.CheckBox chkChangeMaxSafetyTradesCount;
        private System.Windows.Forms.CheckBox chkChangeMaxActiveSafetyTradesCount;
        private System.Windows.Forms.CheckBox chkChangePriceDeviationToOpenSafetyOrders;
        private System.Windows.Forms.CheckBox chkChangeSafetyOrderVolumeScale;
        private System.Windows.Forms.CheckBox chkChangeSafetyOrderStepScale;
        private System.Windows.Forms.CheckBox chkChangeCooldownBetweenDeals;
        private System.Windows.Forms.ComboBox cmbIsEnabled;
        private System.Windows.Forms.ComboBox cmbTtpEnabled;
    }
}