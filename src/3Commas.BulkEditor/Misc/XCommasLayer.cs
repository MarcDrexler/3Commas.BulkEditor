using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3Commas.BulkEditor.Views.CopyBotDialog;
using _3Commas.BulkEditor.Views.ManageBotControl;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.Logging;
using XCommas.Net;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Misc
{
    public class XCommasLayer
    {
        private readonly ILogger _logger;
        private readonly Dictionary<Guid, Tuple<string, XCommasApi>> _3CommasClients = new Dictionary<Guid, Tuple<string, XCommasApi>>();

        public XCommasLayer(XCommasAccounts accounts, ILogger logger)
        {
            _logger = logger;

            foreach (var xCommasAccount in accounts.Accounts)
            {
                _3CommasClients.Add(xCommasAccount.Id, new Tuple<string, XCommasApi>(xCommasAccount.Name, new XCommasApi(xCommasAccount.ApiKey, xCommasAccount.Secret)));
            }
        }

        public async Task<XCommasResponse<Bot>> Enable(int botId, Guid accountId)
        {
            return await _3CommasClients[accountId].Item2.EnableBotAsync(botId);
        }

        public async Task<XCommasResponse<Bot>> Disable(int botId, Guid accountId)
        {
            return await _3CommasClients[accountId].Item2.DisableBotAsync(botId);
        }

        public async Task<List<AccountViewModel>> RetrieveAccounts()
        {
            var accounts = new List<AccountViewModel>();

            foreach (var commasClient in _3CommasClients)
            {
                try
                {
                    var response = await commasClient.Value.Item2.GetAccountsAsync();
                    _logger.LogInformation($"Retrieving exchange information from 3Commas Account '{commasClient.Value.Item1}'...");
                    if (!response.IsSuccess)
                    {
                        _logger.LogError($"Problem with 3Commas connection (Account: '{commasClient.Value.Item1}'): " + response.Error);
                    }
                    else
                    {
                        _logger.LogInformation($"{response.Data.Length} Exchanges found");

                        var cfg = new MapperConfigurationExpression();
                        cfg.CreateMap<Account, AccountViewModel>();
                        var mapperConfig = new MapperConfiguration(cfg);
                        var mapper = mapperConfig.CreateMapper();

                        var result = new List<AccountViewModel>();
                        foreach (var account in response.Data)
                        {
                            var to = mapper.Map<Account, AccountViewModel>(account);
                            to.XCommasAccountId = commasClient.Key;
                            to.XCommasAccountName = commasClient.Value.Item1;
                            result.Add(to);
                        }
                        
                        accounts.AddRange(result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return accounts;
        }

        public async Task<List<AccountTableData>> GetAccountTableData(int accountId, Guid xCommasAccount)
        {
            var accounts = new List<AccountTableData>();

            var response = await _3CommasClients[xCommasAccount].Item2.GetAccountTableDataAsync(accountId);
            if (!response.IsSuccess)
            {
                this._logger.LogError($"Problem with 3Commas connection (Account: '{_3CommasClients[xCommasAccount].Item1}'): " + response.Error);
            }
            else
            {
                accounts = response.Data.ToList();
            }

            return accounts;
        }

        private async Task<List<BotWithExchangeInfo>> GetBotsByStrategyAndScope(Strategy strategy, BotScope scope, Guid xCommasAccount)
        {
            var bots = new List<Bot>();
            int take = 50;
            int skip = 0;
            while (true)
            {
                var response = await _3CommasClients[xCommasAccount].Item2.GetBotsAsync(limit: take, offset: skip, strategy: strategy, botScope: scope);
                if (!response.IsSuccess)
                {
                    throw new Exception($"Problem with 3Commas connection (Account: '{_3CommasClients[xCommasAccount].Item1}'): " + response.Error);
                }
                if (response.Data.Length == 0)
                {
                    break;
                }

                bots.AddRange(response.Data);
                skip += take;
            }

            return bots.Select(bot => new BotWithExchangeInfo(xCommasAccount, _3CommasClients[xCommasAccount].Item1, bot)).ToList();
        }

        public async Task<List<BotWithExchangeInfo>> GetAllBots()
        {
            var allBots = new List<BotWithExchangeInfo>();
            try
            {
                foreach (var commasClient in _3CommasClients)
                {
                    _logger.LogInformation($"Retrieving bots from 3Commas (Account: '{commasClient.Value.Item1}')...");
                    var bots = new List<BotWithExchangeInfo>();
                    bots.AddRange(await GetBotsByStrategyAndScope(Strategy.Long, BotScope.Enabled, commasClient.Key));
                    bots.AddRange(await GetBotsByStrategyAndScope(Strategy.Long, BotScope.Disabled, commasClient.Key));
                    bots.AddRange(await GetBotsByStrategyAndScope(Strategy.Short, BotScope.Enabled, commasClient.Key));
                    bots.AddRange(await GetBotsByStrategyAndScope(Strategy.Short, BotScope.Disabled, commasClient.Key));
                    _logger.LogInformation($"{bots.Count} bots found.");
                    allBots.AddRange(bots);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"An error occurred: {e.Message}");
            }
            return allBots;
        }

        public async Task<List<DealWithExchangeInfo>> GetAllDeals()
        {
            var allDeals = new List<DealWithExchangeInfo>();

            try
            {
                foreach (var commasClient in _3CommasClients)
                {
                    var deals = new List<DealWithExchangeInfo>();
                    _logger.LogInformation($"Retrieving deals from 3Commas (Account: '{commasClient.Value.Item1}')...");

                    int take = 1000;
                    int skip = 0;
                    while (true)
                    {
                        var response = await commasClient.Value.Item2.GetDealsAsync(limit: take, offset: skip, dealScope: DealScope.Active, dealOrder: DealOrder.CreatedAt);
                        if (!response.IsSuccess)
                        {
                            throw new Exception($"Problem with 3Commas connection (Account: '{commasClient.Value.Item1}'): " + response.Error);
                        }

                        if (response.Data.Length == 0)
                        {
                            break;
                        }

                        deals.AddRange(response.Data.Select(deal => new DealWithExchangeInfo(commasClient.Key, commasClient.Value.Item1, deal)));
                        skip += take;
                    }
                    _logger.LogInformation($"{deals.Count} deals found.");
                    allDeals.AddRange(deals);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"An error occurred: {e.Message}");
            }

            return allDeals;
        }

        public async Task EnableTrailing(int dealId, Guid xCommasAccount)
        {
            await SetTrailing(dealId, true, xCommasAccount);
        }

        public async Task DisableTrailing(int dealId, Guid xCommasAccount)
        {
            await SetTrailing(dealId, false, xCommasAccount);
        }

        private async Task SetTrailing(int dealId, bool enableTrailing, Guid xCommasAccount)
        {
            try
            {
                var res = await _3CommasClients[xCommasAccount].Item2.UpdateDealAsync(dealId, new DealUpdateData(dealId) { TrailingEnabled = enableTrailing });
                if (!res.IsSuccess)
                {
                    _logger.LogError($"Could not update deal {dealId}: {res.Error}");
                }
                else
                {
                    _logger.LogInformation($"Deal {dealId} updated.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"An error occurred: {e.Message}");
            }
        }

        public async Task CancelDeal(int dealId, Guid xCommasAccount)
        {
            try
            {
                var res = await _3CommasClients[xCommasAccount].Item2.CancelDealAsync(dealId);
                if (!res.IsSuccess)
                {
                    _logger.LogError($"Could not cancel deal {dealId}: {res.Error}");
                }
                else
                {
                    _logger.LogInformation($"Deal {dealId} cancelled.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"An error occurred: {e.Message}");
            }
        }

        public async Task PanicSellDeal(int dealId, Guid xCommasAccount)
        {
            try
            {
                var res = await _3CommasClients[xCommasAccount].Item2.PanicSellDealAsync(dealId);
                if (!res.IsSuccess)
                {
                    _logger.LogError($"Could not panic sell deal {dealId}: {res.Error}");
                }
                else
                {
                    _logger.LogInformation($"Deal {dealId} panic sold.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"An error occurred: {e.Message}");
            }
        }

        public async Task<XCommasResponse<Bot>> SaveBot(int botId, BotUpdateData updateData, Guid xCommasAccount)
        {
            return await _3CommasClients[xCommasAccount].Item2.UpdateBotAsync(botId, updateData);
        }

        public async Task<XCommasResponse<bool>> DeleteBot(int botId, Guid xCommasAccount)
        {
            return await _3CommasClients[xCommasAccount].Item2.DeleteBotAsync(botId);
        }

        public static string GenerateNewName(string pattern, string strategy, string[] pairs, string accountName)
        {
            string pairText;

            if (pairs.Length > 1)
            {
                pairText = pairs.First().Split('_').First();
            }
            else
            {
                pairText = pairs.Single();
            }

            return pattern
                .Replace("{account}", accountName)
                .Replace("{strategy}", strategy)
                .Replace("{pair}", pairText);
        }

        public async Task<Bot> GetBotById(int botId, Guid xCommasAccount)
        {
            return (await _3CommasClients[xCommasAccount].Item2.ShowBotAsync(botId)).Data;
        }

        public async Task UpdateDealAsync(DealUpdateData data, Guid xCommasAccount)
        {
            var res = await _3CommasClients[xCommasAccount].Item2.UpdateDealAsync(data.DealId, data);

            if (res.IsSuccess)
            {
                _logger.LogInformation($"Deal {data.DealId} updated");
            }
            else
            {
                _logger.LogError($"Could not update deal {data.DealId}. Reason: {res.Error}");
            }
        }

        public async Task AddFundsAsync(DealAddFundsParameters data, string baseCoin, decimal quoteQty, string quoteCoin, Guid xCommasAccount)
        {
            var res = await _3CommasClients[xCommasAccount].Item2.AddFundsToDealAsync(data);
            
            if (res.IsSuccess)
            {
                _logger.LogInformation($"Funds added to deal {data.DealId}: {data.Quantity.ToString("0.#####")} {baseCoin.ToUpper()} / {quoteQty.ToString("0.#####")} {quoteCoin.ToUpper()}");
            }
            else
            {
                _logger.LogError($"Could not add funds to deal {data.DealId}. Reason: {res.Error}");
            }
        }

        public async Task<MarketplaceItem[]> GetMarketplaceItems()
        {
            return (await _3CommasClients.First().Value.Item2.GetMarketplaceItemsAsync()).Data;
        }

        public async Task<XCommasResponse<Bot>> CreateBot(int accountId, Strategy strategy, BotData botData, Guid xCommasAccount)
        {
            return (await _3CommasClients[xCommasAccount].Item2.CreateBotAsync(accountId, strategy, botData));
        }
    }
}
