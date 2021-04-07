
namespace _3Commas.BulkEditor.Views.ManageGridBotControl
{
    partial class ManageGridBotControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tableControl = new _3Commas.BulkEditor.Views.ManageGridBotControl.GridBotTableControl();
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
            this.panel2.Controls.Add(this.btnCopy);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(300, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 34);
            this.panel2.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Actions:";
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Image = global::_3Commas.BulkEditor.Properties.Resources.Copy_16x16;
            this.btnCopy.Location = new System.Drawing.Point(262, 4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(67, 27);
            this.btnCopy.TabIndex = 79;
            this.btnCopy.Text = "Copy";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::_3Commas.BulkEditor.Properties.Resources.Edit_16x16;
            this.btnEdit.Location = new System.Drawing.Point(189, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(67, 27);
            this.btnEdit.TabIndex = 78;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::_3Commas.BulkEditor.Properties.Resources.Delete_16x161;
            this.btnDelete.Location = new System.Drawing.Point(335, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 27);
            this.btnDelete.TabIndex = 80;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            // ManageBotControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableControl);
            this.Name = "ManageBotControl";
            this.Size = new System.Drawing.Size(1203, 730);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GridBotTableControl tableControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}
