using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.MainForm
{
    public class BotViewModel : Bot
    {
        [DisplayName("Deal Start Condition")]
        public string DealStartConditionDisplayString => string.Join(", ", Strategies.Select(x => x.Name));
    }
}
