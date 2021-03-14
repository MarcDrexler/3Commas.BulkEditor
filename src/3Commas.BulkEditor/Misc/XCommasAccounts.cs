using System;
using System.Collections.Generic;
using System.Linq;

namespace _3Commas.BulkEditor.Misc
{
    [Serializable]
    public class XCommasAccounts
    {
        public List<XCommasAccount> Accounts { get; set; } = new List<XCommasAccount>();

        public bool IsEmpty => !Accounts.Any();
    }
}