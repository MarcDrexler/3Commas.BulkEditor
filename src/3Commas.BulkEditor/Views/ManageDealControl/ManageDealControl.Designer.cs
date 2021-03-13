
namespace _3Commas.BulkEditor.Views.ManageDealControl
{
    partial class ManageDealControl
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDisableTTP = new System.Windows.Forms.Button();
            this.btnEnableTTP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableControl = new _3Commas.BulkEditor.Views.ManageDealControl.DealTableControl();
            this.btnAddFunds = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnPanicSell = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 687);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1197, 40);
            this.tableLayoutPanel2.TabIndex = 87;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddFunds);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnPanicSell);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnDisableTTP);
            this.panel2.Controls.Add(this.btnEnableTTP);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(261, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 34);
            this.panel2.TabIndex = 78;
            // 
            // btnDisableTTP
            // 
            this.btnDisableTTP.Enabled = false;
            this.btnDisableTTP.Location = new System.Drawing.Point(235, 4);
            this.btnDisableTTP.Name = "btnDisableTTP";
            this.btnDisableTTP.Size = new System.Drawing.Size(75, 27);
            this.btnDisableTTP.TabIndex = 78;
            this.btnDisableTTP.Text = "Disable TTP";
            this.btnDisableTTP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisableTTP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDisableTTP.UseVisualStyleBackColor = true;
            this.btnDisableTTP.Click += new System.EventHandler(this.btnDisableTTP_Click);
            // 
            // btnEnableTTP
            // 
            this.btnEnableTTP.Enabled = false;
            this.btnEnableTTP.Location = new System.Drawing.Point(156, 4);
            this.btnEnableTTP.Name = "btnEnableTTP";
            this.btnEnableTTP.Size = new System.Drawing.Size(73, 27);
            this.btnEnableTTP.TabIndex = 77;
            this.btnEnableTTP.Text = "Enable TTP";
            this.btnEnableTTP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnableTTP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnableTTP.UseVisualStyleBackColor = true;
            this.btnEnableTTP.Click += new System.EventHandler(this.btnEnableTTP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Actions:";
            // 
            // tableControl
            // 
            this.tableControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableControl.IsBusy = false;
            this.tableControl.Location = new System.Drawing.Point(3, 3);
            this.tableControl.Name = "tableControl";
            this.tableControl.Size = new System.Drawing.Size(1197, 678);
            this.tableControl.TabIndex = 0;
            // 
            // btnAddFunds
            // 
            this.btnAddFunds.Enabled = false;
            this.btnAddFunds.Image = global::_3Commas.BulkEditor.Properties.Resources.Financial_16x16;
            this.btnAddFunds.Location = new System.Drawing.Point(548, 4);
            this.btnAddFunds.Name = "btnAddFunds";
            this.btnAddFunds.Size = new System.Drawing.Size(95, 27);
            this.btnAddFunds.TabIndex = 82;
            this.btnAddFunds.Text = "Add funds";
            this.btnAddFunds.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddFunds.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddFunds.UseVisualStyleBackColor = true;
            this.btnAddFunds.Click += new System.EventHandler(this.btnAddFunds_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::_3Commas.BulkEditor.Properties.Resources.Edit_16x16;
            this.btnEdit.Location = new System.Drawing.Point(83, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(67, 27);
            this.btnEdit.TabIndex = 81;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnPanicSell
            // 
            this.btnPanicSell.Enabled = false;
            this.btnPanicSell.Image = global::_3Commas.BulkEditor.Properties.Resources.Currency_16x16;
            this.btnPanicSell.Location = new System.Drawing.Point(395, 4);
            this.btnPanicSell.Name = "btnPanicSell";
            this.btnPanicSell.Size = new System.Drawing.Size(147, 27);
            this.btnPanicSell.TabIndex = 80;
            this.btnPanicSell.Text = "Close at market price";
            this.btnPanicSell.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPanicSell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPanicSell.UseVisualStyleBackColor = true;
            this.btnPanicSell.Click += new System.EventHandler(this.btnPanicSell_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::_3Commas.BulkEditor.Properties.Resources.Hide_16x16;
            this.btnCancel.Location = new System.Drawing.Point(316, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 27);
            this.btnCancel.TabIndex = 79;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ManageDealControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableControl);
            this.Name = "ManageDealControl";
            this.Size = new System.Drawing.Size(1203, 730);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DealTableControl tableControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPanicSell;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDisableTTP;
        private System.Windows.Forms.Button btnEnableTTP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddFunds;
    }
}
