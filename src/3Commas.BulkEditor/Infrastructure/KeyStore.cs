using System;
using System.Text;
using _3Commas.BulkEditor.Misc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _3Commas.BulkEditor.Infrastructure
{
    public class KeyStore : IKeyStore
    {
        public XCommasAccounts Read()
        {
            var result = new XCommasAccounts();
            try
            {
                var accounts = Properties.Settings.Default.Keys;
                if (!string.IsNullOrWhiteSpace(accounts))
                {
                    byte[] byteArray = Convert.FromBase64String(accounts);
                    string jsonBack = Encoding.UTF8.GetString(byteArray);
                    result = JsonConvert.DeserializeObject<XCommasAccounts>(jsonBack);
                }
            }
            catch (Exception e)
            {
                ObjectContainer.Logger?.LogError($"Error while reading accounts: {e}");
            }
            return result;
        }

        public void Save(XCommasAccounts accounts)
        {
            string json = JsonConvert.SerializeObject(accounts);
            string base64EncodedAccounts = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            Properties.Settings.Default.Keys = base64EncodedAccounts;
            Properties.Settings.Default.Save();
        }

        public void Clear()
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Keys))
            {
                Properties.Settings.Default.Keys = "";
                Properties.Settings.Default.Save();
            }
        }
    }
}