using System;
using System.Diagnostics;
using System.Windows.Forms;
using _3Commas.BulkEditor.Misc;

namespace _3Commas.BulkEditor.Views.AboutBox
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

            this.Text = $"About {AssemblyHelper.AssemblyTitle}";
            this.labelProductName.Text = AssemblyHelper.AssemblyProduct;
            this.labelVersion.Text = $"Version {AssemblyHelper.AssemblyVersion}";
            this.textBoxDescription.Text = AssemblyHelper.AssemblyDescription;
        }
        
        private void pbBuyMeACoffee_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.buymeacoffee.com/marcdrexler");
        }

        private void linkGithubProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/MarcDrexler/3Commas.BulkEditor/issues/new");
        }
    }
}
