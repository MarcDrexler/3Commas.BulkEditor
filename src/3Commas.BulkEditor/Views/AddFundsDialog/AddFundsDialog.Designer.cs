namespace _3Commas.BulkEditor.Views.AddFundsDialog
{
    partial class AddFundsDialog
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
            this.numQtyUsdt = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblUsdt = new System.Windows.Forms.Label();
            this.lblBtc = new System.Windows.Forms.Label();
            this.numQtyBtc = new System.Windows.Forms.NumericUpDown();
            this.radioUsdt = new System.Windows.Forms.RadioButton();
            this.radioBtc = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numQtyUsdt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQtyBtc)).BeginInit();
            this.SuspendLayout();
            // 
            // numQtyUsdt
            // 
            this.numQtyUsdt.DecimalPlaces = 5;
            this.numQtyUsdt.Location = new System.Drawing.Point(179, 37);
            this.numQtyUsdt.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numQtyUsdt.Name = "numQtyUsdt";
            this.numQtyUsdt.Size = new System.Drawing.Size(101, 20);
            this.numQtyUsdt.TabIndex = 15;
            this.numQtyUsdt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQtyUsdt.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(261, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 25);
            this.btnCancel.TabIndex = 54;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(153, 145);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(102, 25);
            this.btnApply.TabIndex = 53;
            this.btnApply.Text = "Place orders";
            this.btnApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblUsdt
            // 
            this.lblUsdt.AutoSize = true;
            this.lblUsdt.Location = new System.Drawing.Point(286, 40);
            this.lblUsdt.Name = "lblUsdt";
            this.lblUsdt.Size = new System.Drawing.Size(30, 13);
            this.lblUsdt.TabIndex = 192;
            this.lblUsdt.Text = "USD";
            this.lblUsdt.Visible = false;
            // 
            // lblBtc
            // 
            this.lblBtc.AutoSize = true;
            this.lblBtc.Location = new System.Drawing.Point(286, 64);
            this.lblBtc.Name = "lblBtc";
            this.lblBtc.Size = new System.Drawing.Size(28, 13);
            this.lblBtc.TabIndex = 194;
            this.lblBtc.Text = "BTC";
            this.lblBtc.Visible = false;
            // 
            // numQtyBtc
            // 
            this.numQtyBtc.DecimalPlaces = 5;
            this.numQtyBtc.Location = new System.Drawing.Point(179, 61);
            this.numQtyBtc.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numQtyBtc.Name = "numQtyBtc";
            this.numQtyBtc.Size = new System.Drawing.Size(101, 20);
            this.numQtyBtc.TabIndex = 193;
            this.numQtyBtc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQtyBtc.Visible = false;
            // 
            // radioUsdt
            // 
            this.radioUsdt.AutoSize = true;
            this.radioUsdt.Location = new System.Drawing.Point(43, 38);
            this.radioUsdt.Name = "radioUsdt";
            this.radioUsdt.Size = new System.Drawing.Size(129, 17);
            this.radioUsdt.TabIndex = 196;
            this.radioUsdt.TabStop = true;
            this.radioUsdt.Text = "Market order in USDT";
            this.radioUsdt.UseVisualStyleBackColor = true;
            this.radioUsdt.CheckedChanged += new System.EventHandler(this.radioUsdt_CheckedChanged);
            // 
            // radioBtc
            // 
            this.radioBtc.AutoSize = true;
            this.radioBtc.Location = new System.Drawing.Point(43, 62);
            this.radioBtc.Name = "radioBtc";
            this.radioBtc.Size = new System.Drawing.Size(120, 17);
            this.radioBtc.TabIndex = 197;
            this.radioBtc.TabStop = true;
            this.radioBtc.Text = "Market order in BTC";
            this.radioBtc.UseVisualStyleBackColor = true;
            this.radioBtc.CheckedChanged += new System.EventHandler(this.radioUsdt_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Enabled = false;
            this.radioButton3.Location = new System.Drawing.Point(43, 85);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(176, 17);
            this.radioButton3.TabIndex = 198;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Percentage of last executed SO";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // AddFundsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 182);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioBtc);
            this.Controls.Add(this.radioUsdt);
            this.Controls.Add(this.lblBtc);
            this.Controls.Add(this.numQtyBtc);
            this.Controls.Add(this.lblUsdt);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.numQtyUsdt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFundsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bulk Add Funds";
            ((System.ComponentModel.ISupportInitialize)(this.numQtyUsdt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQtyBtc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.NumericUpDown numQtyUsdt;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUsdt;
        private System.Windows.Forms.Label lblBtc;
        private System.Windows.Forms.NumericUpDown numQtyBtc;
        private System.Windows.Forms.RadioButton radioUsdt;
        private System.Windows.Forms.RadioButton radioBtc;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}