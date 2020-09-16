using System;
using System.Windows.Forms;
using _3Commas.BulkEditor.Views;
using _3Commas.BulkEditor.Views.MainForm;

namespace _3Commas.BulkEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
