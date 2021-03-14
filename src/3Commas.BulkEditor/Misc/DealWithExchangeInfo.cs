using System;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Misc
{
    public class DealWithExchangeInfo
    {
        public Guid XCommasAccount { get; set; }
        public string XCommasAccountName { get; set; }
        public Deal Deal { get; set; }

        public DealWithExchangeInfo(Guid xCommasAccount, string xCommasAccountName, Deal deal)
        {
            XCommasAccount = xCommasAccount;
            XCommasAccountName = xCommasAccountName;
            Deal = deal;
        }
    }
}