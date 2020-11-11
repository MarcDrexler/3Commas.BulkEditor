using System.ComponentModel;
using System.Linq;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.MainForm
{
    public class BotViewModel : Bot
    {
        [DisplayName("Deal Start Condition")]
        public string DealStartCondition => string.Join(", ", Strategies.Select(x => x.ToHumanReadableString()));

        [DisplayName("Pair")]
        public string Pair => Pairs.FirstOrDefault();
    }
}
