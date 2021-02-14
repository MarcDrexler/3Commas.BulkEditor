using System.Windows.Forms;

namespace _3Commas.BulkEditor.Infrastructure
{
    public abstract class PresenterBase<TView> where TView: IWin32Window
    {
        protected PresenterBase(TView view)
        {
            View = view;
        }

        public TView View { get; set; }
    }
}