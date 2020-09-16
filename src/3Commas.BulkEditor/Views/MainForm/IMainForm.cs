using System.Collections.Generic;
using _3Commas.BulkEditor.Infrastructure;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Views.MainForm
{
    public interface IMainForm : IViewBase
    {
        List<int> SelectedBotIds { get; }
        void SetTotalBotCount(int count);
        void RefreshBotGrid(List<Bot> bots);
        void ClearLog();
        void SetCreateInProgress(bool inProgress);
        void SetVisibleCount(int count);
        void ShowFilterInformation(bool show);
        void SetSelectedRowCount(int count);
    }
}