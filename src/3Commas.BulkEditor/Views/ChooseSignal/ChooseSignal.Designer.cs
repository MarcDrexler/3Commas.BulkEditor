namespace _3Commas.BulkEditor.Views.ChooseSignal
{
    partial class ChooseSignal
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
            this.radioButtonNonstop = new System.Windows.Forms.RadioButton();
            this.radioButtonManual = new System.Windows.Forms.RadioButton();
            this.radioButtonRsi = new System.Windows.Forms.RadioButton();
            this.radioButtonTradingView = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRsiTime = new System.Windows.Forms.ComboBox();
            this.numRsiPoints = new System.Windows.Forms.NumericUpDown();
            this.panelRsi = new System.Windows.Forms.Panel();
            this.panelTradingView = new System.Windows.Forms.Panel();
            this.cmbTradingViewType = new System.Windows.Forms.ComboBox();
            this.cmbTradingViewTime = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numRsiPoints)).BeginInit();
            this.panelRsi.SuspendLayout();
            this.panelTradingView.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonNonstop
            // 
            this.radioButtonNonstop.AutoSize = true;
            this.radioButtonNonstop.Checked = true;
            this.radioButtonNonstop.Location = new System.Drawing.Point(13, 13);
            this.radioButtonNonstop.Name = "radioButtonNonstop";
            this.radioButtonNonstop.Size = new System.Drawing.Size(65, 17);
            this.radioButtonNonstop.TabIndex = 0;
            this.radioButtonNonstop.TabStop = true;
            this.radioButtonNonstop.Text = "Nonstop";
            this.radioButtonNonstop.UseVisualStyleBackColor = true;
            this.radioButtonNonstop.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonManual
            // 
            this.radioButtonManual.AutoSize = true;
            this.radioButtonManual.Location = new System.Drawing.Point(13, 36);
            this.radioButtonManual.Name = "radioButtonManual";
            this.radioButtonManual.Size = new System.Drawing.Size(60, 17);
            this.radioButtonManual.TabIndex = 1;
            this.radioButtonManual.Text = "Manual";
            this.radioButtonManual.UseVisualStyleBackColor = true;
            this.radioButtonManual.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonRsi
            // 
            this.radioButtonRsi.AutoSize = true;
            this.radioButtonRsi.Location = new System.Drawing.Point(13, 59);
            this.radioButtonRsi.Name = "radioButtonRsi";
            this.radioButtonRsi.Size = new System.Drawing.Size(43, 17);
            this.radioButtonRsi.TabIndex = 2;
            this.radioButtonRsi.Text = "RSI";
            this.radioButtonRsi.UseVisualStyleBackColor = true;
            this.radioButtonRsi.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonTradingView
            // 
            this.radioButtonTradingView.AutoSize = true;
            this.radioButtonTradingView.Location = new System.Drawing.Point(13, 82);
            this.radioButtonTradingView.Name = "radioButtonTradingView";
            this.radioButtonTradingView.Size = new System.Drawing.Size(87, 17);
            this.radioButtonTradingView.TabIndex = 3;
            this.radioButtonTradingView.Text = "Trading View";
            this.radioButtonTradingView.UseVisualStyleBackColor = true;
            this.radioButtonTradingView.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(370, 120);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 25;
            this.okButton.Text = "&OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(289, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "&Cancel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Points:";
            // 
            // cmbRsiTime
            // 
            this.cmbRsiTime.FormattingEnabled = true;
            this.cmbRsiTime.Location = new System.Drawing.Point(70, 2);
            this.cmbRsiTime.Name = "cmbRsiTime";
            this.cmbRsiTime.Size = new System.Drawing.Size(77, 21);
            this.cmbRsiTime.TabIndex = 30;
            // 
            // numRsiPoints
            // 
            this.numRsiPoints.Location = new System.Drawing.Point(226, 3);
            this.numRsiPoints.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numRsiPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRsiPoints.Name = "numRsiPoints";
            this.numRsiPoints.Size = new System.Drawing.Size(73, 20);
            this.numRsiPoints.TabIndex = 31;
            this.numRsiPoints.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panelRsi
            // 
            this.panelRsi.Controls.Add(this.cmbRsiTime);
            this.panelRsi.Controls.Add(this.numRsiPoints);
            this.panelRsi.Controls.Add(this.label1);
            this.panelRsi.Controls.Add(this.label2);
            this.panelRsi.Location = new System.Drawing.Point(118, 56);
            this.panelRsi.Name = "panelRsi";
            this.panelRsi.Size = new System.Drawing.Size(327, 26);
            this.panelRsi.TabIndex = 32;
            this.panelRsi.Visible = false;
            // 
            // panelTradingView
            // 
            this.panelTradingView.Controls.Add(this.cmbTradingViewType);
            this.panelTradingView.Controls.Add(this.cmbTradingViewTime);
            this.panelTradingView.Controls.Add(this.label3);
            this.panelTradingView.Location = new System.Drawing.Point(118, 78);
            this.panelTradingView.Name = "panelTradingView";
            this.panelTradingView.Size = new System.Drawing.Size(327, 26);
            this.panelTradingView.TabIndex = 33;
            this.panelTradingView.Visible = false;
            // 
            // cmbTradingViewType
            // 
            this.cmbTradingViewType.FormattingEnabled = true;
            this.cmbTradingViewType.Location = new System.Drawing.Point(153, 2);
            this.cmbTradingViewType.Name = "cmbTradingViewType";
            this.cmbTradingViewType.Size = new System.Drawing.Size(77, 21);
            this.cmbTradingViewType.TabIndex = 31;
            // 
            // cmbTradingViewTime
            // 
            this.cmbTradingViewTime.FormattingEnabled = true;
            this.cmbTradingViewTime.Location = new System.Drawing.Point(70, 2);
            this.cmbTradingViewTime.Name = "cmbTradingViewTime";
            this.cmbTradingViewTime.Size = new System.Drawing.Size(77, 21);
            this.cmbTradingViewTime.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Time:";
            // 
            // ChooseSignal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 155);
            this.Controls.Add(this.panelTradingView);
            this.Controls.Add(this.panelRsi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.radioButtonTradingView);
            this.Controls.Add(this.radioButtonRsi);
            this.Controls.Add(this.radioButtonManual);
            this.Controls.Add(this.radioButtonNonstop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseSignal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Start Condition";
            ((System.ComponentModel.ISupportInitialize)(this.numRsiPoints)).EndInit();
            this.panelRsi.ResumeLayout(false);
            this.panelRsi.PerformLayout();
            this.panelTradingView.ResumeLayout(false);
            this.panelTradingView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonNonstop;
        private System.Windows.Forms.RadioButton radioButtonManual;
        private System.Windows.Forms.RadioButton radioButtonRsi;
        private System.Windows.Forms.RadioButton radioButtonTradingView;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRsiTime;
        private System.Windows.Forms.NumericUpDown numRsiPoints;
        private System.Windows.Forms.Panel panelRsi;
        private System.Windows.Forms.Panel panelTradingView;
        private System.Windows.Forms.ComboBox cmbTradingViewTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTradingViewType;
    }
}