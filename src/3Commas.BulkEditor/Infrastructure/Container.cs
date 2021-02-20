using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3Commas.BulkEditor.Misc;
using Microsoft.Extensions.Logging;

namespace _3Commas.BulkEditor.Infrastructure
{
    public static class ObjectContainer
    {
        public static IMessageBoxService MessageBoxService { get; } = new MessageBoxService();
        public static ILogger Logger { get; set; }
    }
}
