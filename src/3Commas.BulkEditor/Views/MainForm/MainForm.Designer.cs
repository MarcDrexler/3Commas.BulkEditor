using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.MainForm
{
    sealed partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblOutputLog = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.manageBotControl = new _3Commas.BulkEditor.Views.ManageBotControl.ManageBotControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.manageDealControl = new _3Commas.BulkEditor.Views.ManageDealControl.ManageDealControl();
            this.lblAccountsLoaded = new System.Windows.Forms.Label();
            this.lblExchangesLoaded = new System.Windows.Forms.Label();
            this.btnManageApiKeys = new System.Windows.Forms.Button();
            this.btnStopAllBots = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.manageGridBotControl = new _3Commas.BulkEditor.Views.ManageGridBotControl.ManageGridBotControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(12, 550);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(1042, 172);
            this.txtOutput.TabIndex = 0;
            // 
            // lblOutputLog
            // 
            this.lblOutputLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutputLog.AutoSize = true;
            this.lblOutputLog.Location = new System.Drawing.Point(12, 531);
            this.lblOutputLog.Name = "lblOutputLog";
            this.lblOutputLog.Size = new System.Drawing.Size(63, 13);
            this.lblOutputLog.TabIndex = 67;
            this.lblOutputLog.Text = "Output Log:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1042, 459);
            this.tabControl1.TabIndex = 80;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.manageBotControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1034, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DCA Bots";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // manageGridBotControl
            // 
            this.manageGridBotControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageGridBotControl.Location = new System.Drawing.Point(3, 3);
            this.manageGridBotControl.Name = "manageGridBotControl";
            this.manageGridBotControl.Size = new System.Drawing.Size(1028, 427);
            this.manageGridBotControl.TabIndex = 0;
            // 
            // manageBotControl
            // 
            this.manageBotControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageBotControl.Location = new System.Drawing.Point(3, 3);
            this.manageBotControl.Name = "manageBotControl";
            this.manageBotControl.Size = new System.Drawing.Size(1028, 427);
            this.manageBotControl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.manageDealControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1034, 433);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Deals";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.manageGridBotControl);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1034, 433);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Grid Bots";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // manageDealControl
            // 
            this.manageDealControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageDealControl.Location = new System.Drawing.Point(3, 3);
            this.manageDealControl.Name = "manageDealControl";
            this.manageDealControl.Size = new System.Drawing.Size(1028, 427);
            this.manageDealControl.TabIndex = 0;
            // 
            // lblAccountsLoaded
            // 
            this.lblAccountsLoaded.AutoSize = true;
            this.lblAccountsLoaded.Location = new System.Drawing.Point(142, 10);
            this.lblAccountsLoaded.Name = "lblAccountsLoaded";
            this.lblAccountsLoaded.Size = new System.Drawing.Size(148, 13);
            this.lblAccountsLoaded.TabIndex = 81;
            this.lblAccountsLoaded.Text = "3Commas Accounts loaded: 0";
            // 
            // lblExchangesLoaded
            // 
            this.lblExchangesLoaded.AutoSize = true;
            this.lblExchangesLoaded.Location = new System.Drawing.Point(142, 30);
            this.lblExchangesLoaded.Name = "lblExchangesLoaded";
            this.lblExchangesLoaded.Size = new System.Drawing.Size(134, 13);
            this.lblExchangesLoaded.TabIndex = 83;
            this.lblExchangesLoaded.Text = "Total Exchanges loaded: 0";
            // 
            // btnManageApiKeys
            // 
            this.btnManageApiKeys.Image = global::_3Commas.BulkEditor.Properties.Resources.Properties_16x16;
            this.btnManageApiKeys.Location = new System.Drawing.Point(12, 12);
            this.btnManageApiKeys.Name = "btnManageApiKeys";
            this.btnManageApiKeys.Size = new System.Drawing.Size(124, 27);
            this.btnManageApiKeys.TabIndex = 84;
            this.btnManageApiKeys.Text = "Manage API Keys";
            this.btnManageApiKeys.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManageApiKeys.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManageApiKeys.UseVisualStyleBackColor = true;
            this.btnManageApiKeys.Click += new System.EventHandler(this.btnManageApiKeys_Click);
            // 
            // btnStopAllBots
            // 
            this.btnStopAllBots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopAllBots.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStopAllBots.Enabled = false;
            this.btnStopAllBots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopAllBots.Image = global::_3Commas.BulkEditor.Properties.Resources.Info_16x161;
            this.btnStopAllBots.Location = new System.Drawing.Point(831, 12);
            this.btnStopAllBots.Name = "btnStopAllBots";
            this.btnStopAllBots.Size = new System.Drawing.Size(98, 27);
            this.btnStopAllBots.TabIndex = 82;
            this.btnStopAllBots.Text = "Stop all bots";
            this.btnStopAllBots.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStopAllBots.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStopAllBots.UseVisualStyleBackColor = false;
            this.btnStopAllBots.Click += new System.EventHandler(this.btnStopAllBots_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Image = global::_3Commas.BulkEditor.Properties.Resources.Info_16x16;
            this.btnAbout.Location = new System.Drawing.Point(970, 12);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(84, 27);
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
            this.button1.Location = new System.Drawing.Point(984, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clear";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1066, 734);
            this.Controls.Add(this.btnManageApiKeys);
            this.Controls.Add(this.lblExchangesLoaded);
            this.Controls.Add(this.btnStopAllBots);
            this.Controls.Add(this.lblAccountsLoaded);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblOutputLog);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOutput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1048, 590);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulk Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label lblOutputLog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private ManageDealControl.ManageDealControl manageDealControl;
        private ManageBotControl.ManageBotControl manageBotControl;
        private ManageGridBotControl.ManageGridBotControl manageGridBotControl;
        private System.Windows.Forms.Label lblAccountsLoaded;
        private System.Windows.Forms.Button btnStopAllBots;
        private System.Windows.Forms.Label lblExchangesLoaded;
        private System.Windows.Forms.Button btnManageApiKeys;
        private System.Windows.Forms.TabPage tabPage3;
    }
}

