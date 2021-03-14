using System.Collections.Generic;
using _3Commas.BulkEditor.Views.CopyBotDialog;
using M.EventBroker;
using M.EventBroker.EvenHandlerRunners;
using Microsoft.Extensions.Logging;

namespace _3Commas.BulkEditor.Infrastructure
{
    public static class ObjectContainer
    {
        public static IMessageBoxService MessageBoxService { get; } = new MessageBoxService();
        public static ILogger Logger { get; set; }
        public static IEventBroker EventBroker { get; set; } = new EventBroker(new UnrestrictedThreadPoolRunner());
        public static IKeyStore KeyManager { get; set; } = new KeyStore();

        public static class Cache
        {
            public static void SetAccounts(List<AccountViewModel> accounts)
            {
                Accounts = accounts;
            }

            public static List<AccountViewModel> Accounts { get; private set; } = new List<AccountViewModel>();
        }
    }
}
