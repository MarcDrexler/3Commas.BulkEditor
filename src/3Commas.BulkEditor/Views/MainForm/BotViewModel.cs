using System.ComponentModel;
using System.Linq;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.MainForm
{
    public class BotViewModel : Bot
    {
        [DisplayName("Deal Start Condition")]
        public string DealStartConditionDisplayString => string.Join(", ", Strategies.Select(x => x.Name));
    }
}
