using System.Collections.Generic;
using System.Windows.Forms;
using M.EventBroker;
using M.EventBroker.EvenHandlerRunners;
using Microsoft.Extensions.Logging;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Infrastructure
{
    public static class ObjectContainer
    {
        public static IMessageBoxService MessageBoxService { get; } = new MessageBoxService();
        public static ILogger Logger { get; set; }
        public static IEventBroker EventBroker { get; set; } = new EventBroker(new UnrestrictedThreadPoolRunner());

        public static class Cache
        {
            public static void SetAccounts(List<Account> accounts)
            {
                Accounts = accounts;
            }

            public static List<Account> Accounts { get; private set; } = new List<Account>();
        }
    }
}
