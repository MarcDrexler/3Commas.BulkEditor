using System;
using _3Commas.BulkEditor.Misc;

namespace _3Commas.BulkEditor.Infrastructure
{
    public class KeysChangedEventArgs : EventArgs
    {
        public XCommasAccounts Keys { get; set; }
    }

    public class StopAllBotsEventArgs : EventArgs
    {
    }
}