using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using Microsoft.Extensions.Logging;
using Keys = _3Commas.BulkEditor.Misc.Keys;

namespace _3Commas.BulkEditor.Views.MainForm
{
    public class MainFormPresenter : PresenterBase<IMainForm>
    {
        private readonly Keys _keys = new Keys();
        private readonly ILogger _logger;
        private readonly IMessageBoxService _mbs;

        public MainFormPresenter(IMainForm view, ILogger logger, IMessageBoxService mbs) : base(view)
        {
            _logger = logger;
            _mbs = mbs;
            _keys.ApiKey3Commas = Properties.Settings.Default.ApiKey3Commas;
            _keys.Secret3Commas = Properties.Settings.Default.Secret3Commas;
        }

        internal async Task OnViewReady()
        {
            View.InitGrids(_keys, _logger, _mbs);

            if (!string.IsNullOrWhiteSpace(_keys.ApiKey3Commas) && !string.IsNullOrWhiteSpace(_keys.Secret3Commas))
            {
                await View.ReloadData();
            }

            await ShowMessage();
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

        public async Task On3CommasLinkClicked()
        {
            var settingsPersisted = !string.IsNullOrWhiteSpace(Properties.Settings.Default.ApiKey3Commas);
            var settings = new Settings.Settings(settingsPersisted, "3Commas API Credentials", "Permissions Needed: BotsRead, BotsWrite, AccountsRead", _keys.ApiKey3Commas, _keys.Secret3Commas);
            var dr = settings.ShowDialog();
            if (dr == DialogResult.OK)
            {
                _keys.ApiKey3Commas = settings.ApiKey;
                _keys.Secret3Commas = settings.Secret;

                Properties.Settings.Default.ApiKey3Commas = settings.PersistKeys ? settings.ApiKey : "";
                Properties.Settings.Default.Secret3Commas = settings.PersistKeys ? settings.Secret : "";
                Properties.Settings.Default.Save();

                await View.ReloadData();
            }
        }

        public void OnClearClick()
        {
            View.ClearLog();
        }
    }
}
