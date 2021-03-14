using System;
using System.ComponentModel;
using System.Linq;
using _3Commas.BulkEditor.Misc;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.ManageBotControl
{
    public class BotViewModel : Bot
    {
        [DisplayName("Type")]
        public string BotType
        {
            get
            {
                switch (Type)
                {
                    case "Bot::SingleBot":
                        return "Simple";
                    case "Bot::MultiBot":
                        return "Composite";
                    default:
                        return Type;
                }
            }
        }

        [DisplayName("Deal Start Condition")]
        public string DealStartCondition => string.Join(", ", Strategies.Select(x => x.ToHumanReadableString()));

        [DisplayName("Pair")]
        public string Pair => String.Join(", ", Pairs);

        [DisplayName("Enabled")]
        public new bool IsEnabled { get; set; }

        [DisplayName("Account")]
        public new string AccountName { get; set; }

        [DisplayName("TP")]
        public new string TakeProfit { get; set; }

        [DisplayName("TP Type")]
        public new TakeProfitType TakeProfitType { get; set; }

        [DisplayName("Profit Ratio")]
        public decimal ProfitRatio => FinishedDealsCount > 0 ? Math.Round(FinishedDealsProfitUsd / FinishedDealsCount, 2) : 0;

        public Guid XCommasAccountId { get; set; }

        [DisplayName("3Commas Account")]
        public string XCommasAccountName { get; set; }
    }
}
