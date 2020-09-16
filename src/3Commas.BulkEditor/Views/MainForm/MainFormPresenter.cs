using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;
using Keys = _3Commas.BulkEditor.Misc.Keys;

namespace _3Commas.BulkEditor.Views.MainForm
{
    public class MainFormPresenter : PresenterBase<IMainForm>
    {
        private readonly Keys _keys = new Keys();
        private readonly ILogger _logger;
        private readonly IMessageBoxService _mbs;
        private List<Bot> _bots = new List<Bot>();

        public MainFormPresenter(IMainForm view, ILogger logger, IMessageBoxService mbs) : base(view)
        {
            _logger = logger;
            _mbs = mbs;
            _keys.ApiKey3Commas = ConfigurationManager.AppSettings["3CommasApiKey"];
            _keys.Secret3Commas = ConfigurationManager.AppSettings["3CommasSecret"];
        }

        internal void OnViewReady()
        {
        }
        
        public async Task On3CommasLinkClicked()
        {
            var settings = new Settings.Settings("3Commas API Credentials", "Permissions Needed: BotsRead, BotsWrite, AccountsRead", _keys.ApiKey3Commas, _keys.Secret3Commas);
            var dr = settings.ShowDialog();
            if (dr == DialogResult.OK)
            {
                _keys.ApiKey3Commas = settings.ApiKey;
                _keys.Secret3Commas = settings.Secret;
                await RefreshBots();
            }
        }

        private async Task RefreshBots()
        {
            View.SetCreateInProgress(true);
            _bots = new List<Bot>();
            View.RefreshBotGrid(_bots);
            if (!String.IsNullOrWhiteSpace(_keys.Secret3Commas) && !String.IsNullOrWhiteSpace(_keys.ApiKey3Commas))
            {
                var botMgr = new BotManager(_keys, _logger);
                _bots = (await botMgr.GetAllBots()).ToList();
            }
            View.RefreshBotGrid(_bots);
            View.SetTotalBotCount(_bots.Count);
            View.SetCreateInProgress(false);
        }

        public void OnClearClick()
        {
            View.ClearLog();
        }

        public void OnListChanged(int count)
        {
            View.SetVisibleCount(count);
        }

        public void OnGridFilterChanged(string filterString)
        {
            View.ShowFilterInformation(!string.IsNullOrWhiteSpace(filterString));
        }

        public void OnSelectionChanged(int count)
        {
            View.SetSelectedRowCount(count);
        }

        public async void OnEdit()
        {
            var ids = View.SelectedBotIds;
            var botsToEdit = _bots.Where(x => ids.Contains(x.Id)).ToList();
            if (botsToEdit.Any(x => x.Type != "Bot::SingleBot"))
            {
                _mbs.ShowError("Sorry, Bulk Edit only works for Simple Bots, not advanced.");
                return;
            }

            var dlg = new EditDialog.EditDialog(botsToEdit, _keys, _logger);
            var dr = dlg.ShowDialog(View);
            if (dr == DialogResult.OK)
            {
                _logger.LogInformation("Refreshing Bots");
                await RefreshBots();
            }
        }
    }
}
