using System;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Misc
{
    public class BotWithExchangeInfo
    {
        public Guid XCommasAccount { get; set; }
        public string XCommasAccountName { get; set; }
        public Bot Bot { get; set; }

        public BotWithExchangeInfo(Guid xCommasAccount, string xCommasAccountName, Bot bot)
        {
            XCommasAccount = xCommasAccount;
            XCommasAccountName = xCommasAccountName;
            Bot = bot;
        }
    }
}