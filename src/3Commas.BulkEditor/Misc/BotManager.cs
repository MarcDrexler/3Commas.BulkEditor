using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using XCommas.Net;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Misc
{
    public class BotManager
    {
        private readonly ILogger _logger;
        private readonly XCommasApi _3CommasClient;

        public BotManager(Keys settings, ILogger logger)
        {
            _logger = logger;
            _3CommasClient = new XCommasApi(settings.ApiKey3Commas, settings.Secret3Commas);
        }

        public async Task<XCommasResponse<Bot>> Enable(int botId)
        {
            return await _3CommasClient.EnableBotAsync(botId);
        }

        public async Task<XCommasResponse<Bot>> Disable(int botId)
        {
            return await _3CommasClient.DisableBotAsync(botId);
        }

        private async Task<List<Bot>> GetBotsByStrategyAndScope(Strategy strategy, BotScope scope)
        {
            var bots = new List<Bot>();
            int take = 100;
            int skip = 0;
            while (true)
            {
                var result = await _3CommasClient.GetBotsAsync(limit: take, offset: skip, strategy: strategy, botScope: scope);
                if (!result.IsSuccess)
                {
                    throw new Exception("3Commas Connection Issue: " + result.Error);
                }
                if (result.Data.Length == 0)
                {
                    break;
                }

                bots.AddRange(result.Data);
                skip += take;
            }

            return bots;
        }

        public async Task<List<Bot>> GetAllBots()
        {
            var bots = new List<Bot>();
            try
            {
                _logger.LogInformation("Retrieving bots from 3Commas...");
                bots.AddRange(await GetBotsByStrategyAndScope(Strategy.Long, BotScope.Enabled));
                bots.AddRange(await GetBotsByStrategyAndScope(Strategy.Long, BotScope.Disabled));
                bots.AddRange(await GetBotsByStrategyAndScope(Strategy.Short, BotScope.Enabled));
                bots.AddRange(await GetBotsByStrategyAndScope(Strategy.Short, BotScope.Disabled));
                _logger.LogInformation($"{bots.Count} bots found.");
            }
            catch (Exception e)
            {
                _logger.LogError($"An error occurred: {e.Message}");
            }
            return bots;
        }

        public async Task<XCommasResponse<Bot>> SaveBot(int botId, BotUpdateData updateData)
        {
            return await _3CommasClient.UpdateBotAsync(botId, updateData);
        }

        public static string GenerateNewName(string pattern, string strategy, string pair)
        {
            return pattern.Replace("{strategy}", strategy).Replace("{pair}", pair);
        }

        public async Task<Bot> GetBotById(int botId)
        {
            return (await _3CommasClient.ShowBotAsync(botId)).Data;
        }
    }
}
