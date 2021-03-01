using System.Threading.Tasks;
using _3Commas.BulkEditor.Infrastructure;
using _3Commas.BulkEditor.Misc;
using Microsoft.Extensions.Logging;

namespace _3Commas.BulkEditor.Views.MainForm
{
    public interface IMainForm : IViewBase
    {
        void ClearLog();
        void InitGrids(Keys keys, ILogger logger, IMessageBoxService mbs);
        void SetAccountCount(int numberOfAccounts);
    }
}