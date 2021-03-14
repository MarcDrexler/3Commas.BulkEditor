using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using M.EventBroker;
using Microsoft.Extensions.Logging;

namespace _3Commas.BulkEditor.Views.MainForm
{
    public class MainFormPresenter : PresenterBase<IMainForm>
    {
        private XCommasAccounts _keys;
        private readonly ILogger _logger;
        private readonly IMessageBoxService _mbs;
        private readonly IEventBroker _eventBroker;

        public MainFormPresenter(IMainForm view, ILogger logger, IMessageBoxService mbs, IEventBroker eventBroker) : base(view)
        {
            _logger = logger;
            _mbs = mbs;
            _eventBroker = eventBroker;

            GetOrMigrateSettings();
        }

        private void GetOrMigrateSettings()
        {
            var apiKey = Properties.Settings.Default.ApiKey3Commas;
            var secret = Properties.Settings.Default.Secret3Commas;
            _keys = ObjectContainer.KeyManager.Read();
            if (!string.IsNullOrWhiteSpace(apiKey) && !string.IsNullOrWhiteSpace(secret) && _keys.IsEmpty)
            {
                _keys = new XCommasAccounts { Accounts = new List<XCommasAccount> { new XCommasAccount { ApiKey = apiKey, Secret = secret, Name = "default" } } };
                ObjectContainer.KeyManager.Save(_keys);
            }
        }

        internal async Task OnViewReady()
        {
            if (!_keys.IsEmpty) await LoadAccounts();
            View.InitGrids(_keys, _logger, _mbs);
            await ShowMessage();
        }

        private async Task LoadAccounts()
        {
            var xCommas = new XCommasLayer(_keys, _logger);
            var exchanges = await xCommas.RetrieveAccounts();
            ObjectContainer.Cache.SetAccounts(exchanges);
            View.SetAccountCount(_keys.Accounts.Count);
            View.SetExchangeCount(exchanges.Count);
            View.EnablePanicButton();
        }

        private async Task ShowMessage()
        {
            try
            {
                HttpClient client = new HttpClient();
                string result = await client.GetStringAsync("https://marcdrexler.blob.core.windows.net/bulkeditor/message.txt");
                if (!String.IsNullOrWhiteSpace(result))
                {
                    _mbs.ShowInformation(result);
                }
            }
            catch
            {
                // ignore
            }
        }

        public async void OnManageApiKeys()
        {
            var settingsPersisted = !string.IsNullOrWhiteSpace(Properties.Settings.Default.ApiKey3Commas);
            var settings = new Settings.Settings(settingsPersisted, "3Commas Accounts", _keys);
            var dr = settings.ShowDialog();
            if (dr == DialogResult.OK)
            {
                _keys = new XCommasAccounts {Accounts = settings.Accounts.ToList()};

                await LoadAccounts();
                _eventBroker.Publish(new KeysChangedEventArgs() {Keys = _keys});
            }
        }

        public void OnClear()
        {
            View.ClearLog();
        }

        public void OnStopAllBots()
        {
            _eventBroker.Publish(new StopAllBotsEventArgs());
        }
    }
}
