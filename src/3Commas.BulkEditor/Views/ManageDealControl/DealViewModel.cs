using System.ComponentModel;
using System.Linq;
using _3Commas.BulkEditor.Infrastructure;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.ManageDealControl
{
    public class DealViewModel : Deal
    {
        [DisplayName("Type")] public new string DealType { get; set; }

        [DisplayName("Account")]
        public string Account
        {
            get { return ObjectContainer.Cache.Accounts.SingleOrDefault(x => x.Id == AccountId)?.Name; }
        }
    }
}