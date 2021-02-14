using System;

namespace _3Commas.BulkEditor.Views.BaseControls
{
    public class IsBusyEventArgs : EventArgs
    {
        public bool IsBusy { get; private set; }

        public IsBusyEventArgs(bool isBusy)
        {
            IsBusy = isBusy;
        }
    }
}