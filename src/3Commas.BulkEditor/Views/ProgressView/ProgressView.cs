using System;
using System.Threading;
using System.Windows.Forms;

namespace _3Commas.BulkEditor.Views.ProgressView
{
    public partial class ProgressView : Form
    {
        private readonly CancellationTokenSource _cancellationToken;
        private readonly int _totalCount;

        public ProgressView(string text, CancellationTokenSource token, int totalCount)
        {
            _cancellationToken = token;
            _totalCount = totalCount;
            InitializeComponent();
            lblProgress.Text = $@"{text}. Please wait ...";
            progressBar.Maximum = totalCount;
        }

        public void SetProgress(int currentValue)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(() => 
                {
                    progressBar.Value = currentValue;
                    decimal percentage = ((decimal)currentValue / _totalCount) * 100;
                    lblPercentage.Text = $"{(int)percentage} %";
                }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _cancellationToken.Cancel();

            lblProgress.Text = @"Operation has been cancelled.";
            progressBar.Enabled = false;
            btnCancel.Visible = false;
            btnClose.Visible = true;
        }

        private void ProgressView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Enabled = true;
            }
        }

        private void ProgressView_Load(object sender, EventArgs e)
        {
            CenterToParent();
            if (this.Owner != null)
            {
                this.Owner.Enabled = false;
            }
        }
    }
}
