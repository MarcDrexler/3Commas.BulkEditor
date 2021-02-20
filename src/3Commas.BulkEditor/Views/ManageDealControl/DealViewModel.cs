using System.ComponentModel;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.ManageDealControl
{
    public class DealViewModel : Deal
    {
        [DisplayName("Type")]
        public new string DealType { get; set; }
    }
}