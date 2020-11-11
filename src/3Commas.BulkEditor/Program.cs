using System;
using System.Configuration;
using System.Net;
using System.Windows.Forms;
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

            try
            {
                EncryptConfigFile();
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                MessageBox.Show("Sorry, but something went wrong!" + Environment.NewLine + Environment.NewLine +
                                "Please let me know that there was a problem and I will try to fit it for you. You can report this error here: " +
                                "https://github.com/MarcDrexler/3Commas.BulkEditor/issues" + Environment.NewLine + Environment.NewLine +
                                "Error Details: " + Environment.NewLine +
                                e.ToString(), "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void EncryptConfigFile()
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            ConfigurationSection section = config.GetSection("userSettings/_3Commas.BulkEditor.Properties.Settings");
            if (!section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                section.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Full);
            }
        }
    }
}
