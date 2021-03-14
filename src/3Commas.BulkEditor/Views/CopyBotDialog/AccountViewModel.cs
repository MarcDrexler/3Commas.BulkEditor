using System;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.CopyBotDialog
{
    public class AccountViewModel : Account
    {
        public Guid XCommasAccountId { get; set; }
        public string XCommasAccountName { get; set; }
    }
}